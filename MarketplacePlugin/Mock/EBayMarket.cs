using MarketplacePlugin.Interfaces.Integration;
using MarketplacePlugin.Interfaces.Login;

namespace MarketplacePlugin.Mock
{
    public class EBayMarket : Market
    {
        public override string MarketplaceName => "eBay";
        public EBayMarket(IMarketplaceAuth auth, IProductIntegration productIntegration, IOfferIntegration offerIntegration)
            : base(auth, productIntegration, offerIntegration)
        {
        }
    }
}
