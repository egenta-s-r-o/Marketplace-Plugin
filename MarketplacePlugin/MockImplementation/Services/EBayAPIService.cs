using MarketplacePlugin.Interfaces;
using MarketplacePlugin.Models;

namespace MarketplacePlugin.MockImplementation.Services
{
    public class EBayAPIService : IMarketplaceAPIService
    {
        // Mock implementation of eBay API service methods
        public async Task<Product> GetProductByIdAsync(string productId, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(new Product() { EAN = productId });
        }

        public async Task<Product> UpdateProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(product);
        }
        public async Task<List<Product>> SyncProductsAsync(List<Product> products, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(products);
        }
        public async Task<Customer> GetCustomerByIdAsync(string customerId, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(new Customer() { Id = customerId });
        }
        public async Task<Order> GetOrderByIdAsync(string orderId, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(new Order() { Id = orderId });
        }
    }
}
