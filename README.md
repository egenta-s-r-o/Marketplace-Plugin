# MarketplacePlugin

MarketplacePlugin is a .NET 8 library designed to simplify integration with marketplace APIs. It provides a set of extensible interfaces and utilities for building plugins that interact with various e-commerce platforms.

## Features

- Easy-to-use plugin architecture
- Support for multiple marketplaces
- Extensible API integration
- .NET 8 compatible

## This repository use
Use this repository to push your commits after implementation of MarketplacePlugin Package interfaces.

![Marketplace Class Diagram](/MarketplacePlugin/ClassDiagram.png)

### Interface implementation examples

1. Market class
```c#
public class EBayMarket : Market
    {
        public EBayMarket(IMarketplaceAuth auth) : base(auth)
        {
        }
        public override string MarketplaceName => "eBay";
    }
```

2. Implement IMarketplaceAuth that is needed for specific marketplace, for example eBay => implement IOAuth2Provider
3. Create all needed IMarketplaceStrategy implementations (create products, handle customers, handle offers, etc.)
```
//example implementation for retrieving product from eBay
    
/// <summary>
/// Strategy for retrieving an eBay product by its EAN.
/// </summary>
public class EBayGetProductByEANStrategy : IGetItemStrategy<Product, string>
{
    private readonly EBayAPIService _marketplaceAPIService;
    public EBayGetProductByEANStrategy(EBayAPIService marketplaceAPIService)
    {
        _marketplaceAPIService = marketplaceAPIService;
    }

    public string Name => "eBay get product by ean";

    /// <summary>
    /// Executes the strategy asynchronously to retrieve a product from eBay by EAN.
    /// </summary>
    /// <param name="ean">The European Article Number (EAN) of the product.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the retrieved <see cref="IntegrationItem"/>.
    /// </returns>
    public async Task<IntegrationResult<Product>> ExecuteAsync(string ean, CancellationToken cancellationToken = default)
    {
        var product = await _marketplaceAPIService.GetProductByIdAsync(ean, cancellationToken);
        return new IntegrationResult<Product> { Success = true, IntegrationItems = new List<Product> { product } };
    }
}
```

### Use-case example
```
public async Task Test()
{
    HttpClient httpClient = new HttpClient();
    EBayOAuth2Provider auth = new EBayOAuth2Provider(httpClient, new Interfaces.Login.OAuth2.OAuth2ProviderConfig(null, null, null, null, null, null, null, null));
    var authResult = await auth.AuthenticateAsync();

    //initialize market
    EBayMarket eBayMarket = new EBayMarket(auth);
    EBayAPIService marketplaceAPIService = new EBayAPIService(); //create service for calling marketplace API

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
}
```



# Using the MarketplacePlugin NuGet Package

This guide explains how to install and use the `MarketplacePlugin` package hosted on GitHub Packages.

---

## 1. Generate a Personal Access Token (PAT)

1. Go to **GitHub → Settings → Developer settings → Personal access tokens → Tokens (classic)**  
2. Click **Generate new token**  
3. Select only these scopes:
   - `read:packages`
   - `repo` 
4. Copy and save the token securely (you will not see it again).

---

## 2. Add GitHub Packages as a NuGet source

Run the following command in your terminal (PowerShell or CMD):
```
dotnet nuget add source "https://nuget.pkg.github.com/egenta-s-r-o/index.json" --username YOUR_GITHUB_USERNAME --password YOUR_PAT --store-password-in-clear-text --name github
```
## 3. Install the NuGet package

### Option A: Using CLI
```
dotnet add package MarketplacePlugin
```
### Option B: Editing .csproj
Add this inside your .csproj file:

```
<ItemGroup>
  <PackageReference Include="MarketplacePlugin"/>
</ItemGroup>
```

## 4. Verify installation

Build your project. The MarketplacePlugin assembly should now be available in your code:

```
using MarketplacePlugin;

public class Test
{
    public void Run()
    {
        
    }
}
```
