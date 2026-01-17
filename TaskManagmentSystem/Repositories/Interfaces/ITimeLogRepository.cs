using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ViewModels;
namespace TaskManagmentSystem.Repositories.Interfaces
{
    public interface ITimeLogRepository
    {
        Task<OperationResult<PaginatedResult<TimeLogViewModel>>> GetAllAsync(int page, int pageSize, int? filterWithTask);
        Task<TimeLog> GetByIdAsync(int id);
        Task<OperationResult> CreateAsync(TimeLogViewModel timeLogViewModel);
        Task<OperationResult> UpdateAsync(TimeLogViewModel timeLogToUpdate);
        Task<OperationResult> DeleteAsync(int id);
    }
}