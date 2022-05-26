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
            new ApiScope("PostgresAPI", "Postgres API"),
            new ApiScope("MongoDBAPI", "MongoDB API"),
            new ApiScope("Neo4jAPI", "Neo4j API"),
            new ApiScope("GatewayServiceAPI", "GatewayService API"),
        };

        public static IEnumerable<Client> Clients(IConfiguration configuration)
        {
            var PostgresAPI = configuration["PostgresAPI:Key"];
            var MongoDBAPI = configuration["MongoDBAPI:Key"];
            var Neo4jAPI = configuration["Neo4jAPI:Key"];
            var apiGateWayKey = configuration["ApiGateWayClient:Key"];

            return new List<Client>
            {
                // ---------------------------- CLIENTS FOR MICROSERVICES ---------------------------------- 
                new Client
                {
                    ClientId = "Postgres",
                    AccessTokenType = AccessTokenType.Jwt,
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // scopes that client has access to
                    AllowedScopes = { "PostgresAPI"},

                    // secret for authentication
                    ClientSecrets = { new Secret(PostgresAPI.Sha256())},

                    // To test it via POSTMAN,
                    AllowAccessTokensViaBrowser = true,
                },
                  new Client
                {
                    ClientId = "MongoDB",
                    AccessTokenType = AccessTokenType.Jwt,
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // scopes that client has access to
                    AllowedScopes = { "MongoDBAPI"},

                    // secret for authentication
                    ClientSecrets = { new Secret(MongoDBAPI.Sha256())},

                    // To test it via POSTMAN,
                    AllowAccessTokensViaBrowser = true,
                },

                    new Client
                {
                    ClientId = "Neo4j",
                    AccessTokenType = AccessTokenType.Jwt,
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // scopes that client has access to
                    AllowedScopes = { "Neo4jAPI"},

                    // secret for authentication
                    ClientSecrets = { new Secret(Neo4jAPI.Sha256())},

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
            var PostgresAPI = configuration["PostgresAPI:Key"];
            var MongoDBAPI = configuration["MongoDBAPI:Key"];
            var Neo4jAPI = configuration["Neo4jAPI:Key"];
            var apiGateWayKey = configuration["ApiGateWayClient:Key"];

            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "PostgresAPI",
                    Description = "PostgresAPI resource",
                    ApiSecrets = { new Secret(PostgresAPI.Sha256()) },
                    Scopes =  { "PostgresAPI", }
                },

                new ApiResource
                {
                    Name = "MongoDBAPI",
                    Description = "MongoDBAPI resource",
                    ApiSecrets = { new Secret(MongoDBAPI.Sha256()) },
                    Scopes =  { "MongoDBAPI", }
                },

                new ApiResource
                {
                    Name = "Neo4jAPI",
                    Description = "Neo4jAPI resource",
                    ApiSecrets = { new Secret(Neo4jAPI.Sha256()) },
                    Scopes =  { "Neo4jAPI", }
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
