namespace MarketplacePlugin.Interfaces.Login.OAuth2
{
    public class OAuth2ProviderConfig
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorizationEndpoint { get; set; }
        public string TokenEndpoint { get; set; }
        public string RedirectUri { get; set; }
        public List<string> Scopes { get; set; }
        public string RefreshTokenEndpoint { get; set; }
        public string RefreshToken { get; set; }
        public OAuth2ProviderConfig(string clientId, string clientSecret, string authorizationEndpoint, string tokenEndpoint, string redirectUri, List<string> scopes, string refreshTokenEndpoint, string refreshToken)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            AuthorizationEndpoint = authorizationEndpoint;
            TokenEndpoint = tokenEndpoint;
            RedirectUri = redirectUri;
            Scopes = scopes;
            RefreshTokenEndpoint = refreshTokenEndpoint;
            RefreshToken = refreshToken;
        }
    }
}
