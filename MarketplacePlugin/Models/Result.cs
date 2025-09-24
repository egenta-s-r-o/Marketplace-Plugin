namespace MarketplacePlugin.Models
{
    /// <summary>
    /// Represents the base result of an operation, including success status, message, and additional attributes.
    /// </summary>
    public abstract class Result
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
        /// </summary>
        public Dictionary<string, object?> Attributes { get; set; } = new();
    }
}
