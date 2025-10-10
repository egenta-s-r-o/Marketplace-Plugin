using MarketplacePlugin.Interfaces.Strategy;
using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces
{
    public class MarketplaceContext
    {
        private object? _marketplaceStrategy;

        public void SetMarketplaceStrategy(object strategy)
            => _marketplaceStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));

        public async Task<IntegrationResult<TResult>> ExecuteAsync<TResult, TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TResult : IntegrationItem
        {
            if (_marketplaceStrategy is IMarketplaceStrategy<TResult, TEntity> typed)
            {
                return await typed.ExecuteAsync(entity, cancellationToken);
            }

            throw new InvalidOperationException(
                $"The current strategy does not support result type {typeof(TResult).Name}.");
        }
    }
}
