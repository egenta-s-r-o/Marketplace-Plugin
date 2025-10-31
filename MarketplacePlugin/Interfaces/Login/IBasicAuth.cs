namespace MarketplacePlugin.Interfaces.Login
{
    // Basic username/password
    public interface IBasicAuth : IMarketplaceAuth
    {
        string Username { get; }
        string Password { get; }
    }

}
