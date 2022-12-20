using System;
using Kinetic.Sdk.Interfaces;
using NUnit.Framework;
using Solana.Unity.Rpc.Models;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Tests
{
    [TestFixture]
    public class KineticSdkTest
    {
        [SetUp]
        public void Init()
        {
            _sdk = KineticSdk.SetupSync(
                new KineticSdkConfig(
                    Endpoint,
                    Environment,
                    Index,
                    new Logger(Debug.unityLogger.logHandler)
                )
            );
        }

        private KineticSdk _sdk;
        private const string Environment = "devnet";
        // private const string Environment = "local";
        private const string Endpoint = "https://sandbox.kinetic.host";
        // private const string Endpoint = "http://localhost:3000";
        private const int Index = 1;

        [Test]
        public void TestGetAppConfig()
        {
            var res = _sdk.Config();

            Assert.AreEqual(Endpoint, _sdk.SdkConfig.Endpoint);
            Assert.AreEqual(1, res.App.Index);
            Assert.AreEqual("App 1", res.App.Name);
            Assert.AreEqual("devnet", res.Environment.Name);
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
            var res = _sdk.GetBalanceSync(KineticSdkFixture.AliceKeypair.PublicKey);
            var balance = double.Parse(res.Balance);
            Assert.IsTrue(!double.IsNaN(balance));
            Assert.IsTrue(balance > 0);
        }

        [Test, Timeout(30000)]
        public void TestGetAccountInfo()
        {
            var res = _sdk.GetAccountInfoSync(account: KineticSdkFixture.AliceKeypair.PublicKey);
            
            Assert.IsFalse(res.IsMint);
            Assert.IsFalse(res.IsTokenAccount);
            Assert.IsTrue(res.IsOwner);
            Assert.AreEqual(1, res.Tokens.Count);
            Assert.AreEqual(5, res.Tokens[0].Decimals);
            Assert.AreEqual(KineticSdkFixture.DefaultMint, res.Tokens[0].Mint);
            Assert.AreEqual(KineticSdkFixture.AliceKeypair.PublicKey.ToString(), res.Tokens[0].Owner);
            Assert.AreEqual(KineticSdkFixture.AliceTokenAccount, res.Tokens[0].Account);
        }


        [Test, Timeout(30000)]
        public void TestCloseAccount()
        {
            
            var owner = Keypair.Random();
            var createdTx = _sdk.CreateAccountSync(owner, commitment: Commitment.Finalized, referenceType: "Unity: TestCloseAccount", referenceId: "Create");

            Assert.NotNull(createdTx);
            Assert.NotNull(createdTx.Signature);
            Assert.AreEqual(0, createdTx.Errors.Count);
            Assert.AreEqual(_sdk.Config().Mint.PublicKey, createdTx.Mint);
            Assert.AreEqual("Committed", createdTx.Status);
            
            var closedTx = _sdk.CloseAccountSync(owner.PublicKey, commitment: Commitment.Finalized, referenceType: "Unity: TestCloseAccount", referenceId: "Close");

            Assert.NotNull(closedTx);
            Assert.NotNull(closedTx.Signature);
            Assert.AreEqual(0, closedTx.Errors.Count);
            Assert.AreEqual(_sdk.Config().Mint.PublicKey, closedTx.Mint);
            Assert.AreEqual("Committed", closedTx.Status);
        }
        
        [Test]
        public void TestCreateAccount()
        {
            var owner = Keypair.Random();
            var tx = _sdk.CreateAccountSync(owner);

            Assert.NotNull(tx);
            Assert.NotNull(tx.Signature);
            Assert.AreEqual(0, tx.Errors.Count);
            Assert.AreEqual(_sdk.Config().Mint.PublicKey, tx.Mint);
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
            Assert.AreEqual(_sdk.Config().Mint.PublicKey, tx.Mint);
            Assert.IsNotNull(tx.Signature);
            Assert.IsTrue(tx.Errors.Count == 0);
            Assert.IsTrue(tx.Amount == "43");
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
            Assert.AreEqual("99999999999999", tx.Amount);
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
            Assert.AreEqual("43", tx.Amount);
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
            var airdrop = _sdk.RequestAirdropSync(KineticSdkFixture.DaveKeypair.PublicKey, "1000");
            Assert.IsNotNull(airdrop.Signature);
        }

        [Test]
        public void TestRequestAirdropExceedMaximum()
        {
            try
            {
                _sdk.RequestAirdropSync(KineticSdkFixture.DaveKeypair.PublicKey, "50001");
                Assert.IsTrue(false);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Try requesting 50000 or less."));
            }
        }
    }
}