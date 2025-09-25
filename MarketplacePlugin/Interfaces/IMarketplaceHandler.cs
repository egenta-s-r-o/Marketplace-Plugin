using MarketplacePlugin.Interfaces.Integration;
using MarketplacePlugin.Interfaces.Login;

namespace MarketplacePlugin.Interfaces
{
    public interface IMarketplaceHandler<TAuth, TProduct, TOffer>

        where TAuth : IMarketplaceAuth
        where TProduct : IIntegration
        where TOffer : IIntegration
    {
        string MarketplaceName { get; }

        TAuth Auth { get; }
    }
}
