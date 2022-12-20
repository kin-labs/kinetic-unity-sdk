using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kinetic.Sdk.Helpers;
using Kinetic.Sdk.Interfaces;
using Kinetic.Sdk.Transactions;
using Model;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Kinetic.Sdk
{
    /// <summary>
    ///     The KineticSdk is the main entry point and handles communication with the Kinetic API
    /// </summary>
    public class KineticSdk
    {
        private readonly KineticSdkInternal _sdkInternal;

        public readonly KineticSdkConfig SdkConfig;

        private KineticSdk(KineticSdkConfig config)
        {
            SdkConfig = config;
            _sdkInternal = new KineticSdkInternal(config);
        }

        public Solana Solana { get; private set; }

        // public AppConfig Config { get; private set; }
        // getter function for the KineticSdkConfig
        public AppConfig Config()
        {
            return _sdkInternal.AppConfig;
        }

        #region Utility


        public AccountInfo GetAccountInfoSync(string account, Commitment? commitment = null)
        {
            return _sdkInternal.GetAccountInfo(account, commitment);
        }

        public async Task<AccountInfo> GetAccountInfo(string account, Commitment? commitment = null )
        {
            return await Task.Run(() => GetAccountInfoSync(account, commitment));
        }

        public BalanceResponse GetBalanceSync(string account, Commitment? commitment = null)
        {
            return _sdkInternal.GetBalance(account, commitment);
        }

        public async Task<BalanceResponse> GetBalance(string account, Commitment? commitment = null)
        {
            return await Task.Run(() => GetBalanceSync(account, commitment));
        }

        public string GetExplorerUrl(string path)
        {
            return _sdkInternal.AppConfig.Environment.Explorer.Replace("{path}", path);
        }


        public List<HistoryResponse> GetHistorySync(string account, string mint = null, Commitment? commitment = null)
        {
            return _sdkInternal.GetHistory(account, mint, commitment);
        }

        public async Task<List<HistoryResponse>> GetHistory(string account, string mint = null, Commitment? commitment = null)
        {
            return await Task.Run(() => GetHistorySync(account, mint, commitment));
        }

        public GetTransactionResponse GetTransactionSync(string signature, Commitment? commitment = null)
        {
            return _sdkInternal.GetTransaction(signature, commitment);
        }

        public async Task<GetTransactionResponse> GetTransaction(string signature, Commitment? commitment = null)
        {
            return await Task.Run(() => GetTransactionSync(signature, commitment));
        }


        public List<string> GetTokenAccountsSync(
            string account,
            string mint = null,
            Commitment? commitment = null)
        {
            return _sdkInternal.GetTokenAccounts(account, mint, commitment);
        }

        public async Task<List<string>> GetTokenAccounts(
            string account,
            string mint = null,
            Commitment? commitment = null)
        {
            return await Task.Run(() => GetTokenAccountsSync(account, mint, commitment));
        }

        public RequestAirdropResponse RequestAirdropSync(
            string account,
            string amount,
            string mint = null,
            Commitment? commitment = null
            )
        {
            return _sdkInternal.RequestAirdrop(account, amount, mint, commitment);
        }

        public async Task<RequestAirdropResponse> RequestAirdrop(
            string account,
            string amount,
            string mint = null,
            Commitment? commitment = null
        )
        {
            return await Task.Run(() => RequestAirdropSync(account, amount, mint, commitment));
        }

        #endregion

        #region Transactions

        public Transaction CloseAccountSync(
            string account,
            string mint = null,
            string referenceId = null,
            string referenceType = null,
            Commitment? commitment = null
        )
        {
            return _sdkInternal.CloseAccount(account, mint, referenceId, referenceType, commitment);
        }

        public async Task<Transaction> CloseAccount(
            string account,
            string mint = null,
            string referenceId = null,
            string referenceType = null,
            Commitment? commitment = null
        )
        {
            return await Task.Run(() => CloseAccountSync(account, mint, referenceId, referenceType, commitment));
        }

        public Transaction CreateAccountSync(
            Keypair owner,
            string mint = null,
            string referenceId = null,
            string referenceType = null,
            Commitment? commitment = null
        )
        {
            return _sdkInternal.CreateAccount(owner, mint, referenceId, referenceType, commitment);
        }

        public async Task<Transaction> CreateAccount(
            Keypair owner,
            string mint = null,
            string referenceId = null,
            string referenceType = null,
            Commitment? commitment = null
        )
        {
            return await Task.Run(() => CreateAccountSync(owner, mint, referenceId, referenceType, commitment));
        }

        public Transaction MakeTransferSync(
            Keypair owner,
            string amount,
            string destination,
            string mint = null,
            string referenceId = null,
            string referenceType = null,
            bool senderCreate = false,
            TransactionType type = TransactionType.None,
            Commitment? commitment = null
        )
        {
            return _sdkInternal.MakeTransfer(owner, amount, destination, mint, referenceId, referenceType,
                senderCreate, type, commitment);
        }

        public async Task<Transaction> MakeTransfer(
            Keypair owner,
            string amount,
            string destination,
            string mint = null,
            string referenceId = null,
            string referenceType = null,
            bool senderCreate = false,
            TransactionType type = TransactionType.None,
            Commitment? commitment = null
        )
        {
            return await Task.Run(() =>
                MakeTransferSync(owner, amount, destination, mint, referenceId, referenceType, senderCreate, type, commitment));
        }

        #endregion

        #region Initialization

        private AppConfig Init()
        {
            // Error if SdkConfig is not set
            if (SdkConfig == null)
            {
                throw new Exception("SdkConfig is not set. Please use the setup method to initialize the SDK.");
            }
            try
            {
                SdkConfig!.Logger?.Log("KineticSdk: initializing");
                var config = _sdkInternal.GetAppConfig();
                SdkConfig!.SolanaRpcEndpoint = SdkConfig.SolanaRpcEndpoint != null
                    ? SdkConfig.SolanaRpcEndpoint.GetSolanaRpcEndpoint()
                    : config.Environment.Cluster.Endpoint.GetSolanaRpcEndpoint();
                Solana = new Solana(SdkConfig.SolanaRpcEndpoint, SdkConfig.Logger);
                SdkConfig?.Logger?.Log(
                    $"KineticSdk: endpoint '{SdkConfig.Endpoint}', " +
                    $"environment '{SdkConfig.Environment}'," +
                    $" index: {config.App.Index}"
                );
                return config;
            }
            catch (Exception e)
            {
                Debug.LogError("Error initializing Server." + e.Message);
                throw;
            }
        }

        public static KineticSdk SetupSync(KineticSdkConfig config)
        {
            var sdk = new KineticSdk(config: ValidateKineticSdkConfig.Validate(config));
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
            return await Task.Run(() => SetupSync(config));
        }

        #endregion
    }
}