using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces.Strategy
{
    /// <summary>
    /// Defines a strategy for retrieving all <see cref="IntegrationItem"/> objects from the marketplace.
    /// </summary>
    public interface IGetAllItemsStrategy<TResult, TEntity> : IMarketplaceStrategy<TResult, TEntity> where TResult : IntegrationItem
    {
    }
}