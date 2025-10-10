using MarketplacePlugin.Interfaces.Strategy;
using MarketplacePlugin.MockImplementation.Services;
using MarketplacePlugin.Models;

namespace MarketplacePlugin.MockImplementation.Products
{
    public class EBaySyncProductsStrategy : ISyncItemsStrategy<Product, List<Product>>
    {
        private readonly EBayAPIService _marketplaceAPIService;
        public EBaySyncProductsStrategy(EBayAPIService marketplaceAPIService)
        {
            _marketplaceAPIService = marketplaceAPIService;
        }
        public string Name => "eBay Get Customer Strategy";

        public async Task<IntegrationResult<Product>> ExecuteAsync(List<Product> items, CancellationToken cancellationToken = default)
        {
            await _marketplaceAPIService.SyncProductsAsync(items, cancellationToken);
            return new IntegrationResult<Product>
            {
                Success = true,
                IntegrationItems = new List<Product>(items)
            };
        }
    }
}
