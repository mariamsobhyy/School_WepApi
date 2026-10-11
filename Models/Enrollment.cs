using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_WepApi.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
      
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        public Course Course { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Range(0, 100)]
        public decimal? Grade { get; set; }
    }
}
