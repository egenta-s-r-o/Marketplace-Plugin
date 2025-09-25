using MarketplacePlugin.Interfaces.Integration;
using MarketplacePlugin.Interfaces.Login;

namespace MarketplacePlugin.Interfaces
{
    public abstract class Market : IMarketplaceHandler<IMarketplaceAuth, IIntegration, IIntegration>
    {
        public abstract string MarketplaceName { get; }
        public IMarketplaceAuth Auth { get; }
        public IIntegration? ProductIntegration { get; }
        public IIntegration? OfferIntegration { get; }

        public Market(IMarketplaceAuth auth, IIntegration productIntegration, IIntegration offerIntegration)
        {
            Auth = auth ?? throw new ArgumentNullException(nameof(auth));
            ProductIntegration = productIntegration;
            OfferIntegration = offerIntegration;
        }
    }
}
