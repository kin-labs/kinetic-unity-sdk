using System;
using System.Collections.Generic;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Kinetic.Sdk.Configurations;
using Kinetic.Sdk.Helpers;
using Kinetic.Sdk.KinMemo;
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
        private readonly TransactionApi _transactionApi;

        private readonly KineticSdkConfig _sdkConfig;
        private AppConfig Config { get; set; }

        internal KineticSdkInternal(KineticSdkConfig config)
        {
            _sdkConfig = config;
            var basePath = config.Endpoint;
            
            _accountApi = new AccountApi(basePath);
            _airdropApi = new AirdropApi(basePath);
            _appApi = new AppApi(basePath);
            _transactionApi = new TransactionApi(basePath);
        }
        
        #region Utility
        
        public AppConfig GetAppConfig(string environment, int? index){
            Config = _appApi.GetAppConfig(_sdkConfig.Environment, _sdkConfig.Index);
            return Config;
        }

        public BalanceResponse GetBalance(string account)
        {
            if (Config is null)
            {
                throw new Exception("AppConfig not initialized");
            }

            return _accountApi.GetBalance(
                Config.Environment.Name,
                Config.App.Index,
                account
            );
        }

        public List<HistoryResponse> GetHistory(string account, string mint = null) 
        {
            if (Config is null)
            {
                throw new Exception("AppConfig not initialized");
            }
            mint ??= Config.Mint.PublicKey;
            return _accountApi.GetHistory(Config.Environment.Name, Config.App.Index, account, mint);
        }

        public GetTransactionResponse GetTransaction(string signature) 
        {
            if (Config is null)
            {
                throw new Exception("AppConfig not initialized");
            }
            return _transactionApi
                .GetTransaction(Config.Environment.Name, Config.App.Index, signature);
        }
        
        public List<string> GetTokenAccounts(string account, string mint = null){
            if (Config is null)
            {
                throw new Exception("AppConfig not initialized");
            }
            mint ??= Config.Mint.PublicKey;

            return _accountApi
                .GetTokenAccounts(this.Config.Environment.Name, this.Config.App.Index, account, mint);
        }

        public RequestAirdropResponse RequestAirdrop(string account, string amount,
            Commitment commitment = Commitment.Finalized, string mint = null){
            if (Config is null)
            {
                throw new Exception("AppConfig not initialized");
            }
            mint ??= Config.Mint.PublicKey;

            return _airdropApi
                .RequestAirdrop(
                    new RequestAirdropRequest()
                    {
                        Account = account,
                        Amount = amount,
                        Commitment = commitment.ToString(),
                        Environment = Config.Environment.Name,
                        Index = Config.App.Index,
                        Mint = mint,
                    }
                );
        }


        #endregion
        
        #region Transactions

        public Transaction CreateAccount(Keypair owner, string mint = null, Commitment commitment = Commitment.Confirmed)
        {
            if (Config is null)
            {
                throw new Exception("AppConfig not initialized");
            }

            mint ??= Config.Mint.PublicKey;

            var pt = PrepareTransaction(mint);
            
            var tx = TransactionHelper.CreateAccountTransaction(
                Config.Mint.AddMemo,
                appIndex: Config.App.Index,
                pt.LatestBlockhash, 
                pt.MintFeePayer, 
                pt.MintPublicKey,
                owner);

            var request = new CreateAccountRequest
            {
                Commitment = commitment.ToString(), 
                Environment = Config.Environment.Name,
                Index = Config.App.Index,
                Mint = mint,
                Tx = tx
            };

            return _accountApi.CreateAccount(request);
        }

        public Transaction MakeTransfer(Keypair owner, string amount, string destination, string mint = null,
            string referenceId = null, string referenceType = null, bool senderCreate = false,
            Commitment commitment = Commitment.Confirmed, TransactionType type = TransactionType.None)
        {
            if (Config is null)
            {
                throw new Exception("AppConfig not initialized");
            }
            if (Config.Mints.Find(m => m.PublicKey == destination) != null)
            {
                throw new Exception("Transfers to a mint are not allowed.");
            }
            mint ??= Config.Mint.PublicKey;
            var pt = PrepareTransaction(mint);
            
            var account = GetTokenAccounts(account: destination, mint);
            
            if (account.Count == 0 && !senderCreate)
            {
                throw new Exception("Destination account doesn't exist.");
            }

            var tx = TransactionHelper.MakeTransferTransaction(
                addMemo: Config.Mint.AddMemo,
                amount,
                appIndex: Config.App.Index,
                destination,
                pt.LastValidBlockHeight,
                pt.LatestBlockhash,
                pt.MintDecimals,
                pt.MintFeePayer,
                pt.MintPublicKey,
                signer: owner.Solana,
                senderCreate: account?.Count == 0 && senderCreate,
                type: type
            );

            var mkTransfer = new MakeTransferRequest()
            {
                Commitment = commitment.ToString(),
                Environment = Config.Environment.Name,
                Index = Config.App.Index,
                LastValidBlockHeight = (int?) pt.LastValidBlockHeight,
                Mint =  mint,
                ReferenceId = referenceId,
                ReferenceType = referenceType,
                Tx = tx,
            };
            
            return _transactionApi.MakeTransfer(mkTransfer);
        }

        #endregion

        #region Utils
        
        private PreTransaction PrepareTransaction(string mint){
            if (Config is null)
            {
                throw new Exception("AppConfig not initialized");
            }
            mint ??= Config.Mint.PublicKey;
            var found = Config.Mints.Find((item) => item.PublicKey == mint);
            if (found is null)
            {
                throw new Exception("Mint not found");
            }

            var latestBlockhashResponse = _transactionApi.GetLatestBlockhash(Config.Environment.Name, Config.App.Index);

            return new PreTransaction
            {
                MintDecimals = found.Decimals,
                MintPublicKey = found.PublicKey,
                MintFeePayer = found.FeePayer,
                LatestBlockhash = latestBlockhashResponse.Blockhash,
                LastValidBlockHeight = latestBlockhashResponse.LastValidBlockHeight
            };
        }
        
        #endregion
    }
    
}