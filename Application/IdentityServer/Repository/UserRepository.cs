using IdentityServer.Context;
using Microsoft.EntityFrameworkCore;
using PostgresAPI.Models;

namespace IdentityServer.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int userÍd);
        Task<User> GetUserByUsername(string userName);
        Task<Role> GetUserRole(int userId);
    }
    public class UserRepository : IUserRepository
    {
        private readonly DbApplicationContext _applicationContext;
        public UserRepository(DbApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _applicationContext.
                Users.
                Include(u => u.Role).
                Where(u => u.Id == userId).
                FirstOrDefaultAsync();
        }
        public async Task<User> GetUserByUsername(string userName)
        {
            return await _applicationContext.
                Users.
                Where(u => u.Name == userName).
                FirstOrDefaultAsync();
        }
        public async Task<Role> GetUserRole(int userId)
        {
            var user = await _applicationContext.
                Users.
                Include(u => u.Role).
                Where(u => u.Id == userId).
                FirstOrDefaultAsync();

            return user.Role;
        }
    }
}
