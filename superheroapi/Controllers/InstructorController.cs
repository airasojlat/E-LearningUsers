using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using superheroapi.Services.CoursesServices;
using superheroapi.Services.InstructorsServices;
using System.Reflection.Metadata.Ecma335;

namespace superheroapi.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class InstructorController : ControllerBase
    {
        private readonly IinstructorService _instructorService;

        public InstructorController(IinstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Instructor>>> GetAllInstructors()
        {
            var result = _instructorService.GetAllInstructors();
            return await result;
        }
        [HttpPost("AddInstructor")]
        public async Task<ActionResult<List<Instructor>>> AddInstructor(Instructor instructor)
        {

            var result = await _instructorService.AddInstructor(instructor);
            return result;
        }
    }
}
