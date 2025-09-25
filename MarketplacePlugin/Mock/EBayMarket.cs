using MarketplacePlugin.Interfaces;
using MarketplacePlugin.Interfaces.Integration;
using MarketplacePlugin.Interfaces.Login;

namespace MarketplacePlugin.Mock
{
    public class EBayMarket : Market
    {
        public override string MarketplaceName => "eBay";
        public EBayMarket(IMarketplaceAuth auth, IIntegration productIntegration, IIntegration offerIntegration)
            : base(auth, productIntegration, offerIntegration)
        {
        }
    }
}
