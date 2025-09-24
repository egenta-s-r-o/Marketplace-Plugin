namespace MarketplacePlugin.Models.Exception
{
    /// <summary>
    /// Represents errors that occur during integration operations.
    /// </summary>
    public class IntegrationException : System.Exception
    {
        private Dictionary<string, string> _details = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public IntegrationException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        public IntegrationException(string message, System.Exception inner) : base(message, inner) { }

        /// <summary>
        /// Adds a detail to the exception.
        /// </summary>
        /// <param name="key">The key of the detail.</param>
        /// <param name="value">The value of the detail.</param>
        /// <returns>The current <see cref="IntegrationException"/> instance.</returns>
        public IntegrationException AddDetail(string key, string value)
        {
            _details[key] = value;
            return this;
        }

        /// <summary>
        /// Gets the details associated with the exception.
        /// </summary>
        public IReadOnlyDictionary<string, string> Details => _details;
    }
}
