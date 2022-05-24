using IdentityServer.Repository;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Diagnostics;
using System.Security.Claims;

namespace IdentityServer.IdentityConfig
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _authRepository;
        public ProfileService(IUserRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var subject = context.Subject.Claims.ToList().Find(s => s.Type == "sub").Value;
                var userId = Int32.Parse(subject);

                var user = await _authRepository.GetUserById(userId);
                var role = await _authRepository.GetUserRole(userId);
            
                if (subject == null)
                {
                    return;
                }
                var claims = new List<Claim>
                {
                new Claim("Role", role.RoleType),
                new Claim("Email", user.Email),
                };

                context.IssuedClaims = claims;
            }
            catch (Exception e)
            {
                return;
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(0);
        }
    }
}
