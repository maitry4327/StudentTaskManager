using System.ComponentModel.DataAnnotations;

namespace StudentTaskManager.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the assignment title.")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the subject.")]
        [StringLength(100)]
        public string Subject { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please select the due date.")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.Today;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}