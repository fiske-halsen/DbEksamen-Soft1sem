namespace ApiGateway.Models
{
    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
