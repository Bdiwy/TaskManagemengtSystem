using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Srvices.Interfaces
{
    public interface ITimeLogService
    {
        Task<OperationResult<PaginatedResult<TimeLogViewModel>>> GetAllAsync(int? page, int? pageSize, int? filterWithTask);
        Task<OperationResult<TimeLogViewModel>> GetByIdAsync(int id);
        Task<OperationResult> CreateAsync(TimeLogViewModel timeLogFromRequest);
        Task<OperationResult> UpdateAsync(TimeLogViewModel timeLogFromRequest);
        Task<OperationResult> DeleteAsync(int id);
        Task<List<DateTime>> GetDistinctDatesByUserIdAsync(string userId);
    }
}