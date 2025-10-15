using MarketplacePlugin.Interfaces.Strategy;
using MarketplacePlugin.MockImplementation.Services;
using MarketplacePlugin.Models;

namespace MarketplacePlugin.MockImplementation.Orders
{
    public class EBayGetOrderByIdStrategy : IGetItemStrategy<Order, string>
    {
        private readonly EBayAPIService _marketplaceAPIService;
        public EBayGetOrderByIdStrategy(EBayAPIService marketplaceAPIService)
        {
            _marketplaceAPIService = marketplaceAPIService;
        }
        public string Name => "eBay Get Order By Id Strategy";

        public async Task<IntegrationResult<Order>> ExecuteAsync(string entity, CancellationToken cancellationToken = default)
        {
            var order = await _marketplaceAPIService.GetOrderByIdAsync(entity, cancellationToken).ConfigureAwait(false);
            return new IntegrationResult<Order> { Success = true, IntegrationItems = new List<Order> { order } };
        }
    }
}
