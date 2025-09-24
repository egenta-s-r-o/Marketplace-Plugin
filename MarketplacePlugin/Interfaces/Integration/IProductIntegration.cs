using MarketplacePlugin.Models;
using MarketplacePlugin.Models.Exception;

namespace MarketplacePlugin.Interfaces.Integration
{
    /// <summary>
    /// Defines CRUD operations and synchronization for product integration with a marketplace.
    /// </summary>
    public interface IProductIntegration
    {
        /// <summary>
        /// Creates a new product in the marketplace.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating whether the creation was successful, including any relevant messages or attributes.
        /// </returns>
        Task<Result> Create(Product product);

        /// <summary>
        /// Reads product details from the marketplace.
        /// </summary>
        /// <param name="product">The product to read.</param>
        /// <returns>
        /// A <see cref="Result"/> containing the product data, success status, and any additional attributes.
        /// </returns>
        Task<Result> Read(Product product);

        /// <summary>
        /// Updates an existing product in the marketplace.
        /// </summary>
        /// <param name="product">The product to update.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating whether the update was successful, including any relevant messages or attributes.
        /// </returns>
        Task<Result> Update(Product product);

        /// <summary>
        /// Deletes a product from the marketplace.
        /// </summary>
        /// <param name="product">The product to delete.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating whether the deletion was successful, including any relevant messages or attributes.
        /// </returns>
        Task<Result> Delete(Product product);

        /// <summary>
        /// Synchronizes a collection of products with the marketplace.
        /// </summary>
        /// <param name="products">The products to synchronize.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating the outcome of the synchronization, including any relevant messages or attributes.
        /// </returns>
        Task<Result> SyncProducts(IEnumerable<Product> products);

        /// <summary>
        /// Occurs when an error happens during product creation in the marketplace.
        /// </summary>
        event EventHandler<IntegrationException> OnProductCreateError;
        /// <summary>
        /// Occurs when an error happens during reading product details from the marketplace.
        /// </summary>
        event EventHandler<IntegrationException> OnProductReadError;
        /// <summary>
        /// Occurs when an error happens during updating a product in the marketplace.
        /// </summary>
        event EventHandler<IntegrationException> OnProductUpdateError;
        /// <summary>
        /// Occurs when an error happens during deleting a product from the marketplace.
        /// </summary>
        event EventHandler<IntegrationException> OnProductDeleteError;
        /// <summary>
        /// Occurs when an error happens during synchronizing products with the marketplace.
        /// </summary>
        event EventHandler<IntegrationException> OnProductSyncError;
    }
}
