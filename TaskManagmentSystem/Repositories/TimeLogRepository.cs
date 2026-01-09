using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ModelsView;
using TaskManagmentSystem.ViewModels;

using TaskManagmentSystem.Repositories.Interfaces;

namespace TaskManagmentSystem.Repositories
{
    public class TimeLogRepository : ITimeLogRepository
    {
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
