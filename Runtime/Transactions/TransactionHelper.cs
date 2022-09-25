using System;
using System.Collections.Generic;
using Kinetic.Sdk.KinMemo;
using Solana.Unity.Programs;
using Solana.Unity.Rpc.Builders;
using Solana.Unity.Rpc.Models;
using Solana.Unity.Wallet;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Transactions
{
    public static class TransactionHelper
    {

        public static Transaction CreateAccountTransaction(
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
                var memoInstruction = KineticMemo(signer.PublicKey, appIndex, type:TransactionType.None);
                transaction.Instructions.Add(memoInstruction);
            }

            transaction.Instructions.Add(
                AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(feePayerKey, signer.PublicKey, mintKey));
            transaction.Instructions.Add(
                TokenProgram.SetAuthority(associatedTokenAccount, AuthorityType.CloseAccount, signer.PublicKey, feePayerKey));


            // Partially sign the transaction
            transaction.PartialSign(signer.Solana);

            return transaction;
        }

        
        public static Transaction MakeTransferTransaction(
            bool? addMemo, string amount, int? appIndex, string destination, 
            string latestBlockhash, 
            int mintDecimals, string mintFeePayer, string mintPublicKey, 
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
            
            if (addMemo is not null && addMemo.Value)
            {
                // Create Memo Instruction for KRE Ingestion - Must be Memo Program v1, not v2
                var memoInstruction = KineticMemo(signer.PublicKey, appIndex, type:type);
                transaction.Instructions.Add(memoInstruction);
            }

            if (senderCreate)
            {
                transaction.Instructions.Add(
                    AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(
                        feePayerKey, new PublicKey(destination), mintKey));
            }
            
            var amountWithDecimals =
                ulong.Parse(amount) * (ulong)Math.Pow(10, (double)mintDecimals);
            transaction.Instructions.Add(
                TokenProgram.TransferChecked(
                    ownerTokenAccount, 
                    destinationTokenAccount, 
                    amountWithDecimals, 
                    mintDecimals,
                    signer.PublicKey,
                    mintKey
                    )
            );
    
            // Partially sign the transaction
            transaction.PartialSign(signer);

            return transaction;
        }
        
        /// <summary>
        /// Method to format a correct Kin Memo Instruction based on appIndex and Type
        /// </summary>
        /// <param name="signer"></param>
        /// <param name="appIndex"></param>
        /// <param name="memo"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static TransactionInstruction KineticMemo(
            PublicKey signer, decimal? appIndex, string memo = null, TransactionType type = TransactionType.None)
        {
            var memoBytes = KinMemo.KinMemo.CreateKinMemo(appIndex, memo, type).Buffer;
            return MemoProgram.NewMemo(signer, Convert.ToBase64String(memoBytes));
        }
    }
}