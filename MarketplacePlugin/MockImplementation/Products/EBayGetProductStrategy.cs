using MarketplacePlugin.Interfaces.Strategy;
using MarketplacePlugin.MockImplementation.Services;
using MarketplacePlugin.Models;

namespace MarketplacePlugin.MockImplementation.Products
{

    /// <summary>
    /// Strategy for retrieving an eBay product by its EAN.
    /// </summary>
    public class EBayGetProductByEANStrategy : IGetItemStrategy<Product, string>
    {
        private readonly EBayAPIService _marketplaceAPIService;
        public EBayGetProductByEANStrategy(EBayAPIService marketplaceAPIService)
        {
            _marketplaceAPIService = marketplaceAPIService;
        }

        public string Name => throw new NotImplementedException();

        /// <summary>
        /// Executes the strategy asynchronously to retrieve a product from eBay by EAN.
        /// </summary>
        /// <param name="ean">The European Article Number (EAN) of the product.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the retrieved <see cref="IntegrationItem"/>.
        /// </returns>
        public async Task<IntegrationResult<Product>> ExecuteAsync(string ean, CancellationToken cancellationToken = default)
        {
            // Mock implementation: In a real scenario, you would call eBay's API to get the product by ID.
            var product = await _marketplaceAPIService.GetProductByIdAsync(ean, cancellationToken);
            return new IntegrationResult<Product> { Success = true, IntegrationItems = new List<Product> { product } };
        }
    }
}
