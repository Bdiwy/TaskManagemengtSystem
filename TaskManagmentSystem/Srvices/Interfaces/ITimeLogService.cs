using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Srvices.Interfaces
{
    public interface ITimeLogService
    {
        Task<OperationResult<TimeLog>> GetByIdAsync(int id);
        Task<OperationResult> CreateAsync(TimeLogViewModel timeLogFromRequest);
        Task<OperationResult> UpdateAsync(TimeLogViewModel timeLogFromRequest);
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult<List<TimeLog>>> GetForUserAsync(string userId);
        Task<OperationResult<List<TimeLog>>> GetForTaskAsync(int teamId, string userId);
        Task<OperationResult<TimeLogViewModel>> GetForTeamShowAsync(int teamId, string userId);
    }
}