using System.ComponentModel.DataAnnotations;

namespace School_WepApi.DTOs
{
    public class StudentDTO
    {
        [Required, MaxLength(100)]
        [MinLength(3)]
        public string FullName { get; set; }


        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]

        public string Gender { get; set; }
    }

    public class ReadStudentDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }
    }
}
