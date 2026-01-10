using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskManagmentSystem.Models
{
    public class TimeLog
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
        [ForeignKey("UserTask")]
        public int TaskId { get; set; }
        public UserTask Task { get; set; } = null!;
    }
}
