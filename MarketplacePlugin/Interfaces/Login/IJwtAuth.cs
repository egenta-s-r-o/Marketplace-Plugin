namespace MarketplacePlugin.Interfaces.Login
{
    // JWT
    public interface IJwtAuth : IMarketplaceAuth
    {
        string ClientId { get; }
        string ClientSecret { get; }
    }

}
