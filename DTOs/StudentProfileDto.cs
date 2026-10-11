using System.ComponentModel.DataAnnotations;

namespace School_WepApi.DTOs
{
    public class StudentProfileDto
    {

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string ParentPhone { get; set; }

        [Required]
        [Phone]
        public string EmergencyContact { get; set; }

        public int StudentId { get; set; }
    }


    public class ReadStudentProfileDto
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string ParentPhone { get; set; }

        public string EmergencyContact { get; set; }

        public string StudentName { get; set; }
    }
}
