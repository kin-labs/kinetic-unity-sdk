using System.Threading;
using Kinetic.Sdk.Helpers;
using NUnit.Framework;
using Solana.Unity.Rpc.Models;
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

        [Test]
        public void PartialSignCreateAccountTransaction()
        {
            var tx = Transaction.Populate(Message.Deserialize(KineticSdkFixture.CreateAccountCompiledTransaction));
            CollectionAssert.AreEqual(KineticSdkFixture.CreateAccountCompiledTransaction, tx.CompileMessage());
            tx.PartialSign(KineticSdkFixture.CreateAccountSigner.Solana);
            Assert.IsTrue(tx.Signatures.Count > 0);
            Assert.NotNull(tx.Signatures[0]);
            Assert.IsTrue(tx.VerifySignatures());
            Assert.AreEqual(KineticSdkFixture.CreateAccountPartialSignature, tx.Signatures[0].Signature);
        }
        
        [Test]
        public void GetBalance()
        {
            var res = _sdk.GetBalance(account: KineticSdkFixture.AliceKeypair.PublicKey);
            var balance = double.Parse(res.Balance);
            Assert.IsTrue(!double.IsNaN(balance));
            Assert.IsTrue(balance > 0);
        }
        
        [Test]
        public void TestCreateAccount()
        {
            var owner = Keypair.Random();
            var tx = _sdk.CreateAccount(owner);

            Assert.NotNull(tx);
            Assert.NotNull(tx.Signature);
            Assert.AreEqual(0, tx.Errors.Count);
            Assert.AreEqual(_sdk.Config.Mint.PublicKey, tx.Mint);
            Assert.AreEqual("Committed", tx.Status);
        }
        
        [Test]
        public void TestCreateAccountAlreadyExists()
        {
            var tx = _sdk.CreateAccount(KineticSdkFixture.DaveKeypair);
            Assert.IsNull(tx.Signature);
            Assert.IsNull(tx.Amount);
            Assert.IsTrue(tx.Errors.Count > 0);
            Assert.AreEqual("Failed", tx.Status);
            //Assert.IsTrue(tx.Errors[0].Message.Contains("Error: Account already exists."));
        }
        
        [Test]
        public void TestGetHistory()
        {
            var history = _sdk.GetHistory(KineticSdkFixture.AliceKeypair.PublicKey);
            Assert.IsTrue(history.Count > 0);
            Assert.IsNotNull(history[0].Account);
        }
        
        [Test]
        public void TestGetTokenAccounts()
        {
            var tokenAccounts = _sdk.GetTokenAccounts(KineticSdkFixture.AliceKeypair.PublicKey);
            Assert.IsTrue(tokenAccounts.Count > 0);
            Assert.IsNotNull(tokenAccounts[0]);
        }
    }
}