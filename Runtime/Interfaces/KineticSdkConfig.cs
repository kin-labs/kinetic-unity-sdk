using UnityEngine;

// ReSharper disable once CheckNamespace


namespace Kinetic.Sdk.Interfaces
{
    public class KineticSdkConfig
    {
        public Kinetic.Sdk.Interfaces.Commitment? Commitment;
        public readonly string Endpoint;
        public readonly string Environment;
        public readonly int Index;
        public readonly Logger Logger;
        public string SolanaRpcEndpoint;

        public KineticSdkConfig(
            string endpoint,
            string environment,
            int index,
            Logger logger = null,
            Commitment? commitment = null,
            string solanaRpcEndpoint = null
        )
        {
            Index = index;
            Endpoint = endpoint;
            Environment = environment;
            Commitment = commitment;
            Logger = logger;
            SolanaRpcEndpoint = solanaRpcEndpoint;
        }
    }
}