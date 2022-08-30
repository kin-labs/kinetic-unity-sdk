using System;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Helpers
{
    public static class KineticSdkEndpoint
    {
        public const string Devnet = "devnet";
        public const string Mainnet = "mainnet";
    }
    
    public static class EndpointExtensions
    {
        public static string ParseEndpoint(this string endpoint)
        {
            switch(endpoint)
            {
                case KineticSdkEndpoint.Devnet:
                {
                    return "https://devnet.kinetic.kin.org";
                }

                case KineticSdkEndpoint.Mainnet:
                {
                    return "https://mainnet.kinetic.kin.org";
                }

                default:
                {
                    if (endpoint.StartsWith("http"))
                    {
                        return endpoint;
                    }
                    throw new InvalidOperationException("Unknown http or https endpoint");
                }
            }
        }
    }
}