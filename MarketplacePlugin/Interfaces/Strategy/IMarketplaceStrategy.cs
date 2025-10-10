using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces.Strategy
{
    /// <summary>
    /// Defines a strategy interface for executing marketplace operations.
    /// It is the base interface for all marketplace strategies. Use derived interfaces for specific operations.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the strategy execution.</typeparam>
    /// <typeparam name="TEntity">The type of the entity to process.</typeparam>
    public interface IMarketplaceStrategy<TResult, TEntity> where TResult : IntegrationItem
    {
        /// <summary>
        /// Gets the name of the marketplace strategy.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Executes the strategy asynchronously for the specified entity.
        /// </summary>
        /// <param name="entity">The entity to be processed by the strategy.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the result of the strategy execution.
        /// </returns>
        Task<IntegrationResult<TResult>> ExecuteAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
