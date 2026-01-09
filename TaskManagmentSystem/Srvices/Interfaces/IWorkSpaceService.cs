using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Srvices.Interfaces
{
    public interface IWorkSpaceService
    {
        Task<OperationResult<TimeLog>> GetByIdAsync(int id);
        Task<OperationResult> CreateAsync(WorkSpaceViewModel workSpaceToCreate, string userId);
        Task<OperationResult> UpdateAsync(WorkSpaceForEditViewModel workSpaceToUpdate);
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult<List<TimeLog>>> GetForUserAsync(string userId);
        Task<OperationResult<List<TimeLog>>> GetForTeamAsync(int teamId, string userId);
        Task<OperationResult<FullDataWorkSpaceForTeamViewModel>> GetForTeamShowAsync(int teamId, string userId);
    }
}
