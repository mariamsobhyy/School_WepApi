using System.ComponentModel.DataAnnotations;

namespace School_WepApi.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }

        [Required , MaxLength(200)]
        public string Address { get; set; }

        [Required, Phone]
        public string ParentPhone { get; set; }
        [Required, Phone]

        public string EmergencyContact { get; set; }

        public Student? student { get; set; }

        public int  studentId { get; set; }

    }
}
