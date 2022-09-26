using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Interfaces
{
    public class KineticSdkConfig
    {
        public readonly string Endpoint;
        public readonly string Environment;
        public readonly int Index;
        public readonly Logger Logger;
        public string SolanaRpcEndpoint;

        public KineticSdkConfig(
            int index,
            string endpoint,
            string environment,
            Logger logger = null,
            string solanaRpcEndpoint = null
        )
        {
            Index = index;
            Endpoint = endpoint;
            Environment = environment;
            Logger = logger;
            SolanaRpcEndpoint = solanaRpcEndpoint;
        }
    }

    public static class KineticSdkEndpoint
    {
        public const string Devnet = "devnet";
        public const string Mainnet = "mainnet";
    }
}