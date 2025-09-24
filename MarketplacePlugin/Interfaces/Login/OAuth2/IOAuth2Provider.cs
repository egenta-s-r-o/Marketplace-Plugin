using MarketplacePlugin.Models.Login.OAuth2;

namespace MarketplacePlugin.Interfaces.Login.OAuth2
{

    public interface IOAuth2Provider : ILoginProvider
    {
        string Name { get; }

        /// <summary>
        /// Build the URL where the user must be redirected to grant access.
        /// </summary>
        string GetAuthorizationUrl(string state);

        /// <summary>
        /// Exchange the authorization code for the first token set.
        /// </summary>
        Task<OAuth2Token> ExchangeCodeAsync(string authorizationCode);

        /// <summary>
        /// Refresh the access token.
        /// </summary>
        Task<OAuth2Token> RefreshTokenAsync(string refreshToken);
    }

}
