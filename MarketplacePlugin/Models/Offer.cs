namespace MarketplacePlugin.Models
{
    /// <summary>
    /// Represents an offer for a product in the marketplace, including price and stock information.
    /// </summary>
    public class Offer : Product
    {
        /// <summary>
        /// Gets or sets the price of the offer.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the available stock for the offer.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this update is only for stock changes.
        /// </summary>
        public bool IsOnlyStockupdate { get; set; }
    }
}
