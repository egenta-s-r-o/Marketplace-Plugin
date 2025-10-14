using MarketplacePlugin.Infrastructure;
using MarketplacePlugin.Models.OrderManagementAPI;

namespace MarketplacePlugin.MockImplementation.OrderManagement
{
    public class EbayOrderManagement : OrderManagementClientBase
    {
        /// <summary>
        /// Custom implementation of OrderManagementClientBase for eBay marketplace.
        /// </summary>
        /// <param name="client"></param>
        public EbayOrderManagement(HttpClient client) : base(client)
        {
        }
    }
}
