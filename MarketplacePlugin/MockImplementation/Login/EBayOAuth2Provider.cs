using MarketplacePlugin.Interfaces.Login.OAuth2;
using MarketplacePlugin.Models.Login;

namespace MarketplacePlugin.MockImplementation.Login
{
    public class EBayOAuth2Provider : IOAuth2Provider
    {
        private HttpClient _httpClient;
        private readonly OAuth2ProviderConfig _config;

        public EBayOAuth2Provider(HttpClient httpClient, OAuth2ProviderConfig config)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public string Name => "eBay";

        public OAuth2ProviderConfig Config { get; }

        public HttpClient HttpClient { get; }

        public Task<AuthResult> AuthenticateAsync()
        {
            return RefreshTokenAsync();
        }

        private static AuthResult ParseTokenResponse(string json)
        {
            var doc = System.Text.Json.JsonDocument.Parse(json);

            return new AuthResult
            {
                AccessToken = doc.RootElement.GetProperty("access_token").GetString()!,
                RefreshToken = doc.RootElement.TryGetProperty("refresh_token", out var r)
                    ? r.GetString() ?? ""
                    : "",
                Expiration = DateTime.UtcNow.AddSeconds(
                    doc.RootElement.TryGetProperty("expires_in", out var e) ? e.GetInt32() : 3600)
            };
        }

        public async Task<AuthResult> ExchangeCodeAsync(string authorizationCode)
        {
            var body = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {"grant_type", "authorization_code"},
            {"code", authorizationCode},
            {"redirect_uri", _config.RedirectUri},
            {"client_id", _config.ClientId},
            {"client_secret", _config.ClientSecret}
        });

            var response = await _httpClient.PostAsync(_config.TokenEndpoint, body);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return ParseTokenResponse(json);
        }

        public string GetAuthorizationUrl(string state)
        {
            var scope = string.Join(" ", _config.Scopes);
            return $"{_config.AuthorizationEndpoint}?client_id={Uri.EscapeDataString(_config.ClientId)}" +
                   $"&response_type=code" +
                   $"&redirect_uri={Uri.EscapeDataString(_config.RedirectUri)}" +
                   $"&scope={Uri.EscapeDataString(scope)}" +
                   $"&state={Uri.EscapeDataString(state)}";
        }

        public async Task<AuthResult> RefreshTokenAsync()
        {
            var body = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {"grant_type", "refresh_token"},
            {"refresh_token", _config.RefreshToken},
            {"client_id", _config.ClientId},
            {"client_secret", _config.ClientSecret}
        });

            var response = await _httpClient.PostAsync(_config.RefreshTokenEndpoint, body);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return ParseTokenResponse(json);
        }
    }
}
