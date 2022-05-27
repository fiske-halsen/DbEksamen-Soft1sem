using Dapper;
using IdentityServer.Context;
using IdentityServer.Models;
using System.Data;

namespace IdentityServer.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int userÍd);
        Task<User> GetUserByUsername(string email);
        Task<Role> GetUserRole(int userId);
        Task<UserEntry> GetUserEntryById(int userId);
        
    }
    public class UserRepository : IUserRepository
    {
        private readonly DbApplicationContext _applicationContext;
        private readonly IDbConnection _connection;
        public UserRepository(DbApplicationContext applicationContext, IDbConnection connection)
        {
            _applicationContext = applicationContext;
            _connection = connection;
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _connection.QueryFirstOrDefaultAsync<User>(
                "SELECT " +
                "u.\"Id\", " +
                "u.\"Name\", " +
                "u.\"Email\", " +
                "u.\"Password\", " +
                "u.\"RoleId\" " +
                " FROM \"Users\" AS u " +
                "WHERE u.\"Id\" = @Id", new { Id = userId });
        }
        public async Task<User> GetUserByUsername(string email)
        {
            return await _connection.QueryFirstOrDefaultAsync<User>(
                "SELECT " +
                "u.\"Id\", " +
                "u.\"Name\", " +
                "u.\"Email\", " +
                "u.\"Password\" " +
                " FROM \"Users\" AS u " +
                "WHERE u.\"Email\" = @Email", new { Email = email });
        }

        public async Task<UserEntry> GetUserEntryById(int userId)
        {
            return await _connection.QueryFirstOrDefaultAsync<UserEntry>(
                "SELECT u.\"Id\", " +
                " u.\"Email\", " +
                "r.\"RoleType\" " +
                "FROM \"Users\" AS u " +
                "INNER JOIN \"Roles\" AS r " +
                "ON u.\"RoleId\" = u.\"Id\"" +
                " WHERE u.\"Id\" = @Id", new { Id = userId });
        }
        
        public async Task<Role> GetUserRole(int userId)
        {
            return await _connection.QueryFirstOrDefaultAsync<Role>(
                "SELECT u.\"Id\", " +
                "r.\"RoleType\" " +
                "FROM \"Users\" AS u " +
                "INNER JOIN \"Roles\" AS r " +
                "ON u.\"RoleId\" = u.\"Id\"" +
                " WHERE u.\"Id\" = @Id", new { Id = userId });
        }


    }
}
