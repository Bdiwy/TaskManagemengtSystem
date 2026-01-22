using TaskManagmentSystem.ViewModels;
using TaskManagmentSystem.Srvices.Interfaces;
using System.Security.Claims;
using NuGet.Protocol;
namespace TaskManagmentSystem.Services
{
    class AnalysisService(
        IHttpContextAccessor _httpContextAccessor,
        IWorkSpaceService _workSpaceService,
        IUserTaskService _userTaskService,
        ITimeLogService _timeLogService
        )
    {
        private string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        public record StreakResult(int current, int longest);
        public async Task<AnalysisViewModel?> GetAnalysisAsync()
        {
            var workSpacesResult = await _workSpaceService.GetForUserAsync(UserId!);
            if (!workSpacesResult.Succeeded || workSpacesResult.Data is null || workSpacesResult.Data.Count == 0)
                    return null;

            var tasks = await _userTaskService.GetByUserIdAsync(UserId!);
            var timeLogs = await _timeLogService.GetAllAsync(1, int.MaxValue, null);
            var userTimeLogs = timeLogs.Data.Items.Where(tl => tl.UserId == UserId).ToList();

            var totalTasks = tasks.Count;
            var totalWorkSpaces = workSpacesResult.Data.Count;
            var totalTimeLogged = userTimeLogs.Sum(tl => tl.Actul);
            var userStreak = await GetLongestStreak(UserId!);
            var analysis = new AnalysisViewModel
            {
                TotalTasks = totalTasks,
                TotalTimeLoggedInHours = totalTimeLogged / 60.0,
                TotalWorkSpaces = totalWorkSpaces,
                UserCurrentStreak = userStreak.current,
                UserLongestStreak = userStreak.longest,
            };
            return analysis;
        }

        public async Task<StreakResult> GetLongestStreak(string userId)
        {
            var dates = await _timeLogService.GetDistinctDatesByUserIdAsync(userId);

            int longest = 0;
            int current = 1;

            for (int i = 1; i < dates.Count; i++)
            {
                if (dates[i] == dates[i - 1].AddDays(1))
                {
                    current++;
                }
                else
                {
                    longest = Math.Max(longest, current);
                    current = 1;
                }
            }

            return new StreakResult(Math.Max(longest, current), current);
        }

    }


    
}