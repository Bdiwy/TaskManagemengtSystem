using Microsoft.EntityFrameworkCore;
using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repositories.Interfaces;

namespace TaskManagmentSystem.Repositories
{
    public class UserTaskRepository(AppDbContext _context) : IUserTaskRepository
    {
        public async Task<UserTask?> GetByIdAsync(int id)
        {
            return await _context.UserTasks.FindAsync(id);
        }

        public async Task<OperationResult> CreateAsync(UserTask userTask)
        {
            await _context.UserTasks.AddAsync(userTask);
            var saved = await _context.SaveChangesAsync();
            return saved > 0
                ? OperationResult.Success()
                : OperationResult.Failure("Failed to create the task");
        }
        
        public async Task<List<UserTask?>> GetByUserIdAsync(string userId)
        {
            return await _context.UserTasks
                .Where(ut => ut.CreaterId == userId)
                .Select(ut => (UserTask?)ut)
                .ToListAsync();
        }

        public async Task<OperationResult> UpdateAsync(UserTask userTask, string? editorId)
        {
            if (editorId is not null)
            {
                _context.TaskEdiotor.Add(new TaskEdiotor
                {
                    EditorId = editorId,
                    TaskEditedId = userTask.Id
                });
            }

            var saved = await _context.SaveChangesAsync();
            return saved > 0
                ? OperationResult.Success()
                : OperationResult.Failure("Failed to update the task");
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            var userTask = await _context.UserTasks.FindAsync(id);
            if (userTask is null)
                return OperationResult.Success();

            _context.UserTasks.Remove(userTask);
            var saved = await _context.SaveChangesAsync();
            return saved > 0
                ? OperationResult.Success()
                : OperationResult.Failure("Failed to delete the task");
        }

        public async Task<OperationResult> SetIsDoneAsync(int id, bool isDone)
        {
            var userTask = await _context.UserTasks.FindAsync(id);
            if (userTask is null)
                return OperationResult.Failure("Task not found");

            userTask.IsDone = isDone;
            var saved = await _context.SaveChangesAsync();
            return saved > 0
                ? OperationResult.Success()
                : OperationResult.Failure("Failed to update task state");
        }
    }
}
