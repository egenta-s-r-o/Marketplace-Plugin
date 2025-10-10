using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces.Strategy
{
    /// <summary>
    /// Defines a strategy for searching for <see cref="IntegrationItem"/> objects in the marketplace.
    /// </summary>
    public interface ISearchItemStrategy<TResult, TEntity> : IMarketplaceStrategy<TResult, TEntity> where TResult : IntegrationItem
    {
    }
}