using Microsoft.AspNetCore.Authorization;

namespace ApiGateway.Authorization
{
    public class OwnerRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Role { get; }
        public OwnerRequirement(string 
            role, string issuer)
        {
            Role = role;
            Issuer = issuer;
        }

        public class HasOwnerRequirementHandler : AuthorizationHandler<OwnerRequirement>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public HasOwnerRequirementHandler(IHttpContextAccessor httpContextAccessor)
            {
                this._httpContextAccessor = httpContextAccessor;
            }
            /// <summary>Check if the access token has the required scopes depending on the policy that gets created </summary>
            /// <param name="context">The authorization context for a given user </param>
            /// <param name="requirement">The ZoneRequirement that gets defined when a policy is created </param>
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerRequirement requirement)
            {
                if (!context.User.HasClaim(c => c.Type == "RoleId" && c.Issuer == requirement.Issuer))
                    return Task.CompletedTask;

                var role = context.User.FindAll(c => c.Type == "RoleId" && c.Issuer == requirement.Issuer).ToList()[0].Value;

                if (role.Equals("2")) // 2 for owner....
                {
                    context.Succeed(requirement);
                }

                return Task.CompletedTask;
            }

        }

    }
}
