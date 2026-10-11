using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_WepApi.Models
{
    [Index ((nameof(Email)) , IsUnique = true)]
    public class Teacher
    {
        public int Id { get; set; }

        [Required ,MaxLength(100)]
        [MinLength(3)]
        public string FullName { get; set; }
        [Required , EmailAddress]
        public string Email { get; set; } 

        [Required,Phone]
        public string Phone { get; set; } 

        [Required]

        public DateTime HireDate { get; set; }


        public ICollection<Course> Courses { get; set; } = new List<Course> ();


    }
}
