using MarketplacePlugin.Models;
using MarketplacePlugin.Models.Exception;

namespace MarketplacePlugin.Interfaces.Integration
{
    /// <summary>
    /// Defines CRUD operations and synchronization for offer integration with a marketplace.
    /// </summary>
    public interface IOfferIntegration
    {
        /// <summary>
        /// Creates a new offer in the marketplace.
        /// </summary>
        /// <param name="offer">The offer to create.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating whether the creation was successful, including any relevant messages or attributes.
        /// </returns>
        Task<Result> Create(Offer offer);

        event EventHandler<Offer> OnOfferCreated;

        /// <summary>
        /// Reads offer details from the marketplace.
        /// </summary>
        /// <param name="offer">The offer to read.</param>
        /// <returns>
        /// A <see cref="Result"/> containing the offer data if found, along with success status and any additional information.
        /// </returns>
        Task<Result> Read(Offer offer);

        /// <summary>
        /// Updates an existing offer in the marketplace.
        /// </summary>
        /// <param name="offer">The offer to update.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating whether the update was successful, including any relevant messages or attributes.
        /// </returns>
        Task<Result> Update(Offer offer);

        /// <summary>
        /// Deletes an offer from the marketplace.
        /// </summary>
        /// <param name="offer">The offer to delete.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating whether the deletion was successful, including any relevant messages or attributes.
        /// </returns>
        Task<Result> Delete(Offer offer);

        /// <summary>
        /// Synchronizes a collection of offers with the marketplace.
        /// </summary>
        /// <param name="offers">The collection of offers to synchronize.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating the outcome of the synchronization, including any relevant messages or attributes.
        /// </returns>
        Task<Result> SyncOffers(IEnumerable<Offer> offers);

        /// <summary>
        /// Occurs when an error happens during offer creation in the marketplace.
        /// </summary>
        event EventHandler<IntegrationException> OnOfferCreateError;
        /// <summary>
        /// Occurs when an error happens during offer reading from the marketplace.
        /// </summary>
        event EventHandler<IntegrationException> OnOfferReadError;
        /// <summary>
        /// Occurs when an error happens during offer update in the marketplace.
        /// </summary>
        event EventHandler<IntegrationException> OnOfferUpdateError;
        /// <summary>
        /// Occurs when an error happens during offer deletion from the marketplace.
        /// </summary>
        event EventHandler<IntegrationException> OnOfferDeleteError;
        /// <summary>
        /// Occurs when an error happens during offer synchronization with the marketplace.
        /// </summary>
        event EventHandler<IntegrationException> OnOfferSyncError;

    }
}