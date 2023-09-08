using superheroapi.Services.CoursesServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace superheroapi.Controllers
{
    [Route("api/[controller]")]
[ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            var result = _courseService.GetAllCourses();
            return await result;
        }
        [HttpPost("AddCourse")]
        public async Task<ActionResult<List<Course>>> AddCourse(Course course)
        {
            
            var result = await _courseService.AddCourse(course);
            return result;
        }
    }
}
