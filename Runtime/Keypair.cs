using System.Collections.Generic;
using System.Linq;
using Chaos.NaCl;
using Solana.Unity.Wallet;
using Solana.Unity.Wallet.Bip39;
using Solana.Unity.Wallet.Utilities;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk
{

    /// <summary>
    /// The keypair package is a wrapper around the Solana Keypair class and with additional support for mnemonic phrases.
    /// It exports a class called Keypair.
    /// </summary>
    public class Keypair
    {
        /// <summary>
        /// The Solana Account
        /// </summary>
        public Account Solana { get; }

        /// <summary>
        /// The mnemonic
        /// </summary>
        public Mnemonic Mnemonic { get; set; }

        /// <summary>
        /// Solana Public Key
        /// </summary>
        public PublicKey PublicKey => Solana.PublicKey;

        /// <summary>
        /// Solana Secret Key
        /// </summary>
        public PrivateKey SecretKey => Solana.PrivateKey;

        /// <summary>
        /// Create a Keypair
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="secretKey"></param>
        /// <param name="mnemonic"></param>
        public Keypair(string publicKey, string secretKey, string mnemonic = null)
        {
            Solana = new Account(secretKey, publicKey);
            Mnemonic = new Mnemonic(mnemonic);
        }

        /// <summary>
        /// Create a Keypair from an Account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="mnemonic"></param>
        private Keypair(Account account, Mnemonic mnemonic = null)
        {
            Solana = account;
            Mnemonic = mnemonic;
        }


        /// <summary>
        /// Derives the first Keypair using the standard Solana derivation path
        /// </summary>
        /// <param name="mnemonic"></param>
        /// <returns></returns>
        public static Keypair FromMnemonic(string mnemonic)
        {
            return FromMnemonicSet(mnemonic, 0, 1)[0];
        }


        /// <summary>
        /// Derives a list of Keypair using the standard Solana derivation path
        /// </summary>
        /// <param name="mnemonic"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Keypair[] FromMnemonicSet(string mnemonic, int from = 0, int to = 1)
        {
            var keypairs = new List<Keypair>();
            var mnem = new Mnemonic(mnemonic);
            var seed = mnem.DeriveSeed();
            foreach (var idx in Enumerable.Range(@from, to))
            {
                var path = "m/44'/501'/x'/0'".Replace("x", idx.ToString());
                var kp = Derive(seed, path);
                kp.Mnemonic = mnem;
                keypairs.Add(kp);
            }

            return keypairs.ToArray();
        }

        /// <summary>
        /// Returns an instance of Keypair from a secret key
        /// </summary>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static Keypair FromSecretKey(string secretKey)
        {
            var wallet = new Wallet(new PrivateKey(secretKey).KeyBytes, "", SeedMode.Bip39);
            return new Keypair(wallet.Account);
        }

        /// <summary>
        /// Returns an instance of Keypair from a Byte Array
        /// </summary>
        /// <param name="secretByteArray"></param>
        /// <returns></returns>
        public static Keypair FromByteArray(byte[] secretByteArray)
        {
            var wallet = new Wallet(secretByteArray, "", SeedMode.Bip39);
            return new Keypair(wallet.Account);
        }

        /// <summary>
        /// Generates a random keypair
        /// </summary>
        /// <returns></returns>
        public static Keypair Random()
        {
            var mnemonic = GenerateMnemonic();
            return FromMnemonic(mnemonic);
        }

        /// <summary>
        /// Generates a random mnemonic
        /// </summary>
        /// <param name="wordCount"></param>
        /// <returns></returns>
        public static string GenerateMnemonic(WordCount wordCount = WordCount.Twelve)
        {
            return new Mnemonic(WordList.English, wordCount).ToString();
        }

        /// <summary>
        /// Takes a seed and path as an input and derive a Keypair
        /// </summary>
        /// <param name="seed"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static Keypair Derive(byte[] seed, string path)
        {
            var ed25519Bip32 = new Ed25519Bip32(seed);
            var (account, _) = ed25519Bip32.DerivePath(path);
            return FromSeed(account);
        }

        /// <summary>
        /// Takes a seed as input and Returns an instance of Keypair
        /// </summary>
        /// <param name="seed"></param>
        /// <returns></returns>
        private static Keypair FromSeed(byte[] seed)
        {
            var privateKey = Ed25519.ExpandedPrivateKeyFromSeed(seed);
            return FromSecretKey(Encoders.Base58.EncodeData(privateKey));
        }
    }
}