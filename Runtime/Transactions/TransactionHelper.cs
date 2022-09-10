using System.Collections.Generic;
using System.IO;
using Kinetic.Sdk.Helpers;
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
                var memoInstruction = KineticMemo(signer, appIndex);
                transaction.Instructions.Add(memoInstruction);
            }

            transaction.Instructions.Add(
                AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(feePayerKey, signer.PublicKey, mintKey));
            transaction.Instructions.Add(
                TokenProgram.SetAuthority(associatedTokenAccount, AuthorityType.CloseAccount, signer.PublicKey, feePayerKey));


            // Sign and Serialize Transaction
            transaction.PartialSign(signer.Solana);

            return transaction.Serialize();
            
            
        }

        

        public static byte[] MakeTransferTransaction(
            bool? addMemo, string amount, int? appIndex, string destination, 
            decimal? lastValidBlockHeight, string latestBlockhash, 
            decimal? mintDecimals, string mintFeePayer, string mintPublicKey, 
            Account signer, bool senderCreate, TransactionType type)
        {
            // Create objects from Response
            var mintKey = new PublicKey(mintPublicKey);
            var feePayerKey = new PublicKey(mintFeePayer);

            // Get TokenAccount from Owner and Destination
            var ownerTokenAccount = 
                AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(signer.PublicKey, mintKey);
            var destinationTokenAccount = 
                AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(new PublicKey(destination), mintKey);
            
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
            /*
            if (addMemo is not null && addMemo.Value)
            {
                // Create Memo Instruction for KRE Ingestion - Must be Memo Program v1, not v2
                var memoInstruction = KineticMemo(appIndex, type);
                transaction.Instructions.Add(memoInstruction);
            }
           
            if (addMemo) {
                instructions.push(
                    generateKinMemoInstruction({
                    appIndex,
                    type,
                }),
                )
            }

            if (senderCreate)
            {
                transaction.Instructions.Add(
                    AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(feePayerKey, destinationTokenAccount,
                        new PublicKey(destination), mintKey));
            }

            transaction.Instructions.Add(
                    createTransferInstruction(
                            ownerTokenAccount,
                            destinationTokenAccount,
                            signer.publicKey,
                            addDecimals(amount, mintDecimals).toNumber(),
                        [],
                    TOKEN_PROGRAM_ID,
                ),
                )*/

            // Partially sign the transaction
            transaction.PartialSign(signer);

            return transaction.Serialize();
        }
        
        private static TransactionInstruction KineticMemo(Keypair signer, decimal? appIndex)
        {
            return MemoProgram.NewMemo(signer.PublicKey, appIndex.ToString());
        }
    }
}