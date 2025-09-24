namespace MarketplacePlugin.Models.Login.OAuth2
{
    /// <summary>
    /// Represents an OAuth2 token set, including access and refresh tokens and expiration.
    /// </summary>
    public class OAuth2Token
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; } = "";

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        public string RefreshToken { get; set; } = "";

        /// <summary>
        /// Gets or sets the expiration date and time of the access token.
        /// </summary>
        public DateTime ExpiresAt { get; set; }
    }
}