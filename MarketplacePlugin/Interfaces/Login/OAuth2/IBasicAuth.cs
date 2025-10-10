namespace MarketplacePlugin.Interfaces.Login.OAuth2
{
    // Basic username/password
    public interface IBasicAuth : IMarketplaceAuth
    {
        string Username { get; }
        string Password { get; }
    }

}
