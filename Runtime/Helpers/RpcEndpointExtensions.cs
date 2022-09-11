using System;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Helpers
{
    public static class RpcEndpointExtensions
    {
        public static string GetSolanaRpcEndpoint(this string endpoint)
        {
            switch(endpoint)
            {
                case "devnet":
                {
                    return "https://api.devnet.solana.com";
                }

                case "mainnet":
                case "mainnet-beta":
                    return "https://api.mainnet-beta.solana.com";

                default:
                {
                    if (endpoint != null && endpoint.StartsWith("http"))
                    {
                        return endpoint;
                    }
                    throw new InvalidOperationException("Unknown http or https endpoint");
                }
            }
        }
    }
}