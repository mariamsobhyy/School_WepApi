using AutoMapper;
using School_WepApi.DTOs;
using School_WepApi.Models;
namespace School_WepApi.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
                // Department
                CreateMap<Department, DepartmentDTO>().ReverseMap();

                CreateMap<CreateDepartmentDTO, Department>().ReverseMap();

                CreateMap<UpdateDepartmentDTO, Department>().ReverseMap();

                // Teacher
                CreateMap<Teacher, TeacherDTO>()
                    .ForMember(
                        dest => dest.FullName,
                        opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)
                    )
                    .ForMember(
                        dest => dest.DepartmentName,
                        opt => opt.MapFrom(src => src.Department.Name)
                    )
                    .ReverseMap();

                CreateMap<CreateTeacherDTO, Teacher>() .ReverseMap();

                CreateMap<UpdateTeacherDTO, Teacher>().ReverseMap();

                // ClassRoom
                CreateMap<ClassRoom, ClassroomDTO>().ReverseMap();

                CreateMap<CreateClassRoomsDTO, ClassRoom>().ReverseMap();

                CreateMap<UpdateClassRoomsDTO, ClassRoom>() .ReverseMap();

                // Student
                CreateMap<Student, StudentDTO>()
                    .ForMember(
                        x => x.FullName,
                        opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)
                    )
                    .ForMember(
                        x => x.ClassRoomName,
                        opt => opt.MapFrom(src => src.ClassRoom.Name)
                    )
                    .ReverseMap();

                CreateMap<CreateStudentDTO, Student>() .ReverseMap();

                CreateMap<UpdateStudentDTO, Student>()  .ReverseMap();

                // Subject
                CreateMap<Subject, SubjectDTO>()
                    .ForMember(
                        x => x.TeacherName,
                        opt => opt.MapFrom(
                            src => src.Teacher.FirstName + " " + src.Teacher.LastName
                        )
                    )
                    .ReverseMap();

                CreateMap<CreateSubjectDTO, Subject>()
                    .ReverseMap();

                CreateMap<UpdateSubjectDTO, Subject>()
                    .ReverseMap();

                // Enrollment
                CreateMap<Enrollment, EnrollmentDTO>()
                    .ForMember(
                        x => x.StudentFullName,
                        opt => opt.MapFrom(
                            src => src.Student.FirstName + " " + src.Student.LastName
                        )
                    )
                    .ForMember(
                        x => x.SubjectName,
                        opt => opt.MapFrom(src => src.Subject.Name)
                    )
                    .ReverseMap();

                CreateMap<CreateEnrollmentDTO, Enrollment>() .ReverseMap();

                CreateMap<UpdateEnrollmentDTO, Enrollment>().ReverseMap();
           
        }
    }
}