using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Kinetic.Sdk.Configurations;
using Kinetic.Sdk.Helpers;
using Kinetic.Sdk.KinMemo;
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
        
        public readonly KineticSdkConfig SdkConfig;
        private readonly KineticSdkInternal _sdkInternal;

        public Solana Solana { get; private set; }
        public AppConfig Config { get; private set; }

        private KineticSdk(KineticSdkConfig config)
        {
            SdkConfig = config;
            _sdkInternal = new KineticSdkInternal(config);
        }
        
        #region Utility

        public BalanceResponse GetBalanceSync(string account)
        {
            return _sdkInternal.GetBalance(account);
        }
        
        public async Task<BalanceResponse> GetBalance(string account){
            return await Task.Run(()=> GetBalanceSync(account));
        }
        
        public string GetExplorerUrl(string path)
        {
            return Config.Environment.Explorer.Replace("{path}", path);
        }
        
        
        public List<HistoryResponse> GetHistorySync(string account, string mint = null)
        {
            return _sdkInternal.GetHistory(account, mint);
        }
        
        public async Task<List<HistoryResponse>> GetHistory(string account, string mint = null){
            return await Task.Run(()=> GetHistorySync(account, mint));
        }
        
        public GetTransactionResponse GetTransactionSync(string signature)
        {
            return _sdkInternal.GetTransaction(signature);
        }
        
        public async Task<GetTransactionResponse> GetTransaction(string signature) {
            return await Task.Run(()=> GetTransactionSync(signature));
        }
        
        
        public List<string> GetTokenAccountsSync(string account, string mint = null)
        {
            return _sdkInternal.GetTokenAccounts(account, mint);
        }
        
        public async Task<List<string>> GetTokenAccounts(string account, string mint = null){
            return await Task.Run(()=> GetTokenAccountsSync(account, mint));
        }
        
        public RequestAirdropResponse RequestAirdropSync(string account, string amount,
            Commitment commitment = Commitment.Finalized, string mint = null)
        {
            return _sdkInternal.RequestAirdrop(account, amount, commitment, mint);
        }
        
        public async Task<RequestAirdropResponse> RequestAirdrop(string account, string amount,
            Commitment commitment = Commitment.Finalized, string mint = null){
            return await Task.Run(()=> RequestAirdropSync(account, amount, commitment, mint));
        }


        #endregion
        
        #region Transactions

        public Transaction CreateAccountSync(Keypair owner, string mint = null, Commitment commitment = default)
        {
            return _sdkInternal.CreateAccount(owner, mint, commitment);
        }
        
        public async Task<Transaction> CreateAccount(Keypair owner, string mint = null,
            Commitment commitment = Commitment.Confirmed){
            return await Task.Run(()=> CreateAccountSync(owner, mint, commitment));
        }

        public Transaction MakeTransferSync(Keypair owner, string amount, string destination, string mint = null,
            string referenceId = null, string referenceType = null, bool senderCreate = false,
            Commitment commitment = Commitment.Confirmed, TransactionType type = TransactionType.None)
        {
            return _sdkInternal.MakeTransfer(owner, amount, destination, mint, referenceId, referenceType,
                senderCreate, commitment, type);
        }
        
        public async Task<Transaction> MakeTransfer(Keypair owner, string amount, string destination, 
                string mint = null, string referenceId = null, string referenceType = null, bool senderCreate = false,
                Commitment commitment = Commitment.Confirmed, TransactionType type = TransactionType.None){
            return await Task.Run(()=> 
                MakeTransferSync(owner, amount, destination, mint, referenceId, referenceType, senderCreate,
                    commitment, type));
        }

        #endregion
        
        #region Initialization

        private AppConfig Init()
        {
            try
            {
                Config = _sdkInternal.GetAppConfig(SdkConfig.Environment, SdkConfig.Index);
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

        public static KineticSdk SetupSync(KineticSdkConfig config)
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
        
        public static async Task<KineticSdk> Setup(KineticSdkConfig config)
        {
            return await Task.Run(()=> SetupSync(config));
        }
        
        #endregion
    }
    
}