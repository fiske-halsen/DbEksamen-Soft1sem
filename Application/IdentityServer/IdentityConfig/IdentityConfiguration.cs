using IdentityServer4.Models;

namespace IdentityServer.IdentityConfig
{
    public static class IdentityConfiguration
    {
        #region classVariables
        #endregion

        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("RestaurantServiceAPI", "RestaurantService API"),
            new ApiScope("MenuServiceAPI", "MenuService API"),
            new ApiScope("CustomerHistoryServiceAPI", "CustomerHistory API"),
            new ApiScope("GatewayServiceAPI", "GatewayService API"),
        };

        public static IEnumerable<Client> Clients(IConfiguration configuration)
        {
            var restaurantServiceKey = configuration["RestaurantService:Key"];
            var menuServiceAPIKey = configuration["MenuService:Key"];
            var customerHistoryServiceKey = configuration["CustomerHistoryService:Key"];
            var apiGateWayKey = configuration["ApiGateWayClient:Key"];

            return new List<Client>
            {
                // ---------------------------- CLIENTS FOR MICROSERVICES ---------------------------------- 
                new Client
                {
                    ClientId = "RestaurantService",
                    AccessTokenType = AccessTokenType.Jwt,
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // scopes that client has access to
                    AllowedScopes = { "RestaurantServiceAPI"},

                    // secret for authentication
                    ClientSecrets = { new Secret(restaurantServiceKey.Sha256())},

                    // To test it via POSTMAN,
                    AllowAccessTokensViaBrowser = true,
                },
                  new Client
                {
                    ClientId = "MenuService",
                    AccessTokenType = AccessTokenType.Jwt,
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // scopes that client has access to
                    AllowedScopes = { "MenuServiceAPI"},

                    // secret for authentication
                    ClientSecrets = { new Secret(menuServiceAPIKey.Sha256())},

                    // To test it via POSTMAN,
                    AllowAccessTokensViaBrowser = true,
                },

                    new Client
                {
                    ClientId = "CustomerHistoryService",
                    AccessTokenType = AccessTokenType.Jwt,
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // scopes that client has access to
                    AllowedScopes = { "CustomerHistoryServiceAPI"},

                    // secret for authentication
                    ClientSecrets = { new Secret(customerHistoryServiceKey.Sha256())},

                    // To test it via POSTMAN,
                    AllowAccessTokensViaBrowser = true,
                },
            // --------------------------------- CLIENT FOR HANDLING PASSWORDS ------------------------------------
                new Client
                {
                    ClientId = "ApiGateWayClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret(apiGateWayKey.Sha256())
                    },
                    AllowedScopes = { "GatewayServiceAPI" }
                }
            };
        }
        public static IEnumerable<ApiResource> ApiResources(IConfiguration configuration)
        {
            var restaurantServiceKey = configuration["RestaurantService:Key"];
            var menuServiceAPIKey = configuration["MenuService:Key"];
            var customerHistoryServiceKey = configuration["CustomerHistoryService:Key"];
            var apiGateWayKey = configuration["ApiGateWayClient:Key"];

            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "RestaurantServiceAPI",
                    Description = "RestaurantServiceAPI resource",
                    ApiSecrets = { new Secret(restaurantServiceKey.Sha256()) },
                    Scopes =  { "RestaurantServiceAPI", }
                },

                new ApiResource
                {
                    Name = "MenuServiceAPI",
                    Description = "MenuServiceAPI resource",
                    ApiSecrets = { new Secret(menuServiceAPIKey.Sha256()) },
                    Scopes =  { "MenuServiceAPI", }
                },

                new ApiResource
                {
                    Name = "CustomerHistoryServiceAPI",
                    Description = "CustomerHistoryServiceAPI resource",
                    ApiSecrets = { new Secret(customerHistoryServiceKey.Sha256()) },
                    Scopes =  { "CustomerHistoryServiceAPI", }
                },

                   new ApiResource
                {
                    Name = "GatewayServiceAPI",
                    Description = "GatewayService resource",
                    ApiSecrets = { new Secret(apiGateWayKey.Sha256()) },
                    Scopes =  { "GatewayServiceAPI", }
                }
            };
        }
    }
}
