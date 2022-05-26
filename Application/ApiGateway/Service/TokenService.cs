using ApiGateway.Models;
using IdentityModel.Client;

namespace ApiGateway.Service
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        private readonly string _identityServerUrl;
        private readonly HelperService _helperService;

        public TokenService(IConfiguration configuration, HelperService helperService)
        {
            _configuration = configuration;
            _identityServerUrl = _configuration["IdentityServer:Host"];
            _helperService = helperService;
        }

        public async Task<TokenResult> RequestTokenClientApplication(string clientId, string clientSecret, string scope)
        {
            using HttpClient client = new HttpClient();

            DiscoveryDocumentResponse disco = await client.GetDiscoveryDocumentAsync(_identityServerUrl);

            if (disco.IsError)
            {
                return new TokenResult { Succeeded = false, Error = disco.Error };
            }

            TokenResponse token = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = clientId,
                ClientSecret = clientSecret,
                Scope = scope
            });

            return new TokenResult { Succeeded = !token.IsError, Token = token };
        }

        public async Task<TokenResult> RequestTokenForUser(string userName, string password)
        {

            using HttpClient client = new HttpClient();

            DiscoveryDocumentResponse disco = await client.GetDiscoveryDocumentAsync(_identityServerUrl);

            if (disco.IsError)
            {
                return new TokenResult { Succeeded = false, Error = disco.Error };
            }
            else
            {
                var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "ApiGateWayClient",
                    ClientSecret = _configuration["ApiGateWayClient:Key"],
                    UserName = userName,
                    Password = password,
                    Scope = "GatewayServiceAPI",
                });

                return new TokenResult { Succeeded = !tokenResponse.IsError, Token = tokenResponse };
            }
        }
    }
}
