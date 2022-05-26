using Common.Models;
using Microsoft.EntityFrameworkCore;
using PostgresAPI.Context;
using PostgresAPI.Models;

namespace PostgresAPI.Repository
{
    public interface IUserRepository
    {
        public Task<Response> Register(RegisterUserDTO registerUserDTO);
        public Task<User> GetUserById(int userId);
        public Task<User> GetUserByEmail(string email);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DbApplicationContext _applicationContext;
        public UserRepository (DbApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<User> GetUserByEmail(string email)
        {
           return await _applicationContext.
                Users.Where(u => u.Email == email)
                .FirstOrDefaultAsync(); 
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _applicationContext.Users.FindAsync(userId);
        }

        public async Task<Response> Register(RegisterUserDTO registerUserDTO)
        {
            User user = new User()
            {
                Email = registerUserDTO.Email,
                PhoneNumber = registerUserDTO.Phone,
                Name = registerUserDTO.Name,
                LastName = registerUserDTO.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password)
            };

            Role role = new Role()
            {
                RoleType = Common.Enums.RoleType.Customer
            };

            user.Role = role;

            await _applicationContext.Users.AddAsync(user);
            await _applicationContext.SaveChangesAsync();

            return new Response()
            {
                Message = "Succesfully created user",
                Status = "Succes"
            };

        }
    }
}
