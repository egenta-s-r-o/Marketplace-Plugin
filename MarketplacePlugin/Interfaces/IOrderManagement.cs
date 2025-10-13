using MarketplacePlugin.Models.OrderManagementAPI;

namespace MarketplacePlugin.Interfaces
{
    public interface IOrderManagement
    {
        Task<HttpResponseMessage> ImportOrdersAsync(OrderImportRequest request);
        Task<HttpResponseMessage> GetShippedOrdersAsync(string secretId, string secretKey);
        Task<HttpResponseMessage> UpdateOrderShippedAsync(OrderUpdateRequest request);
        Task<HttpResponseMessage> GetOrdersToCheckStatusAsync(string secretId, string secretKey);
        Task<HttpResponseMessage> UpdateOrderStatusAsync(OrderStatusUpdateRequest request);
    }
}
