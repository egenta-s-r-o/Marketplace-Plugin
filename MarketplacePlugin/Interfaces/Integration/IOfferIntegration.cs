using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces.Integration
{
    /// <summary>
    /// Defines CRUD operations for offer integration with a marketplace.
    /// </summary>
    public interface IOfferIntegration
    {
        /// <summary>
        /// Creates a new offer in the marketplace.
        /// </summary>
        /// <param name="offer">The offer to create.</param>
        /// <returns>A <see cref="Result"/> indicating the outcome.</returns>
        Task<Result> Create(Offer offer);

        /// <summary>
        /// Reads offer details from the marketplace.
        /// </summary>
        /// <param name="offer">The offer to read.</param>
        /// <returns>A <see cref="Result"/> containing offer data.</returns>
        Task<Result> Read(Offer offer);

        /// <summary>
        /// Updates an existing offer in the marketplace.
        /// </summary>
        /// <param name="offer">The offer to update.</param>
        /// <returns>A <see cref="Result"/> indicating the outcome.</returns>
        Task<Result> Update(Offer offer);

        /// <summary>
        /// Deletes an offer from the marketplace.
        /// </summary>
        /// <param name="offer">The offer to delete.</param>
        /// <returns>A <see cref="Result"/> indicating the outcome.</returns>
        Task<Result> Delete(Offer offer);
    }
}