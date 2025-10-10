using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces.Strategy
{
    /// <summary>
    /// Defines a strategy for updating an <see cref="IntegrationItem"/> in the marketplace.
    /// </summary>
    public interface IUpdateItemStrategy<TResult, TEntity> : IMarketplaceStrategy<TResult, TEntity> where TResult : IntegrationItem
    {
    }
}