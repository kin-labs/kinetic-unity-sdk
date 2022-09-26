using System;
using Kinetic.Sdk.Interfaces;
using Solana.Unity.Programs;
using Solana.Unity.Rpc.Models;
using Solana.Unity.Wallet;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk.Transactions
{
    public static class MemoHelper
    {
        /// <summary>
        ///     Method to format a correct Kin Memo Instruction based on index and Type
        /// </summary>
        /// <param name="signer"></param>
        /// <param name="index"></param>
        /// <param name="memo"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TransactionInstruction Create(
            PublicKey signer, decimal? index, string memo = null, TransactionType type = TransactionType.None)
        {
            var memoBytes = KinMemo.CreateKinMemo(index, memo, type).Buffer;
            return MemoProgram.NewMemo(signer, Convert.ToBase64String(memoBytes));
        }
    }
}