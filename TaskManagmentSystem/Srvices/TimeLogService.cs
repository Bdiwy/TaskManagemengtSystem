using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repositories.Interfaces;
using TaskManagmentSystem.ViewModels;
using TaskManagmentSystem.Srvices.Interfaces;
namespace TaskManagmentSystem.Srvices
{
    public class TimeLogService: ITimeLogService
    {
        private readonly ITimeLogRepository _timeLogRepository;

        public TimeLogService(ITimeLogRepository timeLogRepository)
        {
            _timeLogRepository = timeLogRepository;
        }

        public Task<OperationResult<TimeLog>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> CreateAsync(TimeLogViewModel timeLogFromRequest)
        {
            var result = await _timeLogRepository.CreateAsync(timeLogFromRequest);
            return result;
        }

        public Task<OperationResult> UpdateAsync(TimeLogViewModel timeLogFromRequest)
        {
            throw new NotImplementedException();
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
