using System;
using System.Transactions;
using Kinetic.Sdk.Configurations;
using NUnit.Framework;
using Solana.Unity.Rpc.Models;
using UnityEngine;
using Transaction = Solana.Unity.Rpc.Models.Transaction;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Tests
{
    [TestFixture]
    public class KineticSdkTest
    {
        private KineticSdk _sdk;
        private const string Endpoint = "https://sandbox.kinetic.host/";

        [SetUp]
        public void Init()
        {
            _sdk = KineticSdk.SetupSync(
                new KineticSdkConfig(
                    index:1,
                    endpoint: Endpoint, 
                    environment: KineticSdkEndpoint.Devnet,
                    logger: new Logger(Debug.unityLogger.logHandler)
                )
            );
        }

        [Test]
        public void TestGetAppConfig()
        {
            var res = _sdk.Config;

            Assert.AreEqual( Endpoint, _sdk.SdkConfig.Endpoint);
            Assert.AreEqual( 1, res.App.Index);
            Assert.AreEqual("App 1", res.App.Name);
            Assert.AreEqual(KineticSdkEndpoint.Devnet, res.Environment.Name );
            Assert.AreEqual("solana-devnet", res.Environment.Cluster.Id);
            Assert.AreEqual("Solana Devnet", res.Environment.Cluster.Name);
            Assert.AreEqual("KIN", res.Mint.Symbol);
            Assert.NotNull(res.Mint.PublicKey);
            Assert.IsTrue(res.Mints.Count > 0);
            Assert.AreEqual("KIN", res.Mints[0].Symbol);
            Assert.NotNull(res.Mints[0].PublicKey);
            Assert.NotNull(_sdk.Solana.Connection);
            Assert.AreEqual("https://api.devnet.solana.com/", _sdk.Solana.Connection.NodeAddress.ToString());
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
            var res = _sdk.GetBalanceSync(account: KineticSdkFixture.AliceKeypair.PublicKey);
            var balance = double.Parse(res.Balance);
            Assert.IsTrue(!double.IsNaN(balance));
            Assert.IsTrue(balance > 0);
        }
        
        [Test]
        public void TestCreateAccount()
        {
            var owner = Keypair.Random();
            var tx = _sdk.CreateAccountSync(owner);

            Assert.NotNull(tx);
            Assert.NotNull(tx.Signature);
            Assert.AreEqual(0, tx.Errors.Count);
            Assert.AreEqual(_sdk.Config.Mint.PublicKey, tx.Mint);
            Assert.AreEqual("Committed", tx.Status);
        }
        
        [Test]
        public void TestCreateAccountAlreadyExists()
        {
            var tx = _sdk.CreateAccountSync(KineticSdkFixture.DaveKeypair);
            Assert.IsNull(tx.Signature);
            Assert.IsNull(tx.Amount);
            Assert.IsTrue(tx.Errors.Count > 0);
            Assert.AreEqual("Failed", tx.Status);
            //Assert.IsTrue(tx.Errors[0].Message.Contains("Error: Account already exists."));
        }
        
        [Test]
        public void TestGetHistory()
        {
            var history = _sdk.GetHistorySync(KineticSdkFixture.AliceKeypair.PublicKey);
            Assert.IsTrue(history.Count > 0);
            Assert.IsNotNull(history[0].Account);
        }
        
        [Test]
        public void TestGetTokenAccounts()
        {
            var tokenAccounts = _sdk.GetTokenAccountsSync(KineticSdkFixture.AliceKeypair.PublicKey);
            Assert.IsTrue(tokenAccounts.Count > 0);
            Assert.IsNotNull(tokenAccounts[0]);
        }
        
        [Test]
        public void TestGetExplorerUrl()
        {
            var kp = Keypair.Random();
            var explorerUrl = _sdk.GetExplorerUrl(kp.PublicKey);
            Assert.IsTrue(explorerUrl.Contains(kp.PublicKey));
        }
        
        [Test]
        public void TestTransaction()
        {
            var tx = _sdk.MakeTransferSync(
                amount: "43",
                destination: KineticSdkFixture.BobKeypair.PublicKey,
                owner: KineticSdkFixture.AliceKeypair);
            Assert.IsNotNull(tx);
            Assert.AreEqual(_sdk.Config.Mint.PublicKey, tx.Mint);
            Assert.IsNotNull(tx.Signature);
            Assert.IsTrue(tx.Errors.Count == 0);
            Assert.IsTrue(uint.Parse(tx.Amount) == 4300000);
            Assert.AreEqual(KineticSdkFixture.AliceKeypair.PublicKey.ToString(), tx.Source);
        }
        
        [Test]
        public void TestTransactionWithInsufficientFunds()
        {
            var tx = _sdk.MakeTransferSync(
                amount: "99999999999999",
                destination: KineticSdkFixture.BobKeypair.PublicKey,
                owner: KineticSdkFixture.AliceKeypair);
            Assert.IsNull(tx.Signature);
            Assert.AreEqual("9999999999999900000", tx.Amount);
            Assert.IsTrue(tx.Errors.Count > 0);
            Assert.AreEqual("Failed", tx.Status);
            Assert.IsTrue(tx.Errors[0].Message.Contains("Error: Insufficient funds."));
        }
        
        [Test]
        public void TestTransactionWithSenderCreation()
        {
            var destination = Keypair.Random();
            var tx = _sdk.MakeTransferSync(
                amount: "43",
                destination: destination.PublicKey,
                owner: KineticSdkFixture.AliceKeypair,
                senderCreate: true);
            Assert.IsNotNull(tx);
            Assert.IsNotNull(tx.Signature);
            Assert.AreEqual("4300000", tx.Amount);
            Assert.IsTrue(tx.Errors.Count == 0);
            Assert.AreEqual(KineticSdkFixture.AliceKeypair.PublicKey.ToString(), tx.Source);
        }
        
        [Test]
        public void TestTransactionWithoutSenderCreation()
        {
            try
            {
                var destination = Keypair.Random();
                _sdk.MakeTransferSync(
                    amount: "43",
                    destination: destination.PublicKey,
                    owner: KineticSdkFixture.AliceKeypair,
                    senderCreate: false);
                Assert.IsTrue(false);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Destination account doesn't exist."));
            }
        }
        
        [Test]
        public void TestTransactionToMint()
        {
            const string kinMint = "KinDesK3dYWo3R2wDk6Ucaf31tvQCCSYyL8Fuqp33GX";
            try
            {
                _sdk.MakeTransferSync(
                    amount: "43",
                    destination: kinMint,
                    owner: KineticSdkFixture.AliceKeypair,
                    senderCreate: false);
                Assert.IsTrue(false);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Transfers to a mint are not allowed."));
            }
        }
        
        [Test]
        public void TestRequestAirdrop()
        {
            var airdrop = _sdk.RequestAirdropSync( account: KineticSdkFixture.DaveKeypair.PublicKey, amount: "1000" );
            Assert.IsNotNull(airdrop.Signature);
        }
        
        [Test]
        public void TestRequestAirdropExceedMaximum()
        {
            try
            {
                _sdk.RequestAirdropSync( account: KineticSdkFixture.DaveKeypair.PublicKey, amount: "50001" );
                Assert.IsTrue(false);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Error: Try requesting 50000 or less."));
            }
        }
        
    }
}