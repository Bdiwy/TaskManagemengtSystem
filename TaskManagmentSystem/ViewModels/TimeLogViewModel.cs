using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.ModelsView
{
    public class TimeLogViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Actul { get; set; }
        [Required]
        [Range(0,100)]
        public int Progress { get; set; }
        [Required]
        public int Allocat { get; set; }

        [Required]
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public TaskList Task { get; set; } = null!;


    }
}
