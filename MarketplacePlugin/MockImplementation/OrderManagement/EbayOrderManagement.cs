using MarketplacePlugin.Infrastructure;
using MarketplacePlugin.Models.OrderManagementAPI;

namespace MarketplacePlugin.MockImplementation.OrderManagement
{
    public class EbayOrderManagement : OrderManagementClientBase
    {
        public EbayOrderManagement(HttpClient client) : base(client)
        {
        }

        public async Task ImportOrdersAsync(string secretId, string secretKey, List<OrderManagementOrder> orders)
        {
            var request = new OrderImportRequest
            {
                SecretId = secretId,
                SecretKey = secretKey,
                Orders = orders
            };
            var response = await ImportOrdersAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                // Handle error
                throw new Exception($"Failed to import orders: {response.RequestMessage}");
            }
        }
    }
}
