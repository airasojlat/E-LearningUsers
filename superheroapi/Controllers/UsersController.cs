using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<ActionResult<User>> Login([FromBody] LoginModel loginInfo)
        {
            if (loginInfo.EmailAddress is null)
            {
                return BadRequest("EmailAddress is empty");
            }
            if (loginInfo.Password is null)
            {
                return BadRequest("Password is empty");
            }
            var result = await _userService.Login(loginInfo);
            if (result is null)
            {
                return NotFound("User not found.");
            }
            return result;
        }
        [HttpPost("signup")]
        public async Task<ActionResult<List<User>>> Signup(User user)
        {
            var error = SignupValidation(user);
            if (error is not null)
            {
                return BadRequest(string.Join(", \n" , error));
            }
            var result = await _userService.Signup(user);
            return result;
        }
        private List<string> SignupValidation(User user)
        {
            
            var validationList = new List<string>();
            if (string.IsNullOrEmpty(user.EmailAddress))
            {
                validationList.Add("Email Address is not filled");   
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                validationList.Add("Password is not filled");
            }
            if (string.IsNullOrEmpty(user.UserName))
            {
                validationList.Add("UserName is not filled");
            }
            if (string.IsNullOrEmpty(user.FirstName))
            {
                validationList.Add("FirstName is not filled");
            }
            if (string.IsNullOrEmpty(user.LastName))
            {
                validationList.Add("LastName is not filled");
            }
            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                validationList.Add("PhoneNumber is not filled");
            }
            if (string.IsNullOrEmpty(user.Country))
            {
                validationList.Add("Country is not filled");
            }
            if (user.BirthDay < DateTime.Now.AddYears(- 120) )
            {
                validationList.Add("You are too old");
            }
            if (user.BirthDay > DateTime.Now.AddYears(- 10))
            {
                validationList.Add("You are too young");
            }
            if (validationList.Count != 0)
            {
                return validationList;
            }
            else
            {
                return null;
            }
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
