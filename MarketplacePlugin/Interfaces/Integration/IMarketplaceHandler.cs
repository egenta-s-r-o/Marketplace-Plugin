using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces.Integration
{
    /// <summary>
    /// Defines methods for synchronizing products and offers with a marketplace.
    /// </summary>
    public interface IMarketplaceHandler
    {
        /// <summary>
        /// Synchronizes a collection of products with the marketplace.
        /// </summary>
        /// <param name="products">The products to synchronize.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating the success or failure of the operation.
        /// </returns>
        Task<Result> SyncProductsAsync(IEnumerable<Product> products);

        /// <summary>
        /// Synchronizes a collection of offers with the marketplace.
        /// </summary>
        /// <param name="offers">The offers to synchronize.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating the success or failure of the operation.
        /// </returns>
        Task<Result> SyncOffersAsync(IEnumerable<Offer> offers);
    }
}
