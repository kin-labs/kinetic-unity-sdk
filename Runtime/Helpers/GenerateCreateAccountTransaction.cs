using System.Collections.Generic;
using Kinetic.Sdk.Interfaces;
using Solana.Unity.Programs;
using Solana.Unity.Rpc.Builders;
using Solana.Unity.Rpc.Models;
using Solana.Unity.Wallet;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Transactions
{
    public static class GenerateCreateAccountTransaction
    {
        public static Transaction Generate(
            bool addMemo,
            string blockhash,
            int index,
            string mintFeePayer,
            string mintPublicKey,
            Keypair owner
        )
        {
            // Create objects from Response
            var mintKey = new PublicKey(mintPublicKey);
            var feePayerKey = new PublicKey(mintFeePayer);
            var ownerPublicKey = owner.PublicKey;

            // Get AssociatedTokenAccount
            var associatedTokenAccount =
                AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(ownerPublicKey, mintKey);

            // Create Instructions
            var instructions = new List<TransactionInstruction>();

            // Create Memo Instruction for KRE Ingestion - Must be Memo Program v1, not v2
            if (addMemo.Equals(true))
                instructions.Add(MemoHelper.Create(ownerPublicKey, index, type: TransactionType.None));

            instructions.Add(
                AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(feePayerKey, ownerPublicKey, mintKey));
            instructions.Add(
                TokenProgram.SetAuthority(associatedTokenAccount, AuthorityType.CloseAccount, ownerPublicKey,
                    feePayerKey));

            // Create Transaction
            var transaction = new Transaction
            {
                RecentBlockHash = blockhash,
                FeePayer = feePayerKey,
                Instructions = instructions,
                Signatures = new List<SignaturePubKeyPair>
                {
                    new()
                    {
                        PublicKey = feePayerKey,
                        Signature = new byte[TransactionBuilder.SignatureLength]
                    }
                }
            };

            // Partially sign the transaction
            transaction.PartialSign(owner.Solana);

            return transaction;
        }
    }
}