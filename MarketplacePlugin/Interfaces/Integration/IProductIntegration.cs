using MarketplacePlugin.Models;

namespace MarketplacePlugin.Interfaces.Integration
{
    /// <summary>
    /// Defines CRUD operations for product integration with a marketplace.
    /// </summary>
    public interface IProductIntegration
    {
        /// <summary>
        /// Creates a new product in the marketplace.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>A <see cref="Result"/> indicating the outcome.</returns>
        Task<Result> Create(Product product);

        /// <summary>
        /// Reads product details from the marketplace.
        /// </summary>
        /// <param name="product">The product to read.</param>
        /// <returns>A <see cref="Result"/> containing product data.</returns>
        Task<Result> Read(Product product);

        /// <summary>
        /// Updates an existing product in the marketplace.
        /// </summary>
        /// <param name="product">The product to update.</param>
        /// <returns>A <see cref="Result"/> indicating the outcome.</returns>
        Task<Result> Update(Product product);

        /// <summary>
        /// Deletes a product from the marketplace.
        /// </summary>
        /// <param name="product">The product to delete.</param>
        /// <returns>A <see cref="Result"/> indicating the outcome.</returns>
        Task<Result> Delete(Product product);
    }
}
