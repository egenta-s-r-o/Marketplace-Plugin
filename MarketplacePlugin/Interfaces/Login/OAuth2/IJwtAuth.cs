namespace MarketplacePlugin.Interfaces.Login.OAuth2
{
    // JWT
    public interface IJwtAuth : IMarketplaceAuth
    {
        string ClientId { get; }
        string ClientSecret { get; }
    }

}
