using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces.Strategy
{
    /// <summary>
    /// Defines a strategy for deleting an <see cref="IntegrationItem"/> from the marketplace.
    /// </summary>
    public interface IDeleteItemStrategy<TResult, TEntity> : IMarketplaceStrategy<TResult, TEntity> where TResult : IntegrationItem
    {
    }
}