using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ModelsView;
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

        public Task<OperationResult> CreateAsync(WorkSpaceViewModel workSpaceToCreate, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> UpdateAsync(WorkSpaceForEditViewModel workSpaceToUpdate)
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
