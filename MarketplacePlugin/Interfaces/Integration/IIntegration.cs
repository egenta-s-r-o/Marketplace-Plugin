using MarketplacePlugin.Models;
using MarketplacePlugin.Models.Exception;

namespace MarketplacePlugin.Interfaces.Integration
{
    /// <summary>
    /// Defines the contract for integration operations with external systems.
    /// </summary>
    public interface IIntegration
    {
        /// <summary>
        /// Occurs when an integration item is successfully created.
        /// </summary>
        event EventHandler<IntegrationItem> OnIntegrationItemCreated;

        /// <summary>
        /// Occurs when an error happens during the creation of an integration item.
        /// </summary>
        event EventHandler<IntegrationException> OnIntegrationItemCreateError;

        /// <summary>
        /// Occurs when an error happens during the deletion of an integration item.
        /// </summary>
        event EventHandler<IntegrationException> OnIntegrationItemDeleteError;

        /// <summary>
        /// Occurs when an error happens during the reading of an integration item.
        /// </summary>
        event EventHandler<IntegrationException> OnIntegrationItemReadError;

        /// <summary>
        /// Occurs when an error happens during the synchronization of integration items.
        /// </summary>
        event EventHandler<IntegrationException> OnIntegrationItemSyncError;

        /// <summary>
        /// Occurs when an error happens during the update of an integration item.
        /// </summary>
        event EventHandler<IntegrationException> OnIntegrationItemUpdateError;

        /// <summary>
        /// Creates a new integration item in the external system.
        /// </summary>
        /// <param name="IntegrationItem">The integration item to create.</param>
        /// <returns>A <see cref="IntegrationResult"/> indicating the outcome of the operation.</returns>
        Task<IntegrationResult> Create(IntegrationItem IntegrationItem);

        /// <summary>
        /// Deletes an existing integration item from the external system.
        /// </summary>
        /// <param name="IntegrationItem">The integration item to delete.</param>
        /// <returns>A <see cref="IntegrationResult"/> indicating the outcome of the operation.</returns>
        Task<IntegrationResult> Delete(IntegrationItem IntegrationItem);

        /// <summary>
        /// Reads an integration item from the external system.
        /// </summary>
        /// <param name="IntegrationItem">The integration item to read.</param>
        /// <returns>A <see cref="IntegrationResult"/> containing the read data and operation outcome.</returns>
        Task<IntegrationResult> Read(IntegrationItem IntegrationItem);

        /// <summary>
        /// Synchronizes a collection of integration items with the external system.
        /// </summary>
        /// <param name="IntegrationItems">The integration items to synchronize.</param>
        /// <param name="IsStockUpdate">Indicates whether the synchronization is a stock update.</param>
        /// <returns>A <see cref="IntegrationResult"/> indicating the outcome of the operation.</returns>
        Task<IntegrationResult> SyncIntegrationItems(IEnumerable<IntegrationItem> IntegrationItems, bool IsStockUpdate);

        /// <summary>
        /// Updates an existing integration item in the external system.
        /// </summary>
        /// <param name="IntegrationItem">The integration item to update.</param>
        /// <returns>A <see cref="IntegrationResult"/> indicating the outcome of the operation.</returns>
        Task<IntegrationResult> Update(IntegrationItem IntegrationItem);
    }
}