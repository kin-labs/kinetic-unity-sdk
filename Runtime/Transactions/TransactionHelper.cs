using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Asn1.Ocsp;
using Solana.Unity.Programs;
using Solana.Unity.Rpc.Builders;
using Solana.Unity.Rpc.Models;
using Solana.Unity.Wallet;
using Solana.Unity.Rpc.Utilities;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Transactions
{
    public static class TransactionHelper
    {
        public static byte[] CreateAccountTransaction(
            bool? addMemo, decimal? appIndex, string latestBlockhash, 
            string mintFeePayer, string mintPublicKey, Keypair signer)
        {
            // Create objects from Response
            var mintKey = new PublicKey(mintPublicKey);
            var feePayerKey = new PublicKey(mintFeePayer);

            // Get AssociatedTokenAccount
            var associatedTokenAccount = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(signer.PublicKey, mintKey);

            // Create Transaction
            var transaction = new Transaction
            {
                RecentBlockHash = latestBlockhash,
                FeePayer = feePayerKey,
                Instructions = new List<TransactionInstruction>(),
                Signatures = new List<SignaturePubKeyPair>
                {
                    new()
                    {
                        PublicKey = feePayerKey,
                        Signature = new byte[TransactionBuilder.SignatureLength]
                    }
                }
            };

            if (addMemo is not null && addMemo.Value)
            {
                // Create Memo Instruction for KRE Ingestion - Must be Memo Program v1, not v2
                var appIndexMemoInstruction = MemoProgram.NewMemo(signer.PublicKey, appIndex.ToString());
                transaction.Instructions.Add(appIndexMemoInstruction);
            }

            transaction.Instructions.Add(
                AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(feePayerKey, signer.PublicKey, mintKey));
            transaction.Instructions.Add(
                TokenProgram.SetAuthority(associatedTokenAccount, AuthorityType.CloseAccount, signer.PublicKey, feePayerKey));


            // Sign and Serialize Transaction
            transaction.PartialSign(signer.Solana);

            return transaction.Serialize();
            
            
        }
    }
}