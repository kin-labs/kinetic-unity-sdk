using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Helpers
{
    public class KineticSdkConfig
    {
        public readonly long Index;
        public readonly string Endpoint;
        public readonly string Environment;
        public readonly Logger Logger;
        public string SolanaRpcEndpoint;

        public KineticSdkConfig(long index, string endpoint, string environment,
            Logger logger = null, string solanaRpcEndpoint = null)
        {
            Index = index;
            Endpoint = endpoint;
            Environment = environment;
            Logger = logger;
            SolanaRpcEndpoint = solanaRpcEndpoint;
        }
    }
}