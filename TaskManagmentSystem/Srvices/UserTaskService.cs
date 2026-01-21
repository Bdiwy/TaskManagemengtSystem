using Humanizer;
using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repositories.Interfaces;
using TaskManagmentSystem.Srvices.Interfaces;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Srvices
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly INotificationService _notificationService;

        public UserTaskService(IUserTaskRepository userTaskRepository, INotificationService notificationService)
        {
            _userTaskRepository = userTaskRepository;
            _notificationService = notificationService;
        }

        public async Task<List<UserTask?>> GetByUserIdAsync(string userId)
        {
            return await _userTaskRepository.GetByUserIdAsync(userId);
        }

        public async Task<OperationResult> CreateAsync(UserTaskAddViewModel request, string? userId)
        {
            if (userId is null)
                return OperationResult.Failure("User not found");

            var userTask = new UserTask
            {
                Title = request.Title,
                Description = request.Description,
                CreaterId = userId,
                BeginOn = request.BeginOn,
                EndOn = request.EndOn,
                TaskListId = request.TaskListId,
                Color = request.Color,
                Priority = request.Priority,
                Status = request.Status,
                CreatedDate = DateTime.Now
            };

            if (userTask.BeginOn is not null)
                userTask.RemindMeBeforeBegin = userTask.BeginOn - request.RemindMeBeforeBegin.Minutes();

            if (userTask.EndOn is not null)
                userTask.RemindMeBeforeEnd = userTask.EndOn - request.RemindMeBeforeEnd.Minutes();

            var result = await _userTaskRepository.CreateAsync(userTask);
            if (!result.Succeeded)
                return result;

            await _notificationService.ManageTaskBeginAndEndAsync(userId, userTask);
            return result;
        }

        public async Task<OperationResult<UserTaskEditViewModel>> GetForEditAsync(int id, int workSpaceId)
        {
            var userTask = await _userTaskRepository.GetByIdAsync(id);
            if (userTask is null)
                return OperationResult<UserTaskEditViewModel>.Failure("Task not found");

            var viewModel = new UserTaskEditViewModel
            {
                Id = id,
                WorkSpaceId = workSpaceId,
                Title = userTask.Title,
                Description = userTask.Description,
                Status = userTask.Status,
                Priority = userTask.Priority,
                BeginOn = userTask.BeginOn,
                EndOn = userTask.EndOn,
                Color = userTask.Color,
                RemindMeBeforeBegin = 0,
                RemindMeBeforeEnd = 0
            };

            return OperationResult<UserTaskEditViewModel>.Success(viewModel);
        }

        public async Task<OperationResult> UpdateAsync(UserTaskEditViewModel request, string? editorId)
        {
            var userTask = await _userTaskRepository.GetByIdAsync(request.Id);
            if (userTask is null)
                return OperationResult.Failure("Task not found");

            userTask.Title = request.Title;
            userTask.Description = request.Description;
            userTask.LastEditDate = DateTime.Now;
            userTask.Status = request.Status;
            userTask.Priority = request.Priority;
            userTask.BeginOn = request.BeginOn;
            userTask.EndOn = request.EndOn;
            userTask.Color = request.Color;

            return await _userTaskRepository.UpdateAsync(userTask, editorId);
        }

        public Task<OperationResult> DeleteAsync(int id)
            => _userTaskRepository.DeleteAsync(id);

        public Task<OperationResult> SetIsDoneAsync(CheckIsDoneTaskViewModel viewModel)
        {
            if (viewModel is null)
                return Task.FromResult(OperationResult.Failure("Invalid request"));

            return _userTaskRepository.SetIsDoneAsync(viewModel.Id, viewModel.IsDone);
        }
    }
}
