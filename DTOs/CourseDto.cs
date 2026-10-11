using System.ComponentModel.DataAnnotations;

namespace School_WepApi.DTOs
{
    public class CourseDto
    {

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Range(1, 6)]
        public int CreditHours { get; set; }

        public int TeacherId { get; set; }
    }

    public class ReadCourseDto
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public int CreditHours { get; set; }

        public string TeacherName { get; set; }
    }
}
