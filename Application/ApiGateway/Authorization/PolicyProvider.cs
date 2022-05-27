using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace ApiGateway.Authorization
{
    public class PolicyProvider : IAuthorizationPolicyProvider
    {
        private readonly DefaultAuthorizationPolicyProvider _fallback;
        private readonly IConfiguration _configuration;
        private readonly AuthorizationOptions _options;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PolicyProvider(
            IOptions<AuthorizationOptions> options,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {

            _options = options.Value;
            _fallback = new DefaultAuthorizationPolicyProvider(options);
            _configuration = configuration;
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
              => _fallback.GetDefaultPolicyAsync();

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
            => Task.FromResult<AuthorizationPolicy>(null);

        public async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            var policy = _options.GetPolicy(policyName);
            var issuer = _configuration["IdentityServer:Host"];

            policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                 .AddRequirements(new OwnerRequirement("Owner", issuer))
                 .Build();

            _options.AddPolicy(policyName, policy);

            return policy;

        }
    }
}
