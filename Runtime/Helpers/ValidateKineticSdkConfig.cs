using System;
using Kinetic.Sdk.Interfaces;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Transactions
{
    public static class ValidateKineticSdkConfig
    {
        public static KineticSdkConfig Validate(
            KineticSdkConfig config
        )
        {
            // Throw error if endpoint does not start with http
            if (!config.Endpoint.StartsWith("http"))
            {
                throw new ArgumentException("validateKineticSdkConfig: the endpoint should start with http or https.");
            }

            var commitment = config.Commitment ?? Commitment.Confirmed;
            var endpoint = config.Endpoint.EndsWith("/") ? config.Endpoint.Substring(0, config.Endpoint.Length - 1) : config.Endpoint;
            
            return new KineticSdkConfig(
                endpoint,
                config.Environment,
                config.Index,
                config.Logger,
                commitment,
                config.SolanaRpcEndpoint);
        }
    }
}