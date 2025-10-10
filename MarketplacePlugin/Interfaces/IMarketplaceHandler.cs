using MarketplacePlugin.Interfaces.Login;

namespace MarketplacePlugin.Interfaces
{
    /// <summary>
    /// Defines a handler for a specific marketplace, providing access to authentication and marketplace identification.
    /// </summary>
    /// <typeparam name="TAuth">
    /// The type of authentication used for the marketplace, which must implement <see cref="IMarketplaceAuth"/>.
    /// </typeparam>
    public interface IMarketplaceHandler<TAuth>
        where TAuth : IMarketplaceAuth
    {
        /// <summary>
        /// Gets the name of the marketplace.
        /// </summary>
        string MarketplaceName { get; }

        /// <summary>
        /// Gets the authentication object for the marketplace.
        /// </summary>
        TAuth Auth { get; }
    }
}
