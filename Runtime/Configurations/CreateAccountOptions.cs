using Solana.Unity.Rpc.Types;

namespace Kinetic.Sdk.Helpers
{
    public class CreateAccountOptions
    {
        public Keypair Owner;
        public Commitment Commitment;
        public string Mint;

        public CreateAccountOptions(Keypair owner, Commitment commitment = default, string mint = null)
        {
            Owner = owner;
            Commitment = commitment;
            Mint = mint;
        }
    }
}