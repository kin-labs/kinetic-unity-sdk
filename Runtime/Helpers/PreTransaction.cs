// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Helpers
{
    public class PreTransaction
    {
        public string LatestBlockhash { get; set; }
        public int LastValidBlockHeight { get; set; }
        public int MintDecimals { get; set; }
        public string MintFeePayer { get; set; }
        public string MintPublicKey { get; set; }
    }
}