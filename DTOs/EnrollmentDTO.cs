using System.ComponentModel.DataAnnotations;

namespace School_WepApi.DTOs
{
    public class EnrollmentDTO
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Range(0, 100)]
        public double? Grade { get; set; }


    }


    public class ReadEnrollmentDto
    {

        public int Id { get; set; }

        public string StudentName { get; set; }

        public string CourseTitle { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public double? Grade { get; set; }
    }
}

