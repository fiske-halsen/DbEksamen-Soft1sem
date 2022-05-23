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

                Debug.WriteLine("sssss " + subject);

                var user = await _authRepository.GetUserById(1);
                
                if (subject == null)
                {
                    return;
                }
                var claims = new List<Claim>
                {
                new Claim("Role", user.Role.RoleType.ToString()),
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
