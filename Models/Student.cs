using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_WepApi.Models
{
    [Index(nameof(Email),IsUnique =true)]
    public class Student
    {
        public int Id { get; set; }

        [Required , MaxLength(100)]
        [MinLength(3)]
        public string FullName { get; set; }


        [ Required,EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required , Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]

        public string Gender { get; set; }  

        public StudentProfile? StudentProfile { get; set; }


        public ICollection<Enrollment> enrollments { get; set; } = new List<Enrollment>();
        
    }
}
