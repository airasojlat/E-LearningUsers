using Microsoft.AspNetCore.Mvc;

namespace superheroapi.Services.UserServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User?> Login([FromBody] LoginModel loginInfo);
        Task<List<User>> Signup(User user);
        Task<List<User>?> UpdateUser(int id, User request);
        Task<List<User>?> DeleteUser(int id);
    }
}
