using MarketplacePlugin.Infrastructure;
using MarketplacePlugin.Interfaces.Strategy;
using MarketplacePlugin.MockImplementation.Customers;
using MarketplacePlugin.MockImplementation.Login;
using MarketplacePlugin.MockImplementation.OrderManagement;
using MarketplacePlugin.MockImplementation.Orders;
using MarketplacePlugin.MockImplementation.Products;
using MarketplacePlugin.MockImplementation.Services;
using MarketplacePlugin.Models;
using MarketplacePlugin.Models.OrderManagementAPI;

namespace MarketplacePlugin.MockImplementation
{
    public class Testing
    {
        public async Task Test()
        {
            // Example usage:
            HttpClient httpClient = new HttpClient();
            EBayOAuth2Provider auth = new EBayOAuth2Provider(httpClient, new Interfaces.Login.OAuth2.OAuth2ProviderConfig(null, null, null, null, null, null, null, null));
            var authResult = await auth.AuthenticateAsync();

            //initialize market
            EBayMarket eBayMarket = new EBayMarket(auth);
            EBayAPIService marketplaceAPIService = new EBayAPIService();

            //for simplicity, we create strategies here. In a real-world scenario, consider using a DI container.
            IMarketplaceStrategy<Product, string> getItemStrategy = new EBayGetProductByEANStrategy(marketplaceAPIService);
            IMarketplaceStrategy<Product, Product> updateStrategy = new EBayUpdateProductStrategy(marketplaceAPIService);
            IMarketplaceStrategy<Product, List<Product>> syncStrategy = new EBaySyncProductsStrategy(marketplaceAPIService);
            IMarketplaceStrategy<Customer, string> getCustomerStrategy = new EBayGetCustomerByIdStrategy(marketplaceAPIService);
            IMarketplaceStrategy<Order, string> getOrderStrategy = new EBayGetOrderByIdStrategy(marketplaceAPIService);

            //get order example
            string orderID = "exampleOrderID";
            var integrationResultOrder = await eBayMarket.ExecuteAsync(getOrderStrategy, orderID);
            var order = integrationResultOrder.IntegrationItems?.FirstOrDefault();
            //handle order as needed
            if (order != null)
            {
                // Process the order
            }

            //handling products
            List<Product> products = new List<Product>
            {
                new Product { EAN = "1234567890123", SKU = "SKU001" },
                new Product { EAN = "2345678901234", SKU = "SKU002" }
            };
            foreach (var product in products)
            {
                var integrationResult = await eBayMarket.ExecuteAsync(getItemStrategy, product.EAN);
                var existingItem = integrationResult.IntegrationItems?.FirstOrDefault();
                if (!string.IsNullOrEmpty(existingItem?.SKU))
                {
                    //item exists, update it                                        
                    var updateProductResult = await eBayMarket.ExecuteAsync(updateStrategy, product);
                    if (!updateProductResult.Success)
                    {
                        //handle error
                        var message = updateProductResult.Message;
                    }
                }
            }

            //synchronize products
            await eBayMarket.ExecuteAsync(syncStrategy, products);


            //handling customers            
            string customerID = "exampleCustomerID";
            var integrationResultCustomer = await eBayMarket.ExecuteAsync(getCustomerStrategy, customerID);
            var customer = integrationResultCustomer.IntegrationItems?.FirstOrDefault();

            //example of OrderManagement
            EbayOrderManagement orderManagement = new EbayOrderManagement(new HttpClient());
            await orderManagement.UpdateOrderStatusAsync(new OrderStatusUpdateRequest()
            {
                OrderId = "exampleOrderID",
                SecretId = "exampleSecretId",
                SecretKey = "exampleSecretKey",
                OrderStatusTranslated = OrderStatus.Unshipped
            });
        }
    }
}
