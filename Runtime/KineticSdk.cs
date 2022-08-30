using System;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Kinetic.Sdk.Helpers;
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
        private readonly DefaultApi _defaultApi;
        private readonly TransactionApi _transactionApi;
        
        private readonly KineticSdkConfig _sdkConfig;
        
        public Solana Solana;
        public AppConfig Config;

        private KineticSdk(KineticSdkConfig config)
        {
            _sdkConfig = config;
            var basePath = config.Endpoint.ParseEndpoint();
            
            _accountApi = new AccountApi(basePath);
            _airdropApi = new AirdropApi(basePath);
            _appApi = new AppApi(basePath);
            _defaultApi = new DefaultApi(basePath);
            _transactionApi = new TransactionApi(basePath);
        }

        private AppConfig Init()
        {
            try
            {
                Config = _appApi.GetAppConfig(_sdkConfig.Environment, _sdkConfig.Index);
                _sdkConfig.SolanaRpcEndpoint = _sdkConfig.SolanaRpcEndpoint != null
                    ? _sdkConfig.SolanaRpcEndpoint.GetSolanaRpcEndpoint() 
                    : Config.Environment.Cluster.Endpoint.GetSolanaRpcEndpoint();
                Solana = new Solana(_sdkConfig.SolanaRpcEndpoint, _sdkConfig.Logger);
                _sdkConfig?.Logger?.Log(
                    $"KineticSdk: endpoint '{_sdkConfig.Endpoint}', " +
                    $"environment '{_sdkConfig.Environment}'," +
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
        
    }
}