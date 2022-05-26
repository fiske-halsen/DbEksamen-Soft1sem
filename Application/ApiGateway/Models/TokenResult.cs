using IdentityModel.Client;

namespace ApiGateway.Models
{
    public class TokenResult
    {
        public bool Succeeded { get; set; }
        public TokenResponse Token { get; set; }
        public string Error { get; set; }
    }
}
