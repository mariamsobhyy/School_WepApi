using System.ComponentModel.DataAnnotations;

namespace School_WepApi.DTOs
{
    public class TeacherDTO
    {


        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public DateTime HireDate { get; set; }

    }

    public class ReadTeacherDto
    {

        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime HireDate { get; set; }

    }
}
