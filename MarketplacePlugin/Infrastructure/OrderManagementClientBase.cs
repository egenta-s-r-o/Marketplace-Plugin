using MarketplacePlugin.Interfaces;
using MarketplacePlugin.Models.OrderManagementAPI;
using System.Net.Http.Json;

namespace MarketplacePlugin.Infrastructure
{
    /// <summary>
    /// HttpClient wrapper for OrderManagement API
    /// </summary>
    public abstract class OrderManagementClientBase : IOrderManagement
    {
        private readonly HttpClient _client;

        public OrderManagementClientBase(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Import orders into OMS
        /// </summary>
        public async Task<HttpResponseMessage> ImportOrdersAsync(OrderImportRequest request)
        {
            return await _client.PutAsJsonAsync("https://oms.egenta.eu/api/order_import.php", request);
        }

        /// <summary>
        /// Get list of shipped orders from OMS
        /// </summary>
        public async Task<HttpResponseMessage> GetShippedOrdersAsync(string secretId, string secretKey)
        {
            var uri = $"https://oms.egenta.eu/api/order_update_get_list.php?secret_id={secretId}&secret_key={secretKey}";
            return await _client.GetAsync(uri);
        }

        /// <summary>
        /// Update an order as shipped
        /// </summary>
        public async Task<HttpResponseMessage> UpdateOrderShippedAsync(OrderUpdateRequest request)
        {
            return await _client.PostAsJsonAsync("https://oms.egenta.eu/api/order_update_update.php", request);
        }

        /// <summary>
        /// Get list of orders to check status
        /// </summary>
        public async Task<HttpResponseMessage> GetOrdersToCheckStatusAsync(string secretId, string secretKey)
        {
            var uri = $"https://oms.egenta.eu/api/order_status_get_list.php?secret_id={secretId}&secret_key={secretKey}";
            return await _client.GetAsync(uri);
        }

        /// <summary>
        /// Update an order status
        /// </summary>
        public async Task<HttpResponseMessage> UpdateOrderStatusAsync(OrderStatusUpdateRequest request)
        {
            return await _client.PostAsJsonAsync("https://oms.egenta.eu/api/order_status_update.php", request);
        }
    }
}
