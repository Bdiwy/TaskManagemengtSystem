using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Srvices.Interfaces
{
    public interface IUserTaskService
    {
        Task<OperationResult> CreateAsync(UserTaskAddViewModel request, string? userId);
        Task<OperationResult<UserTaskEditViewModel>> GetForEditAsync(int id, int workSpaceId);
        Task<OperationResult> UpdateAsync(UserTaskEditViewModel request, string? editorId);
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult> SetIsDoneAsync(CheckIsDoneTaskViewModel viewModel);
    }
}
