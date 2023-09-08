using superheroapi.Models;

namespace superheroapi.Services.CoursesServices
{
    public class CourseService : ICourseService
    {
        private readonly DataContext _context;

        public CourseService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> AddCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return await _context.Courses.ToListAsync();
        }

        public async Task<List<Course>> GetAllCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses;
        }
    }
}
