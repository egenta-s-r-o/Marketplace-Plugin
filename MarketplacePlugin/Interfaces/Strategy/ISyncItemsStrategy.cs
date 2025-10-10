using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces.Strategy
{
    public interface ISyncItemsStrategy<TResult, TEntity> : IMarketplaceStrategy<TResult, TEntity> where TResult : IntegrationItem
    {
    }
}