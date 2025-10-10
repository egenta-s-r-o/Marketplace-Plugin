using MarketplacePlugin.Interfaces.Login;
using MarketplacePlugin.Interfaces.Strategy;
using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces
{
    /// <summary>
    /// Represents an abstract base class for a marketplace, providing authentication and context execution capabilities.
    /// </summary>
    public abstract class Market : IMarketplaceHandler<IMarketplaceAuth>
    {
        /// <summary>
        /// Gets the name of the marketplace.
        /// </summary>
        public abstract string MarketplaceName { get; }

        /// <summary>
        /// Gets the authentication object for the marketplace.
        /// </summary>
        public IMarketplaceAuth Auth { get; }

        /// <summary>
        /// Gets the context used for executing marketplace operations.
        /// </summary>
        protected MarketplaceContext MarketplaceContext { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Market"/> class with the specified authentication.
        /// </summary>
        /// <param name="auth">The authentication object for the marketplace.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="auth"/> is <c>null</c>.</exception>
        protected Market(IMarketplaceAuth auth)
        {
            Auth = auth ?? throw new ArgumentNullException(nameof(auth));
            MarketplaceContext = new MarketplaceContext();
        }

        public async Task<IntegrationResult<TResult>> ExecuteAsync<TResult, TEntity>(IMarketplaceStrategy<TResult, TEntity> strategy, TEntity entity, CancellationToken cancellationToken = default) where TResult : IntegrationItem
        {
            MarketplaceContext.SetMarketplaceStrategy(strategy);
            return await MarketplaceContext.ExecuteAsync<TResult, TEntity>(entity, cancellationToken);
        }

    }
}
