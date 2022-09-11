using Solana.Unity.Rpc;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk
{
    public class Solana
    {
        public readonly IRpcClient Connection;

        public Solana(string endpoint, Logger logger=null)
        {
            Connection = ClientFactory.GetClient(endpoint);
        }
    }
}