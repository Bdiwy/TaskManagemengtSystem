using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repositories.Interfaces;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Repositories
{
    public class TimeLogRepository(AppDbContext _context , IHttpContextAccessor _httpContextAccessor) : ITimeLogRepository
    {
        private string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        public async Task<OperationResult<PaginatedResult<TimeLogViewModel>>> GetAllAsync(int page, int pageSize, int? filterWithTaskId)
        {
            var query = _context.TimeLog.Where(t => t.UserId == UserId);
            if (filterWithTaskId is not null)
                query = query.Where(t => t.TaskId == filterWithTaskId);
            var result = await query.Select(tl => new TimeLogViewModel
            {
                Actul = tl.Actul,
                Allocat = tl.Allocat,
                Progress = tl.Progress,
                TaskTitle = tl.Task.Title,
                Id = tl.Id,
                TaskId = tl.TaskId
            }).ToPaginatedListAsync(page, pageSize);
            return OperationResult<PaginatedResult<TimeLogViewModel>>.Success(result);
        }
        public async Task<TimeLog> GetByIdAsync(int id)
        {
            return await _context.TimeLog.FindAsync(id);
        }

        public async Task<OperationResult> CreateAsync(TimeLogViewModel timeLogFromRequest)
        {
            var newTimeLog = new TimeLog();
            newTimeLog.Allocat = timeLogFromRequest.Allocat;
            newTimeLog.Actul = timeLogFromRequest.Actul;
            newTimeLog.Progress = timeLogFromRequest.Progress;
            newTimeLog.TaskId = timeLogFromRequest.TaskId;
            newTimeLog.UserId = timeLogFromRequest.UserId!;

            await _context.TimeLog.AddAsync(newTimeLog);
            var result = await _context.SaveChangesAsync();
            
            if (result > 0)
                return OperationResult.Success();
            else
                return OperationResult.Failure("Failed to save the time log entry");
        }

        public async Task<OperationResult> UpdateAsync(TimeLogViewModel timeLogToUpdate)
        {
            var timeLog = await _context.TimeLog.FindAsync(timeLogToUpdate.Id);
            if (timeLog == null)
                return OperationResult.Failure("Time log not found");

            timeLog.Allocat = timeLogToUpdate.Allocat;
            timeLog.Actul = timeLogToUpdate.Actul;
            timeLog.Progress = timeLogToUpdate.Progress;
            timeLog.TaskId = timeLogToUpdate.TaskId;
            
            var result = await _context.SaveChangesAsync();
            
            if (result > 0)
                return OperationResult.Success();
            else
                return OperationResult.Failure("Failed to update the time log entry");
        }

        public Task<OperationResult> DeleteAsync(int id)
        {

            var timeLog = _context.TimeLog.Find(id);
            if (timeLog != null)
            {
                _context.TimeLog.Remove(timeLog);
                _context.SaveChanges();
            }
            return Task.FromResult(OperationResult.Success());
        }
    }
}
