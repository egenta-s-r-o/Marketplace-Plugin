namespace MarketplacePlugin.Models.Login
{
    public class AuthResult
    {
        public string AccessToken { get; set; } // for OAuth2/JWT
        public string RefreshToken { get; set; } // for OAuth2
        public string TokenType { get; set; }   // optional
        public DateTime? Expiration { get; set; }
        public IDictionary<string, string>? Headers { get; set; } // for API keys or custom headers
    }
}
