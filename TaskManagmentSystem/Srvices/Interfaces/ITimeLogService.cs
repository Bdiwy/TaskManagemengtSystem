using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Srvices.Interfaces
{
    public interface ITimeLogService
    {
        Task<OperationResult<List<TimeLogViewModel>>> GetAllAsync();
        Task<OperationResult<TimeLog>> GetByIdAsync(int id);
        Task<OperationResult> CreateAsync(TimeLogViewModel timeLogFromRequest);
        Task<OperationResult> UpdateAsync(TimeLogViewModel timeLogFromRequest);
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult<List<TimeLogViewModel>>> GetForUserAsync(string userId);
        Task<OperationResult<List<TimeLogViewModel>>> GetForTaskAsync(int teamId, string userId);
        Task<OperationResult<TimeLogViewModel>> GetForTeamShowAsync(int teamId, string userId);
    }
}