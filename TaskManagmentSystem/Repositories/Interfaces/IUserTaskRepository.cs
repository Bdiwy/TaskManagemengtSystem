using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repositories.Interfaces
{
    public interface IUserTaskRepository
    {
        Task<UserTask?> GetByIdAsync(int id);
        Task<List<UserTask?>> GetByUserIdAsync(string userId);
        Task<OperationResult> CreateAsync(UserTask userTask);
        Task<OperationResult> UpdateAsync(UserTask userTask, string? editorId);
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult> SetIsDoneAsync(int id, bool isDone);
    }
}
