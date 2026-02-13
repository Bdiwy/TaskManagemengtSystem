using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Srvices.Interfaces
{
    public interface IAnalysisService
    {
        Task<AnalysisViewModel?> GetAnalysisAsync();
        Task<StreakResult> GetLongestStreak(string userId);
    }

    public record StreakResult(int current, int longest);
}
