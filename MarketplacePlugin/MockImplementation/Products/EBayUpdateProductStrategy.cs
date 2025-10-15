using MarketplacePlugin.Interfaces.Strategy;
using MarketplacePlugin.MockImplementation.Services;
using MarketplacePlugin.Models;

namespace MarketplacePlugin.MockImplementation.Products
{
    public class EBayUpdateProductStrategy : IUpdateItemStrategy<Product, Product>
    {
        private readonly EBayAPIService _marketplaceAPIService;
        public EBayUpdateProductStrategy(EBayAPIService marketplaceAPIService)
        {
            _marketplaceAPIService = marketplaceAPIService;
        }

        public string Name => throw new NotImplementedException();

        public async Task<IntegrationResult<Product>> ExecuteAsync(Product item, CancellationToken cancellationToken = default)
        {
            await _marketplaceAPIService.UpdateProductAsync(item, cancellationToken).ConfigureAwait(false);
            return new IntegrationResult<Product> { Success = true, IntegrationItems = new List<Product> { item } };
        }
    }
}
