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
        public void TestCreateImportKeypairFromSecret()
        {
            var kp1 = Keypair.Random();

            var byteArray = "[" + kp1.SecretKey.KeyBytes.Aggregate("", (current, b) => current + (b + ",")) + "]";
            var fromByteArray = Keypair.FromSecret(byteArray);
            
            Assert.AreEqual(fromByteArray.SecretKey, kp1.SecretKey);
            Assert.AreEqual(fromByteArray.PublicKey, kp1.PublicKey);
            Assert.AreEqual(fromByteArray.Mnemonic, null);
            
            var fromMnemonic = Keypair.FromSecret(kp1.Mnemonic.ToString());
            Assert.AreEqual(fromMnemonic.SecretKey, kp1.SecretKey);
            Assert.AreEqual(fromMnemonic.PublicKey, kp1.PublicKey);
            Assert.AreEqual(fromMnemonic.Mnemonic.ToString(), kp1.Mnemonic.ToString());
            
            var fromSecretKey = Keypair.FromSecret(kp1.SecretKey.ToString());
            Assert.AreEqual(fromSecretKey.SecretKey, kp1.SecretKey);
            Assert.AreEqual(fromSecretKey.PublicKey, kp1.PublicKey);
            Assert.AreEqual(fromSecretKey.Mnemonic, null);
        }


        [Test]
        public void TestCreateImportKeypair()
        {
            var kp1 = Keypair.Random();
            var kp2 = Keypair.FromSecretKey(kp1.SecretKey);
            var kpSecret = Keypair.FromSecret(kp1.SecretKey);
            Assert.AreEqual(kp1.SecretKey, kp2.SecretKey);
            Assert.AreEqual(kp1.PublicKey, kp2.PublicKey);
            Assert.AreEqual(kpSecret.PublicKey, kp2.PublicKey);
        }

        [Test]
        public void TestImportFromByteArray()
        {
            var kp = Keypair.FromByteArray(KeypairFixture.TestSecretByteArray);
            var kpSecret = Keypair.FromSecret("[" + KeypairFixture.TestSecretByteArray.Aggregate("", (current, b) => current + (b + ",")) + "]");
            Assert.AreEqual(kp.PublicKey.ToString(), KeypairFixture.TestPublicKey);
            Assert.AreEqual(kpSecret.PublicKey.ToString(), KeypairFixture.TestPublicKey);
        }

        [Test]
        public void TestImportExistingSecretKey()
        {
            var kp = Keypair.FromSecretKey(KeypairFixture.TestSecretKey);
            var kpSecret = Keypair.FromSecret(KeypairFixture.TestSecretKey);
            Assert.AreEqual(kp.PublicKey.ToString(), KeypairFixture.TestPublicKey);
            Assert.AreEqual(kpSecret.PublicKey.ToString(), KeypairFixture.TestPublicKey);
        }

        [Test]
        public void TestImportMnemonic12()
        {
            var kp = Keypair.FromMnemonic(KeypairFixture.TestMnemonic12);
            var kpSecret = Keypair.FromSecret(KeypairFixture.TestMnemonic12);

            Assert.AreEqual(kp.PublicKey.ToString(), KeypairFixture.TestMnemonic12Keypair.PublicKey.ToString());
            Assert.AreEqual(kpSecret.PublicKey.ToString(), KeypairFixture.TestMnemonic12Keypair.PublicKey.ToString());
            Assert.AreEqual(kp.SecretKey.ToString(), KeypairFixture.TestMnemonic12Keypair.SecretKey.ToString());
            Assert.AreEqual(kpSecret.SecretKey.ToString(), KeypairFixture.TestMnemonic12Keypair.SecretKey.ToString());
            Assert.AreEqual(kp.Mnemonic.ToString(), KeypairFixture.TestMnemonic12Keypair.Mnemonic.ToString());
            Assert.AreEqual(kpSecret.Mnemonic.ToString(), KeypairFixture.TestMnemonic12Keypair.Mnemonic.ToString());
        }

        [Test]
        public void TestImportMnemonic24()
        {
            var kp = Keypair.FromMnemonic(KeypairFixture.TestMnemonic24);
            var kpSecret = Keypair.FromSecret(KeypairFixture.TestMnemonic24);

            Assert.AreEqual(kp.PublicKey.ToString(), KeypairFixture.TestMnemonic24Keypair.PublicKey.ToString());
            Assert.AreEqual(kpSecret.PublicKey.ToString(), KeypairFixture.TestMnemonic24Keypair.PublicKey.ToString());
            Assert.AreEqual(kp.SecretKey.ToString(), KeypairFixture.TestMnemonic24Keypair.SecretKey.ToString());
            Assert.AreEqual(kpSecret.SecretKey.ToString(), KeypairFixture.TestMnemonic24Keypair.SecretKey.ToString());
            Assert.AreEqual(kp.Mnemonic.ToString(), KeypairFixture.TestMnemonic24Keypair.Mnemonic.ToString());
            Assert.AreEqual(kpSecret.Mnemonic.ToString(), KeypairFixture.TestMnemonic24Keypair.Mnemonic.ToString());
        }

        [Test]
        public void TestImportMnemonic12WrongInput()
        {
            var keypairs = Keypair.FromMnemonicSet(KeypairFixture.TestMnemonic12, 10, 1);
            Assert.AreEqual(keypairs.Length, 1);
        }

        [Test]
        public void TestImportMnemonicSet12()
        {
            var keypairSet = Keypair.FromMnemonicSet(KeypairFixture.TestMnemonic12, 0, 10);
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
            var keypairSet = Keypair.FromMnemonicSet(KeypairFixture.TestMnemonic24, 0, 10);
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