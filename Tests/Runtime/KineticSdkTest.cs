using Kinetic.Sdk.Helpers;
using NUnit.Framework;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Tests
{
    [TestFixture]
    public class KineticSdkTest
    {
        private KineticSdk _sdk;

        [SetUp]
        public void Init()
        {
            _sdk = KineticSdk.Setup(
                new KineticSdkConfig(
                    index:1,
                    endpoint: "https://devnet.kinetic.kin.org", 
                    environment: KineticSdkEndpoint.Devnet,
                    logger: new Logger(Debug.unityLogger.logHandler)
                )
            );
        }

        [Test]
        public void TestGetAppConfig()
        {
            var res = _sdk.Config;

            Assert.AreEqual( 1, res.App.Index);
            Assert.AreEqual("App 1", res.App.Name);
            Assert.AreEqual("devnet", res.Environment.Name );
            Assert.AreEqual("https://devnet.kinetic.kin.org", res.Environment.Cluster.Endpoint.ParseEndpoint() );
            Assert.AreEqual("solana-devnet", res.Environment.Cluster.Id);
            Assert.AreEqual("Solana Devnet", res.Environment.Cluster.Name);
            Assert.AreEqual("KIN", res.Mint.Symbol);
            Assert.NotNull(res.Mint.PublicKey);
            Assert.IsTrue(res.Mints.Count > 0);
            Assert.AreEqual("KIN", res.Mints[0].Symbol);
            Assert.NotNull(res.Mints[0].PublicKey);
            Assert.NotNull(_sdk.Solana.Connection);
        }
    }
}