using MarketplacePlugin.Models.OrderManagementAPI;

namespace MarketplacePlugin.Interfaces
{
    public interface IOrderManagement
    {
        Task<HttpResponseMessage> ImportOrdersAsync(OrderImportRequest request);
        Task<(HttpResponseMessage, ShippedOrderResponse?)> GetShippedOrdersAsync(string secretId, string secretKey);
        Task<HttpResponseMessage> UpdateOrderShippedAsync(OrderUpdateRequest request);
        Task<(HttpResponseMessage, OrdersToCheckResponse?)> GetOrdersToCheckStatusAsync(string secretId, string secretKey);
        Task<HttpResponseMessage> UpdateOrderStatusAsync(OrderStatusUpdateRequest request);
    }
}
