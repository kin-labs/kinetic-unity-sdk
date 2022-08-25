using System.Linq;
using NUnit.Framework;
using Solana.Unity.Wallet.Bip39;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Tests
{
    [TestFixture]
    public class KeypairTest
    {

        [Test]
        public void TestKeypairRandom()
        {
            var keypair = Keypair.Random();
            Assert.IsNotNull(keypair);
            Assert.IsNotNull(keypair.PublicKey);
            Assert.IsNotNull(keypair.SecretKey);
            Assert.IsNotNull(keypair.Mnemonic);
            Assert.IsNotNull(keypair.Solana);
        }

        [Test]
        public void TestKeypairFromMnemonic()
        {
            var keypair = Keypair.Random();
            var restored = Keypair.FromMnemonic(keypair.Mnemonic.ToString());

            Assert.AreEqual(restored.Mnemonic.ToString(), keypair.Mnemonic.ToString());
            Assert.AreEqual(restored.SecretKey, keypair.SecretKey);
            Assert.AreEqual(restored.PublicKey, keypair.PublicKey);
        }

        [Test]
        public void TestMnemonicGeneration12()
        {
            var mnemonic = Keypair.GenerateMnemonic();
            Assert.AreEqual(12, new Mnemonic(mnemonic).Words.Length);
        }

        [Test]
        public void TestMnemonicGeneration24()
        {
            var mnemonic = Keypair.GenerateMnemonic(WordCount.TwentyFour);
            Assert.AreEqual(24, new Mnemonic(mnemonic).Words.Length);
        }


        [Test]
        public void TestCreateImportKeypair()
        {
            var kp1 = Keypair.Random();
            var kp2 = Keypair.FromSecretKey(kp1.SecretKey);
            Assert.AreEqual(kp1.SecretKey, kp2.SecretKey);
            Assert.AreEqual(kp1.PublicKey, kp2.PublicKey);
        }

        [Test]
        public void TestImportFromByteArray()
        {
            var kp = Keypair.FromByteArray(KeypairFixture.TestSecretByteArray);
            Assert.AreEqual(kp.PublicKey.ToString(), KeypairFixture.TestPublicKey);
        }

        [Test]
        public void TestImportExistingSecretKey()
        {
            var kp = Keypair.FromSecretKey(KeypairFixture.TestSecretKey);
            Assert.AreEqual(kp.PublicKey.ToString(), KeypairFixture.TestPublicKey);
        }

        [Test]
        public void TestImportMnemonic12()
        {
            var keypair = Keypair.FromMnemonic(KeypairFixture.TestMnemonic12);
            CollectionAssert.AreEqual(keypair.SecretKey.KeyBytes, KeypairFixture.TestSecretByteArray);
            Assert.AreEqual(keypair.SecretKey.ToString(), KeypairFixture.TestSecretKey);
            Assert.AreEqual(keypair.PublicKey.ToString(), KeypairFixture.TestPublicKey);
        }

        [Test]
        public void TestImportMnemonic24()
        {
            var keypair = Keypair.FromMnemonic(KeypairFixture.TestMnemonic24);
            Assert.AreEqual(keypair.SecretKey.ToString(), KeypairFixture.TestMnemonic24SecretKey);
            Assert.AreEqual(keypair.PublicKey.ToString(), KeypairFixture.TestMnemonic24PublicKey);
        }

        [Test]
        public void TestImportMnemonicSet12()
        {
            var keypairSet = Keypair.FromMnemonicSet(KeypairFixture.TestMnemonic12);
            var keypairs = KeypairFixture.TestMnemonic12Set.Zip(keypairSet, (kp1, kp2)
                => new {KP1 = kp1, KP2 = kp2});

            foreach (var kp in keypairs)
            {
                Assert.AreEqual(kp.KP1.SecretKey, kp.KP2.SecretKey);
                Assert.AreEqual(kp.KP1.PublicKey, kp.KP2.PublicKey);
                CollectionAssert.AreEqual(kp.KP1.SecretKey.KeyBytes, kp.KP2.SecretKey.KeyBytes);
            }
        }

        [Test]
        public void TestImportMnemonicSet24()
        {
            var keypairSet = Keypair.FromMnemonicSet(KeypairFixture.TestMnemonic24);
            var keypairs = KeypairFixture.TestMnemonic24Set.Zip(keypairSet, (kp1, kp2)
                => new {KP1 = kp1, KP2 = kp2});

            foreach (var kp in keypairs)
            {
                Assert.AreEqual(kp.KP1.SecretKey, kp.KP2.SecretKey);
                Assert.AreEqual(kp.KP1.PublicKey, kp.KP2.PublicKey);
                CollectionAssert.AreEqual(kp.KP1.SecretKey.KeyBytes, kp.KP2.SecretKey.KeyBytes);
            }
        }
    }
}