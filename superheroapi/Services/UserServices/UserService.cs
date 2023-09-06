using Microsoft.AspNetCore.Mvc;

namespace superheroapi.Services.UserServices
{
    public class UserService : IUserService
    {
        private static List<User> Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Saria",
                    LastName = "Taljo",
                    EmailAddress = "sariataljo0@gmail.com",
                    Password = "123456789",
                    Country = "Türkiye",
                    BirthDay = new DateTime(2005,05,23),
                    PhoneNumber = "05510088380",
                    UserName = "airas"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Nourallah",
                    LastName = "Nahhas",
                    EmailAddress = "nournahhas@gmail.com",
                    Password = "bddakyah.nourallah",
                    Country = "Türkiye",
                    BirthDay = new DateTime(2005,05,23),
                    PhoneNumber = "05510749692",
                    UserName = "abualnur"
                }
            };
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Users;
        }

        public async Task<List<User>?> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Users;
        }

        public async  Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> login([FromBody] LoginModel loginInfo)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.EmailAddress == loginInfo.EmailAddress && x.Password == loginInfo.Password);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public async Task<List<User>>? UpdateUser(int id, User request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.EmailAddress = request.EmailAddress;
            user.Password = request.Password;
            user.UserName = request.UserName;

            await _context.SaveChangesAsync();
            return Users;
            
        }
    }
}
