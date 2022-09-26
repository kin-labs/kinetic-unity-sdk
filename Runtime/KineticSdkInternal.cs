using System;
using System.Collections.Generic;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Kinetic.Sdk.Helpers;
using Kinetic.Sdk.Interfaces;
using Kinetic.Sdk.Transactions;
using Solana.Unity.Rpc.Types;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk
{
    public class KineticSdkInternal
    {
        private readonly AccountApi _accountApi;
        private readonly AirdropApi _airdropApi;
        private readonly AppApi _appApi;

        private readonly KineticSdkConfig _sdkConfig;
        private readonly TransactionApi _transactionApi;

        internal KineticSdkInternal(KineticSdkConfig config)
        {
            _sdkConfig = config;
            var basePath = config.Endpoint;

            _accountApi = new AccountApi(basePath);
            _airdropApi = new AirdropApi(basePath);
            _appApi = new AppApi(basePath);
            _transactionApi = new TransactionApi(basePath);
        }

        public AppConfig AppConfig { get; private set; }

        #region Utils

        private PreTransaction PrepareTransaction(string mint)
        {
            if (AppConfig is null) throw new Exception("AppConfig not initialized");
            mint ??= AppConfig.Mint.PublicKey;
            var found = AppConfig.Mints.Find(item => item.PublicKey == mint);
            if (found is null) throw new Exception("Mint not found");

            var latestBlockhashResponse =
                _transactionApi.GetLatestBlockhash(AppConfig.Environment.Name, AppConfig.App.Index);

            return new PreTransaction
            {
                MintDecimals = found.Decimals.GetValueOrDefault(0),
                MintPublicKey = found.PublicKey,
                MintFeePayer = found.FeePayer,
                LatestBlockhash = latestBlockhashResponse.Blockhash,
                LastValidBlockHeight = latestBlockhashResponse.LastValidBlockHeight.GetValueOrDefault(0)
            };
        }

        #endregion

        #region Utility

        public AppConfig GetAppConfig(string environment, int? index)
        {
            AppConfig = _appApi.GetAppConfig(_sdkConfig.Environment, _sdkConfig.Index);
            return AppConfig;
        }

        public BalanceResponse GetBalance(string account)
        {
            if (AppConfig is null) throw new Exception("AppConfig not initialized");

            return _accountApi.GetBalance(
                AppConfig.Environment.Name,
                AppConfig.App.Index,
                account
            );
        }

        public List<HistoryResponse> GetHistory(string account, string mint = null)
        {
            if (AppConfig is null) throw new Exception("AppConfig not initialized");
            mint ??= AppConfig.Mint.PublicKey;
            return _accountApi.GetHistory(AppConfig.Environment.Name, AppConfig.App.Index, account, mint);
        }

        public GetTransactionResponse GetTransaction(string signature)
        {
            if (AppConfig is null) throw new Exception("AppConfig not initialized");
            return _transactionApi
                .GetTransaction(AppConfig.Environment.Name, AppConfig.App.Index, signature);
        }

        public List<string> GetTokenAccounts(string account, string mint = null)
        {
            if (AppConfig is null) throw new Exception("AppConfig not initialized");
            mint ??= AppConfig.Mint.PublicKey;

            return _accountApi
                .GetTokenAccounts(AppConfig.Environment.Name, AppConfig.App.Index, account, mint);
        }

        public RequestAirdropResponse RequestAirdrop(string account, string amount,
            Commitment commitment = Commitment.Finalized, string mint = null)
        {
            if (AppConfig is null) throw new Exception("AppConfig not initialized");
            mint ??= AppConfig.Mint.PublicKey;

            return _airdropApi
                .RequestAirdrop(
                    new RequestAirdropRequest
                    {
                        Account = account,
                        Amount = amount,
                        Commitment = commitment.ToString(),
                        Environment = AppConfig.Environment.Name,
                        Index = AppConfig.App.Index,
                        Mint = mint
                    }
                );
        }

        #endregion

        #region Transactions

        public Transaction CreateAccount(Keypair owner, string mint = null,
            Commitment commitment = Commitment.Confirmed)
        {
            if (AppConfig is null) throw new Exception("AppConfig not initialized");

            mint ??= AppConfig.Mint.PublicKey;

            var pt = PrepareTransaction(mint);

            var tx = TransactionHelper.CreateAccountTransaction(
                AppConfig.Mint.AddMemo,
                AppConfig.App.Index,
                pt.LatestBlockhash,
                pt.MintFeePayer,
                pt.MintPublicKey,
                owner);

            var request = new CreateAccountRequest
            {
                Commitment = commitment.ToString(),
                Environment = AppConfig.Environment.Name,
                Index = AppConfig.App.Index,
                Mint = mint,
                Tx = tx.Serialize(),
                LastValidBlockHeight = pt.LastValidBlockHeight
            };

            return _accountApi.CreateAccount(request);
        }

        public Transaction MakeTransfer(Keypair owner, string amount, string destination, string mint = null,
            string referenceId = null, string referenceType = null, bool senderCreate = false,
            Commitment commitment = Commitment.Confirmed, TransactionType type = TransactionType.None)
        {
            if (AppConfig is null) throw new Exception("AppConfig not initialized");
            if (AppConfig.Mints.Find(m => m.PublicKey == destination) != null)
                throw new Exception("Transfers to a mint are not allowed.");
            mint ??= AppConfig.Mint.PublicKey;
            var pt = PrepareTransaction(mint);

            var account = GetTokenAccounts(destination, mint);

            if (account.Count == 0 && !senderCreate) throw new Exception("Destination account doesn't exist.");

            var tx = TransactionHelper.MakeTransferTransaction(
                AppConfig.Mint.AddMemo,
                amount,
                AppConfig.App.Index,
                destination,
                pt.LatestBlockhash,
                pt.MintDecimals,
                pt.MintFeePayer,
                pt.MintPublicKey,
                owner.Solana,
                account?.Count == 0 && senderCreate,
                type
            );

            var mkTransfer = new MakeTransferRequest
            {
                Commitment = commitment.ToString(),
                Environment = AppConfig.Environment.Name,
                Index = AppConfig.App.Index,
                LastValidBlockHeight = pt.LastValidBlockHeight,
                Mint = mint,
                ReferenceId = referenceId,
                ReferenceType = referenceType,
                Tx = tx.Serialize()
            };

            return _transactionApi.MakeTransfer(mkTransfer);
        }

        #endregion
    }
}