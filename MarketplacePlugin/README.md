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
```
public class EBayMarket : Market
{
    public override string MarketplaceName => "eBay";
    public EBayMarket(IMarketplaceAuth auth, IIntegration productIntegration, IIntegration offerIntegration)
        : base(auth, productIntegration, offerIntegration)
    {
    }
}
```

2. Implement IMarketplaceAuth that is needed for specific marketplace, for example eBay => implement IOAuth2Provider
3. Implement IIntegration for products
4. Implement IIntegration for offers

### Product creation use-case example
```
public async Task Test(List<Product> products)
{
    // Example usage:
    HttpClient httpClient = new HttpClient();
    EBayOAuth2Provider auth = new EBayOAuth2Provider(httpClient, new Interfaces.Login.OAuth2.OAuth2ProviderConfig(null, null, null, null, null, null, null, null));
    var authResult = await auth.AuthenticateAsync();

    //handle create products
    IIntegration productIntegration = new ProductIntegration(); // Replace with actual implementation of IIntegration for products

    //subscribe to events
    productIntegration.OnIntegrationItemCreated += (s, e) =>
    {
    };

    EBayMarket eBayMarket = new EBayMarket(auth, productIntegration, null);
    foreach (var product in products)
    {
        var createProductResult = await eBayMarket.ProductIntegration.Create(product);
    }
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
dotnet nuget add source "https://nuget.pkg.github.com/ZdenekMrazek/index.json" --username YOUR_GITHUB_USERNAME --password YOUR_PAT --store-password-in-clear-text --name github
```
## 3. Install the NuGet package

### Option A: Using CLI
```
dotnet add package MarketplacePlugin --version 1.0.2
```
### Option B: Editing .csproj
Add this inside your .csproj file:

```
<ItemGroup>
  <PackageReference Include="MarketplacePlugin" Version="1.0.2" />
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

@2024 Copyright Zdenek Mrazek