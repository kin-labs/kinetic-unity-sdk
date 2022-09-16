using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Kinetic.Sdk.Configurations;
using Kinetic.Sdk.Helpers;
using Kinetic.Sdk.KinMemo;
using Kinetic.Sdk.Transactions;
using Solana.Unity.Rpc.Types;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk
{

    /// <summary>
    /// The KineticSdk is the main entry point and handles communication with the Kinetic API
    /// </summary>
    public class KineticSdk
    {
        private readonly AccountApi _accountApi;
        private readonly AirdropApi _airdropApi;
        private readonly AppApi _appApi;
        private readonly TransactionApi _transactionApi;
        
        public readonly KineticSdkConfig SdkConfig;

        public Solana Solana { get; private set; }
        public AppConfig Config { get; private set; }

        private KineticSdk(KineticSdkConfig config)
        {
            SdkConfig = config;
            var basePath = config.Endpoint;
            
            _accountApi = new AccountApi(basePath);
            _airdropApi = new AirdropApi(basePath);
            _appApi = new AppApi(basePath);
            _transactionApi = new TransactionApi(basePath);
        }
        
        #region Utility

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
        
        public async Task<BalanceResponse> GetBalanceAsync(string account){
            return await Task.Run(()=> GetBalance(account));
        }
        
        public string GetExplorerUrl(string path)
        {
            return Config.Environment.Explorer.Replace("{path}", path);
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
        
        public async Task<List<HistoryResponse>> GetHistoryAsync(string account, string mint = null){
            return await Task.Run(()=> GetHistory(account, mint));
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
        
        public async Task<List<string>> GetTokenAccountsAsync(string account, string mint = null){
            return await Task.Run(()=> GetTokenAccounts(account, mint));
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
        
        public async Task<RequestAirdropResponse> RequestAirdropAsync(string account, string amount,
            Commitment commitment = Commitment.Finalized, string mint = null){
            if (Config is null)
            {
                throw new Exception("AppConfig not initialized");
            }
            mint ??= Config.Mint.PublicKey;
            return await Task.Run(()=> RequestAirdrop(account, amount, commitment, mint));
        }


        #endregion
        
        #region Transactions

        public Transaction CreateAccount(Keypair owner, string mint = null, Commitment commitment = default)
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
                //Commitment = commitment, 
                Environment = Config.Environment.Name,
                Index = Config.App.Index,
                Mint = mint,
                Tx = tx
            };

            return _accountApi.CreateAccount(request);
        }
        
        public async Task<Transaction> CreateAccountAsync(Keypair owner, string mint = null,
            Commitment commitment = Commitment.Confirmed){
            return await Task.Run(()=> CreateAccount(owner, mint, commitment));
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
        
        public async Task<Transaction> MakeTransferAsync(Keypair owner, string amount, string destination, 
                string mint = null, string referenceId = null, string referenceType = null, bool senderCreate = false,
                Commitment commitment = Commitment.Confirmed, TransactionType type = TransactionType.None){
            return await Task.Run(()=> 
                MakeTransfer(owner, amount, destination, mint, referenceId, referenceType, senderCreate,
                    commitment, type));
        }

        #endregion
        
        #region Initialization

        private AppConfig Init()
        {
            try
            {
                Config = _appApi.GetAppConfig(SdkConfig.Environment, SdkConfig.Index);
                SdkConfig.SolanaRpcEndpoint = SdkConfig.SolanaRpcEndpoint != null
                    ? SdkConfig.SolanaRpcEndpoint.GetSolanaRpcEndpoint() 
                    : Config.Environment.Cluster.Endpoint.GetSolanaRpcEndpoint();
                Solana = new Solana(SdkConfig.SolanaRpcEndpoint, SdkConfig.Logger);
                SdkConfig?.Logger?.Log(
                    $"KineticSdk: endpoint '{SdkConfig.Endpoint}', " +
                    $"environment '{SdkConfig.Environment}'," +
                    $" index: {Config.App.Index}"
                );
                return Config;
            }
            catch (Exception e)
            {
                Debug.LogError("Error initializing Server." + e.Message);
                throw;
            }
        }

        public static KineticSdk Setup(KineticSdkConfig config)
        {
            var sdk = new KineticSdk(config);
            try
            {
                sdk.Init();
                config.Logger?.Log("KineticSdk: Setup done.");
                return sdk;
            }
            catch (Exception e)
            {
                Debug.LogError("KineticSdk: Error setting up SDK." + e.Message);
                throw;
            }
        }
        
        public static async Task<KineticSdk> SetupAsync(KineticSdkConfig config)
        {
            return await Task.Run(()=> Setup(config));
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