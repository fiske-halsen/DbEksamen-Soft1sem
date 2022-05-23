using IdentityServer.Repository;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace IdentityServer.IdentityConfig
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserRepository _authRepository;

        public ResourceOwnerPasswordValidator(IUserRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var userName = context.UserName;
            var password = context.Password;
            var user = _authRepository.GetUserByUsername(userName).Result;

            // Need to figure out with bcrypt when doing register
            // bool isEqual = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (user != null && user.Password.Equals(password))
            {
                context.Result = new GrantValidationResult(subject: user.Id.ToString(), authenticationMethod: "password");
                return Task.FromResult(context.Result);
            }

            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Wrong username or password");
            return Task.FromResult(context.Result);
        }
    }
}
