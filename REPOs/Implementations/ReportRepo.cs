using Microsoft.EntityFrameworkCore;
using School_WepApi.Data;
using School_WepApi.DTOs;
using School_WepApi.REPOs.Intarfaces;

namespace School_WepApi.REPOs.Implementations
{
    public class ReportRepo : IReportRepo
    {

        private readonly AppDbContext _context;

        public ReportRepo (AppDbContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<AverageGradeDto>> GetAverageGradesAsync()
        {
            return await _context.courses
                .Select(c => new AverageGradeDto
                {
                    CourseTitle = c.Title,

                    AverageGrade = c.Enrollments
                        .Where(e => e.Grade.HasValue)
                        .Average(e => e.Grade) ?? 0
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseStaticsDto>> GetCourseStatisticsAsync()
        {
            return await _context.courses.Select(c => new CourseStaticsDto
            {
                TeacherName = c.Teacher.FullName,

                CourseTitle = c.Title,

                StudentCount = c.Enrollments.Count()
            })
                .ToListAsync();
               
                
        }

        public async Task<IEnumerable<TopStudentDto>> GetTopStudentsAsync()
        {
            return await _context.students.Select(s => new TopStudentDto
            {
                StudentName = s.FullName,

                AverageGrade = s.enrollments
                .Where(g => g.Grade.HasValue)
                .Average(g => g.Grade) ?? 0

            }).OrderByDescending(g => g.AverageGrade)
            .Take(10)
            .ToListAsync();
                
        }
    }
}
