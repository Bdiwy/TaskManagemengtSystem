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

        public async Task<OperationResult<TimeLogViewModel>> GetByIdAsync(int id)
        {
            var result = await _timeLogRepository.GetByIdAsync(id);
            if (result == null)
            {
                return OperationResult<TimeLogViewModel>.Failure("TimeLog not found");
            }

            var timeLogViewModel = new TimeLogViewModel
            {
                Id = result.Id,
                Actul = result.Actul,
                Allocat = result.Allocat,
                Progress = result.Progress,
                TaskId = result.TaskId,
                UserId = result.UserId
            };
            return OperationResult<TimeLogViewModel>.Success(timeLogViewModel);
        }

        public async Task<OperationResult> CreateAsync(TimeLogViewModel timeLogFromRequest)
        {
            var result = await _timeLogRepository.CreateAsync(timeLogFromRequest);
            return result;
        }

        public async Task<OperationResult> UpdateAsync(TimeLogViewModel timeLogFromRequest)
        {
                var result = await _timeLogRepository.UpdateAsync(timeLogFromRequest);
                return result;
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
