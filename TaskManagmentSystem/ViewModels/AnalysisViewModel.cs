using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.ViewModels
{
    public class AnalysisViewModel
    {
        
        public int? TotalTasks { get; set; }
        public double? TotalTimeLoggedInHours { get; set; }
        public int? TotalWorkSpaces { get; set; }
        public int? UserCurrentStreak { get; set; }
        public int? UserLongestStreak { get; set; }
        }
}
