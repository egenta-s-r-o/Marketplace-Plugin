using MarketplacePlugin.Models.Login;

namespace MarketplacePlugin.Interfaces.Login
{
    public interface IMarketplaceAuth
    {
        /// <summary>
        /// Perform authentication and return a valid token or credentials object.
        /// </summary>
        Task<AuthResult> AuthenticateAsync();
    }

}
