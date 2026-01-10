using System.ComponentModel.DataAnnotations;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.ViewModels
{
    public class TimeLogViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Actual time is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Actual time must be greater than 0")]
        public int Actul { get; set; }
        
        [Required(ErrorMessage = "Progress is required")]
        [Range(0, 100, ErrorMessage = "Progress must be between 0 and 100")]
        public int Progress { get; set; }
        
        [Required(ErrorMessage = "Allocated time is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Allocated time must be greater than 0")]
        public int Allocat { get; set; }

        [Required(ErrorMessage = "Please select a task")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid task")]
        public int TaskId { get; set; }

        public string? TaskTitle { get; set; }

        public UserTask? Task { get; set; }
    }
}
