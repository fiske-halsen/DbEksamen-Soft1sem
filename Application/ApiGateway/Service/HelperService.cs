using ApiGateway.Models;

namespace ApiGateway.Service
{
    public class HelperService
    {
        #region enums
        public enum ClientType
        {
            PostgresClient,
            MongoClient,
            Neo4jClient
        }
        #endregion

        private readonly IConfiguration _configuration;

        public HelperService(IConfiguration configuration)
        {
            _configuration = configuration;   
        }
        /// <summary>
        /// Gets the correct client credentials for identity server
        /// </summary>
        /// <param name="clientType"></param>
        /// <returns></returns>
        public ApplicationCredentials GetMicroserviceClientCredentials(ClientType clientType)
        {
            string clientId = null;
            string clientSecret = null;
            string scope = null;

            switch (clientType)
            {
                case ClientType.PostgresClient :
                    clientId = _configuration["PostgresAPI:ClientId"];
                    clientSecret = _configuration["PostgresAPI:Key"];
                    scope = _configuration["PostgresAPI:Scope"];
                    break;

                case ClientType.MongoClient :
                    clientId = _configuration["MongoDBAPI:ClientId"];
                    clientSecret = _configuration["MongoDBAPI:Key"];
                    scope = _configuration["MongoDBAPI:Scope"];
                    break;

                case ClientType.Neo4jClient :
                    clientId = _configuration["Neo4jAPI:ClientId"];
                    clientSecret = _configuration["Neo4jAPI:Key"];
                    scope = _configuration["Neo4jAPI:Scope"];
                    break;

                default:
                    break;
            }

            return new ApplicationCredentials() { ClientId = clientId, ClientSecret = clientSecret, Scope = scope};
        }

    }
}
