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
                    return "devnet";
                }

                case "mainnet":
                case "mainnet-beta":
                    return "mainnet-beta";

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