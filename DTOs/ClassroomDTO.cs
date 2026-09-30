using System.ComponentModel.DataAnnotations;

namespace School_WepApi.DTOs
{
    public class ClassroomDTO
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, Range(1, 100)]
        public int Capacity { get; set; }
        [Required, Range(1, 12)]
        public int GradeLevel { get; set; }
    }
    public class CreateClassRoomsDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, Range(1, 100)]
        public int Capacity { get; set; }
        [Required, Range(1, 12)]
        public int GradeLevel { get; set; }
    }
    public class UpdateClassRoomsDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, Range(1, 100)]
        public int Capacity { get; set; }
        [Required, Range(1, 12)]
        public int GradeLevel { get; set; }
    }
}

