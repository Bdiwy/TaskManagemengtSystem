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

        public async Task<OperationResult<List<TimeLogViewModel>>> GetAllAsync()
        {
            var result = await _timeLogRepository.GetAllAsync();
            return result;
        }

        public async Task<OperationResult<TimeLog>> GetByIdAsync(int id)
        {
            var result = await _timeLogRepository.GetByIdAsync(id);
            return OperationResult<TimeLog>.Success(result);
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

        public Task<OperationResult<List<TimeLogViewModel>>> GetForUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TimeLogViewModel>>> GetForTaskAsync(int teamId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TimeLogViewModel>> GetForTeamShowAsync(int teamId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
