namespace superheroapi.Services.CoursesServices
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses();
        Task<List<Course>> AddCourse(Course course);
    }
}
