using MarketplacePlugin.Interfaces.Integration;
using MarketplacePlugin.Models;
using MarketplacePlugin.Models.Exception;

namespace MarketplacePlugin.Mock
{
    public class Testing
    {
        public async Task Test(List<Product> products)
        {
            // Example usage:
            HttpClient httpClient = new HttpClient();
            EBayOAuth2Provider auth = new EBayOAuth2Provider(httpClient, new Interfaces.Login.OAuth2.OAuth2ProviderConfig(null, null, null, null, null, null, null, null));
            var authResult = await auth.AuthenticateAsync();

            //handle create products
            IIntegration productIntegration = null; // Replace with actual implementation

            //subscribe to events
            productIntegration.OnIntegrationItemCreated += (s, e) =>
            {
            };

            EBayMarket eBayMarket = new EBayMarket(auth, productIntegration, null);
            foreach (var product in products)
            {
                var createProductResult = await eBayMarket.ProductIntegration.Create(product);
            }
        }
    }

    public class eBayProductIntegration : IIntegration
    {
        public event EventHandler<IntegrationItem> OnIntegrationItemCreated;
        public event EventHandler<IntegrationException> OnIntegrationItemCreateError;
        public event EventHandler<IntegrationException> OnIntegrationItemDeleteError;
        public event EventHandler<IntegrationException> OnIntegrationItemReadError;
        public event EventHandler<IntegrationException> OnIntegrationItemSyncError;
        public event EventHandler<IntegrationException> OnIntegrationItemUpdateError;

        public Task<IntegrationResult> Create(IntegrationItem IntegrationItem)
        {
            throw new NotImplementedException();
        }

        public Task<IntegrationResult> Delete(IntegrationItem IntegrationItem)
        {
            throw new NotImplementedException();
        }

        public Task<IntegrationResult> Read(IntegrationItem IntegrationItem)
        {
            throw new NotImplementedException();
        }

        public Task<IntegrationResult> SyncIntegrationItems(IEnumerable<IntegrationItem> IntegrationItems, bool IsStockUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<IntegrationResult> Update(IntegrationItem IntegrationItem)
        {
            throw new NotImplementedException();
        }
    }
}
