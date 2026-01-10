using Microsoft.EntityFrameworkCore;
using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repositories.Interfaces;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Repositories
{
    public class TimeLogRepository(AppDbContext _context) : ITimeLogRepository
    {
        public Task<OperationResult<TimeLog>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> CreateAsync(TimeLogViewModel timeLogFromRequest)
        {
            var newTimeLog = new TimeLog();
            newTimeLog.Allocat = timeLogFromRequest.Allocat;
            newTimeLog.Actul = timeLogFromRequest.Actul;
            newTimeLog.Progress = timeLogFromRequest.Progress;
            newTimeLog.TaskId = timeLogFromRequest.TaskId;
            
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
            
            var result = await _context.SaveChangesAsync();
            
            if (result > 0)
                return OperationResult.Success();
            else
                return OperationResult.Failure("Failed to update the time log entry");
        }

        public Task<OperationResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TimeLog>>> GetForUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TimeLog>>> GetForTaskAsync(int teamId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TimeLogViewModel>> GetForTeamShowAsync(int teamId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
