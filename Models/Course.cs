using System.ComponentModel.DataAnnotations;

namespace School_WepApi.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required , MaxLength(100)]
        [MinLength(3)]
        public string Title { get; set; }

        [Required , Range(1 , 6)]
        public int CreditHours { get; set; }

        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
