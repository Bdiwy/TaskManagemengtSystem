using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repositories.Interfaces
{
    public interface IWorkSpaceRepository
    {
        Task<OperationResult<TimeLog>> GetByIdAsync(int id);
        Task<OperationResult> CreateAsync(TimeLog workSpace);
        Task<OperationResult> UpdateAsync(TimeLog workSpace);
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult<List<TimeLog>>> GetForUserAsync(string userId);
        Task<OperationResult<List<TimeLog>>> GetForTeamAsync(int teamId);
    }
}
