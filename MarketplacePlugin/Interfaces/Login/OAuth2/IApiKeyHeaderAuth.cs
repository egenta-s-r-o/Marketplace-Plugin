namespace MarketplacePlugin.Interfaces.Login.OAuth2
{
    // API key in header
    public interface IApiKeyHeaderAuth : IMarketplaceAuth
    {
        string ApiKeyName { get; }
        string ApiKeyValue { get; }
    }

}
