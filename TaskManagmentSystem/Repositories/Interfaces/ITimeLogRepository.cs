using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ViewModels;
namespace TaskManagmentSystem.Repositories.Interfaces
{
    public interface ITimeLogRepository
    {
        Task<OperationResult<List<TimeLogViewModel>>> GetAllAsync();
        Task<TimeLog> GetByIdAsync(int id);
        Task<OperationResult> CreateAsync(TimeLogViewModel timeLogViewModel);
        Task<OperationResult> UpdateAsync(TimeLogViewModel timeLogToUpdate);
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult<List<TimeLog>>> GetForUserAsync(string userId);
        Task<OperationResult<List<TimeLog>>> GetForTaskAsync(int teamId, string userId);
        Task<OperationResult<TimeLogViewModel>> GetForTeamShowAsync(int teamId, string userId);
    }
}