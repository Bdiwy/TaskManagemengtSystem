using TaskManagmentSystem.ViewModels;
using TaskManagmentSystem.Repositories.Interfaces;
using System.Security.Claims;
namespace TaskManagmentSystem.Services
{
    class AnalysisService(
        IHttpContextAccessor _httpContextAccessor,
        IWorkSpaceRepository _workSpaceRepository ,
        IUserTaskRepository _userTaskRepository,
        ITimeLogRepository _timeLogRepository
        )
    {
        private string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        
        public async Task<AnalysisViewModel?> GetAnalysisAsync()
        {
            var workSpaces = await _workSpaceRepository.GetForUserAsync(UserId!);
            if (workSpaces is null || workSpaces.Data.Count == 0)
                    return null;

            var tasks = await _userTaskRepository.GetByUserIdAsync(UserId!);
            var timeLogs = await _timeLogRepository.GetAllAsync(1, int.MaxValue, null);
            var userTimeLogs = timeLogs.Data.Items.Where(tl => tl.UserId == UserId).ToList();

            var totalTasks = tasks.Count;
            var totalWorkSpaces = workSpaces.Data.Count;
            var totalTimeLogged = userTimeLogs.Sum(tl => tl.Actul);

            var analysis = new AnalysisViewModel
            {
                TotalTasks = totalTasks,
                TotalTimeLoggedInHours = totalTimeLogged / 60.0,
                TotalWorkSpaces = totalWorkSpaces,
                UserStreak = 0,
            };
            return analysis;
        }
    }
}