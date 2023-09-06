using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using superheroapi.Models;
using superheroapi.Services.UserServices;

namespace superheroapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var result = _userService.GetAllUsers();
            return await result;
        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> login([FromBody] LoginModel loginInfo)
        {
            if (loginInfo.EmailAddress is null)
            {
                return BadRequest("EmailAddress is empty");
            }
            var result = await _userService.login(loginInfo);
            if (result is null)
            {
                return NotFound("User not found.");
            }
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            var result = await _userService.AddUser(user);
            return result;
        }
        [HttpPut("id")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User request)
        {
            var result = await _userService.UpdateUser(id, request);
            if (result is null)
            {
                return NotFound("User not found.");
            }
            return result;
        }
        [HttpDelete("id")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (result is null)
            {
                return NotFound("User not found.");
            }
            return result;
        }
    }
}
