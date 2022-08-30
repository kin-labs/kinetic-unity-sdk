// ReSharper disable once CheckNamespace

using Kinetic.Sdk.Helpers;
using Solana.Unity.Rpc;
using UnityEngine;

namespace Kinetic.Sdk
{
    public class Solana
    {
        private readonly string _endpoint;
        public readonly IRpcClient Connection;

        public Solana(string endpoint, Logger logger=null)
        {
            _endpoint = endpoint.ParseEndpoint();
            Connection = ClientFactory.GetClient(_endpoint);
        }
    }
}