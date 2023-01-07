using System;
using System.Collections.Generic;
#if !UNITY_WEBGL
using System.Threading.Tasks;
#endif
using Kinetic.Sdk.Helpers;
using Kinetic.Sdk.Interfaces;
using Kinetic.Sdk.Transactions;
using Model;
using UnityEngine;
using Cysharp.Threading.Tasks;

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


        public UniTask<AccountInfo> GetAccountInfoSync(string account, Commitment? commitment = null)
        {
            return _sdkInternal.GetAccountInfo(account, commitment);
        }

        public UniTask<AccountInfo> GetAccountInfo(string account, Commitment? commitment = null )
        {
#if UNITY_WEBGL
            return GetAccountInfoSync(account, commitment);
#else
            return await Task.Run(() => GetAccountInfoSync(account, commitment));
#endif
        }

        public UniTask<BalanceResponse> GetBalanceSync(string account, Commitment? commitment = null)
        {
            return _sdkInternal.GetBalance(account, commitment);
        }

        public UniTask<BalanceResponse> GetBalance(string account, Commitment? commitment = null)
        {
#if UNITY_WEBGL
            return GetBalanceSync(account, commitment);
#else
            return await Task.Run(() => GetBalanceSync(account, commitment));            
#endif
        }

        public string GetExplorerUrl(string path)
        {
            return _sdkInternal.AppConfig.Environment.Explorer.Replace("{path}", path);
        }


        public UniTask<List<HistoryResponse>> GetHistorySync(string account, string mint = null, Commitment? commitment = null)
        {
            return _sdkInternal.GetHistory(account, mint, commitment);
        }

        public UniTask<List<HistoryResponse>> GetHistory(string account, string mint = null, Commitment? commitment = null)
        {
#if UNITY_WEBGL
            return GetHistorySync(account, mint, commitment);
#else
            return await Task.Run(() => GetHistorySync(account, mint, commitment));            
#endif

        }

        public UniTask<GetTransactionResponse> GetTransactionSync(string signature, Commitment? commitment = null)
        {
            return _sdkInternal.GetTransaction(signature, commitment);
        }

        public UniTask<GetTransactionResponse> GetTransaction(string signature, Commitment? commitment = null)
        {
#if UNITY_WEBGL
            return GetTransactionSync(signature, commitment);
#else
            return await Task.Run(() => GetTransactionSync(signature, commitment));            
#endif

        }


        public UniTask<List<string>> GetTokenAccountsSync(
            string account,
            string mint = null,
            Commitment? commitment = null)
        {
            return _sdkInternal.GetTokenAccounts(account, mint, commitment);
        }

        public UniTask<List<string>> GetTokenAccounts(
            string account,
            string mint = null,
            Commitment? commitment = null)
        {
#if UNITY_WEBGL
            return GetTokenAccountsSync(account, mint, commitment);
#else
             return await Task.Run(() => GetTokenAccountsSync(account, mint, commitment));           
#endif

        }

        public UniTask<RequestAirdropResponse> RequestAirdropSync(
            string account,
            string amount,
            string mint = null,
            Commitment? commitment = null
            )
        {
            return _sdkInternal.RequestAirdrop(account, amount, mint, commitment);
        }

        public UniTask<RequestAirdropResponse> RequestAirdrop(
            string account,
            string amount,
            string mint = null,
            Commitment? commitment = null
        )
        {
#if UNITY_WEBGL
            return RequestAirdropSync(account, amount, mint, commitment);
#else
            return await Task.Run(() => RequestAirdropSync(account, amount, mint, commitment));            
#endif

        }

        #endregion

        #region Transactions

        public UniTask<Transaction> CloseAccountSync(
            string account,
            string mint = null,
            string referenceId = null,
            string referenceType = null,
            Commitment? commitment = null
        )
        {
            return _sdkInternal.CloseAccount(account, mint, referenceId, referenceType, commitment);
        }

        public UniTask<Transaction> CloseAccount(
            string account,
            string mint = null,
            string referenceId = null,
            string referenceType = null,
            Commitment? commitment = null
        )
        {
#if UNITY_WEBGL
            return CloseAccountSync(account, mint, referenceId, referenceType, commitment);
#else
            return await Task.Run(() => CloseAccountSync(account, mint, referenceId, referenceType, commitment));            
#endif

        }

        public UniTask<Transaction> CreateAccountSync(
            Keypair owner,
            string mint = null,
            string referenceId = null,
            string referenceType = null,
            Commitment? commitment = null
        )
        {
            return _sdkInternal.CreateAccount(owner, mint, referenceId, referenceType, commitment);
        }

        public UniTask<Transaction> CreateAccount(
            Keypair owner,
            string mint = null,
            string referenceId = null,
            string referenceType = null,
            Commitment? commitment = null
        )
        {
#if UNITY_WEBGL
            return CreateAccountSync(owner, mint, referenceId, referenceType, commitment);
#else
             return await Task.Run(() => CreateAccountSync(owner, mint, referenceId, referenceType, commitment));           
#endif

        }

        public UniTask<Transaction> MakeTransferSync(
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

        public UniTask<Transaction> MakeTransfer(
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
#if UNITY_WEBGL
            return MakeTransferSync(owner, amount, destination, mint, referenceId, referenceType, senderCreate, type, commitment);
#else
            return await Task.Run(() =>
                MakeTransferSync(owner, amount, destination, mint, referenceId, referenceType, senderCreate, type, commitment));            
#endif
        }

        #endregion

        #region Initialization

        private async UniTask<AppConfig> Init()
        {
            Debug.Log("AppConfigInit");
            // Error if SdkConfig is not set
            if (SdkConfig == null)
            {
                throw new Exception("SdkConfig is not set. Please use the setup method to initialize the SDK.");
            }
            try
            {
                SdkConfig!.Logger?.Log("KineticSdk: initializing");
                var config = await _sdkInternal.GetAppConfig();
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

        public static async UniTask<KineticSdk> SetupSync(KineticSdkConfig config)
        {
            Debug.Log("SetupSync");
            var sdk = new KineticSdk(config: ValidateKineticSdkConfig.Validate(config));
            try
            {
                await sdk.Init();
                config.Logger?.Log("KineticSdk: Setup done.");
                return sdk;
            }
            catch (Exception e)
            {
                Debug.LogError("KineticSdk: Error setting up SDK." + e.Message);
                throw;
            }
        }

        public static UniTask<KineticSdk> Setup(KineticSdkConfig config)
        {
            Debug.Log("Prepare Setup task");
#if UNITY_WEBGL
            return SetupSync(config);
#else
            return await Task.Run(() => SetupSync(config));            
#endif

        }

#endregion
    }
}