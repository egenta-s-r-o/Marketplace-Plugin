using MarketplacePlugin.Interfaces.Login;

namespace MarketplacePlugin.Interfaces.Integration
{
    public interface IMarketplaceHandler<TAuth, TProduct, TOffer>

        where TAuth : IMarketplaceAuth
        where TProduct : IProductIntegration
        where TOffer : IOfferIntegration
    {
        string MarketplaceName { get; }

        TAuth Auth { get; }
    }

    public abstract class Market : IMarketplaceHandler<IMarketplaceAuth, IProductIntegration, IOfferIntegration>
    {
        public abstract string MarketplaceName { get; }
        public IMarketplaceAuth Auth { get; }
        public IProductIntegration ProductIntegration { get; }
        public IOfferIntegration OfferIntegration { get; }

        public Market(IMarketplaceAuth auth, IProductIntegration productIntegration, IOfferIntegration offerIntegration)
        {
            Auth = auth ?? throw new ArgumentNullException(nameof(auth));
            ProductIntegration = productIntegration ?? throw new ArgumentNullException(nameof(productIntegration));
            OfferIntegration = offerIntegration ?? throw new ArgumentNullException(nameof(offerIntegration));
        }
    }
}
