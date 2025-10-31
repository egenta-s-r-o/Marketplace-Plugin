namespace MarketplacePlugin.Interfaces.Login
{
    // API key in header
    public interface IApiKeyHeaderAuth : IMarketplaceAuth
    {
        string ApiKeyName { get; }
        string ApiKeyValue { get; }
    }

}
