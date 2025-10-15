using MarketplacePlugin.Interfaces.Strategy;
using MarketplacePlugin.MockImplementation.Services;
using MarketplacePlugin.Models;

namespace MarketplacePlugin.MockImplementation.Customers
{
    public class EBayGetCustomerByIdStrategy : IGetItemStrategy<Customer, string>
    {
        private readonly EBayAPIService _marketplaceAPIService;
        public EBayGetCustomerByIdStrategy(EBayAPIService marketplaceAPIService)
        {
            _marketplaceAPIService = marketplaceAPIService;
        }
        public string Name => "eBay Get Customer Strategy";

        public async Task<IntegrationResult<Customer>> ExecuteAsync(string customerId, CancellationToken cancellationToken = default)
        {
            var customer = await _marketplaceAPIService.GetCustomerByIdAsync(customerId, cancellationToken).ConfigureAwait(false);
            return new IntegrationResult<Customer> { Success = true, IntegrationItems = new List<Customer> { customer } };
        }
    }
}
