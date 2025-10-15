using MarketplacePlugin.Interfaces;
using MarketplacePlugin.Interfaces.Login;

namespace MarketplacePlugin.MockImplementation
{
    public class EBayMarket : Market
    {
        public EBayMarket(IMarketplaceAuth auth) : base(auth)
        {
        }
        public override string MarketplaceName => "eBay";
    }
}
