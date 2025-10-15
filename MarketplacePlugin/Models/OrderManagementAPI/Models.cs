using System.Text.Json.Serialization;

namespace MarketplacePlugin.Models.OrderManagementAPI
{
    #region Order Requests
    /// <summary>
    /// Wrapper for Order Import request
    /// </summary>
    public class OrderImportRequest
    {
        /// <summary>App credentials</summary>
        [JsonPropertyName("secret_id")]
        public string SecretId { get; set; }

        /// <summary>App credentials</summary>
        [JsonPropertyName("secret_key")]
        public string SecretKey { get; set; }

        /// <summary>List of orders to import</summary>
        [JsonPropertyName("orders")]
        public List<OrderManagementOrder> Orders { get; set; }
    }

    /// <summary>
    /// Request to mark order as shipped
    /// </summary>
    public class OrderUpdateRequest
    {
        [JsonPropertyName("secret_id")]
        public string SecretId { get; set; }

        [JsonPropertyName("secret_key")]
        public string SecretKey { get; set; }

        [JsonPropertyName("OrderID")]
        public string OrderId { get; set; }

        /// <summary>
        /// Status can be only 1 and is set by default. DO NOT CHANGE!
        /// </summary>
        [JsonPropertyName("updated")]
        public int Updated { get; set; } = 1;
    }

    /// <summary>
    /// Request to update order status
    /// </summary>
    public class OrderStatusUpdateRequest
    {
        [JsonPropertyName("secret_id")]
        public string SecretId { get; set; }

        [JsonPropertyName("secret_key")]
        public string SecretKey { get; set; }

        [JsonPropertyName("OrderID")]
        public string OrderId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("OrderStatusTranslated")]
        public OrderStatus OrderStatusTranslated { get; set; }
    }

    /// <summary>
    /// Order status enumeration for status updates
    /// </summary>
    public enum OrderStatus
    {
        Shipped,
        Unshipped,
        Canceled
    }

    #endregion
    #region Order Responses
    /// <summary>
    /// Response wrapper for shipped orders list
    /// </summary>
    public class ShippedOrderResponse
    {
        [JsonPropertyName("orders")]
        public List<ShippedOrder> Orders { get; set; }
    }

    /// <summary>
    /// Response wrapper for orders to check status
    /// </summary>
    public class OrdersToCheckResponse
    {
        [JsonPropertyName("orders")]
        public List<ShippedOrderId> Orders { get; set; }
    }

    public class ShippedOrderId
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }
    }

    public class ShippedOrder : ShippedOrderId
    {
        [JsonPropertyName("carrierName")]
        public string CarrierName { get; set; }
        [JsonPropertyName("parcelNumber")]
        public string ParcelNumber { get; set; }
    }

    #endregion

    #region Order Management Models
    /// <summary>
    /// Represents an order in the OMS system
    /// </summary>
    public class OrderManagementOrder
    {
        /// <summary>Marketplace order ID</summary>
        [JsonPropertyName("OrderId")]
        public string OrderId { get; set; }

        /// <summary>Current order status at the marketplace</summary>
        [JsonPropertyName("Status")]
        public string Status { get; set; }

        /// <summary>Optional secondary reference ID</summary>
        [JsonPropertyName("Reference")]
        public string Reference { get; set; }

        [JsonPropertyName("StoreId")]
        public string StoreId { get; set; }

        [JsonPropertyName("StoreName")]
        public string StoreName { get; set; }

        [JsonPropertyName("PurchaseDate")]
        public DateTime PurchaseDate { get; set; }

        [JsonPropertyName("LastUpdateDate")]
        public DateTime LastUpdateDate { get; set; }

        [JsonPropertyName("EarliestShipDate")]
        public DateTime? EarliestShipDate { get; set; }

        [JsonPropertyName("LatestShipDate")]
        public DateTime LatestShipDate { get; set; }

        [JsonPropertyName("EarliestDeliveryDate")]
        public DateTime? EarliestDeliveryDate { get; set; }

        [JsonPropertyName("LatestDeliveryDate")]
        public DateTime? LatestDeliveryDate { get; set; }

        [JsonPropertyName("SalesChannelId")]
        public string SalesChannelId { get; set; }

        [JsonPropertyName("SalesChannel")]
        public string SalesChannel { get; set; }

        [JsonPropertyName("BusinessOrder")]
        public bool BusinessOrder { get; set; }

        [JsonPropertyName("BuyerName")]
        public string BuyerName { get; set; }

        [JsonPropertyName("BuyerEmail")]
        public string BuyerEmail { get; set; }

        [JsonPropertyName("OrderTotal")]
        public decimal OrderTotal { get; set; }

        [JsonPropertyName("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("NumberOfItemsUnshipped")]
        public int NumberOfItemsUnshipped { get; set; }

        [JsonPropertyName("requested_shipping_carrier")]
        public string RequestedShippingCarrier { get; set; }

        [JsonPropertyName("shippingAddress")]
        public OrderManagementAddress ShippingAddress { get; set; }

        [JsonPropertyName("billingAddress")]
        public OrderManagementAddress BillingAddress { get; set; }

        [JsonPropertyName("lines")]
        public List<OrderManagementOrderLine> Lines { get; set; }
    }

    /// <summary>
    /// Represents a shipping or billing address
    /// </summary>
    public class OrderManagementAddress
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonPropertyName("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonPropertyName("addressLine3")]
        public string AddressLine3 { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("stateOrRegion")]
        public string StateOrRegion { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }
    }

    /// <summary>
    /// Represents a single order line item
    /// </summary>
    public class OrderManagementOrderLine
    {
        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("sellerProductId")]
        public string SellerProductId { get; set; }

        [JsonPropertyName("orderLineId")]
        public string OrderLineId { get; set; }

        [JsonPropertyName("productTitle")]
        public string ProductTitle { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("sellingPrice")]
        public decimal SellingPrice { get; set; }

        [JsonPropertyName("sellingPriceCurrencyCode")]
        public string SellingPriceCurrencyCode { get; set; }

        [JsonPropertyName("shippingCost")]
        public decimal ShippingCost { get; set; }

        [JsonPropertyName("shippingCostCurrencyCode")]
        public string ShippingCostCurrencyCode { get; set; }

        [JsonPropertyName("commission_amountWithVat")]
        public decimal? CommissionAmountWithVat { get; set; }

        [JsonPropertyName("commission_amountWithoutVat")]
        public decimal? CommissionAmountWithoutVat { get; set; }
    }
    #endregion
}
