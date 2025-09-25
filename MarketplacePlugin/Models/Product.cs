namespace MarketplacePlugin.Models
{

    /// <summary>
    /// Represents a product in the marketplace.
    /// </summary>
    public class Product : IntegrationItem
    {
        /// <summary>
        /// Gets or sets the European Article Number (EAN) of the product.
        /// </summary>
        public string EAN { get; set; }

        /// <summary>
        /// Gets or sets the Stock Keeping Unit (SKU) of the product.
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// Gets or sets a dictionary of additional attributes for the product.
        /// The key is the attribute name, and the value is the attribute value.
        /// </summary>
        public Dictionary<string, object?> Attributes { get; set; } = new();
    }
}
