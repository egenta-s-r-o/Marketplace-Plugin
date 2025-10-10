using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces.Strategy
{
    /// <summary>
    /// Strategy interface for retrieving a single <see cref="IntegrationItem"/> from the marketplace.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity used to retrieve the item.</typeparam>
    public interface IGetItemStrategy<TResult, TEntity> : IMarketplaceStrategy<TResult, TEntity> where TResult : IntegrationItem
    {
    }
}