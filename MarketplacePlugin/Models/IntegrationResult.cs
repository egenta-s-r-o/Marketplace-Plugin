namespace MarketplacePlugin.Models
{
    /// <summary>
    /// Represents the base result of an operation, including success status, message, and additional attributes.
    /// </summary>
    public class IntegrationResult<TItem> where TItem : IntegrationItem
    {
        /// <summary>
        /// Gets or sets a value indicating whether the operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets a message describing the result of the operation.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a collection of additional attributes related to the result.
        /// The key is the attribute name, and the value is the attribute value.
        /// </summary>
        public Dictionary<string, object?> Attributes { get; set; } = new();

        /// <summary>
        /// Gets or sets the integration items associated with the result, if any.
        /// </summary>
        public IEnumerable<TItem>? IntegrationItems { get; set; }
    }
}
