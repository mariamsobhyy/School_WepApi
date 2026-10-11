using School_WepApi.DTOs;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface IReportRepo
    {
        Task<IEnumerable<CourseStaticsDto>> GetCourseStatisticsAsync();

        Task<IEnumerable<AverageGradeDto>> GetAverageGradesAsync();

        Task<IEnumerable<TopStudentDto>> GetTopStudentsAsync();
    }
}
