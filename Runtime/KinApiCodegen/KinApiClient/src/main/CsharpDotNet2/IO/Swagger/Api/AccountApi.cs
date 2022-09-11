using System;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAccountApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>Transaction</returns>
        Transaction CreateAccount (CreateAccountRequest body);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        void GetAccountInfo (string environment, int? index, string accountId);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="accountId"></param>
        /// <returns>BalanceResponse</returns>
        BalanceResponse GetBalance (string environment, int? index, string accountId);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="accountId"></param>
        /// <param name="mint"></param>
        /// <returns>List&lt;HistoryResponse&gt;</returns>
        List<HistoryResponse> GetHistory (string environment, int? index, string accountId, string mint);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="accountId"></param>
        /// <param name="mint"></param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetTokenAccounts (string environment, int? index, string accountId, string mint);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AccountApi : IAccountApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AccountApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AccountApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>Transaction</returns>
        public Transaction CreateAccount (CreateAccountRequest body)
        {
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling CreateAccount");
    
            var path = "/api/account/create";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateAccount: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateAccount: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Transaction) ApiClient.Deserialize(response.Content, typeof(Transaction), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public void GetAccountInfo (string environment, int? index, string accountId)
        {
            // verify the required parameter 'environment' is set
            if (environment == null) throw new ApiException(400, "Missing required parameter 'environment' when calling GetAccountInfo");
            // verify the required parameter 'index' is set
            if (index == null) throw new ApiException(400, "Missing required parameter 'index' when calling GetAccountInfo");
            // verify the required parameter 'accountId' is set
            if (accountId == null) throw new ApiException(400, "Missing required parameter 'accountId' when calling GetAccountInfo");
    
            var path = "/api/account/info/{environment}/{index}/{accountId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "environment" + "}", ApiClient.ParameterToString(environment));
path = path.Replace("{" + "index" + "}", ApiClient.ParameterToString(index));
path = path.Replace("{" + "accountId" + "}", ApiClient.ParameterToString(accountId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAccountInfo: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAccountInfo: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="accountId"></param>
        /// <returns>BalanceResponse</returns>
        public BalanceResponse GetBalance (string environment, int? index, string accountId)
        {
            // verify the required parameter 'environment' is set
            if (environment == null) throw new ApiException(400, "Missing required parameter 'environment' when calling GetBalance");
            // verify the required parameter 'index' is set
            if (index == null) throw new ApiException(400, "Missing required parameter 'index' when calling GetBalance");
            // verify the required parameter 'accountId' is set
            if (accountId == null) throw new ApiException(400, "Missing required parameter 'accountId' when calling GetBalance");
    
            var path = "/api/account/balance/{environment}/{index}/{accountId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "environment" + "}", ApiClient.ParameterToString(environment));
path = path.Replace("{" + "index" + "}", ApiClient.ParameterToString(index));
path = path.Replace("{" + "accountId" + "}", ApiClient.ParameterToString(accountId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBalance: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBalance: " + response.ErrorMessage, response.ErrorMessage);
    
            return (BalanceResponse) ApiClient.Deserialize(response.Content, typeof(BalanceResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="accountId"></param>
        /// <param name="mint"></param>
        /// <returns>List&lt;HistoryResponse&gt;</returns>
        public List<HistoryResponse> GetHistory (string environment, int? index, string accountId, string mint)
        {
            // verify the required parameter 'environment' is set
            if (environment == null) throw new ApiException(400, "Missing required parameter 'environment' when calling GetHistory");
            // verify the required parameter 'index' is set
            if (index == null) throw new ApiException(400, "Missing required parameter 'index' when calling GetHistory");
            // verify the required parameter 'accountId' is set
            if (accountId == null) throw new ApiException(400, "Missing required parameter 'accountId' when calling GetHistory");
            // verify the required parameter 'mint' is set
            if (mint == null) throw new ApiException(400, "Missing required parameter 'mint' when calling GetHistory");
    
            var path = "/api/account/history/{environment}/{index}/{accountId}/{mint}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "environment" + "}", ApiClient.ParameterToString(environment));
path = path.Replace("{" + "index" + "}", ApiClient.ParameterToString(index));
path = path.Replace("{" + "accountId" + "}", ApiClient.ParameterToString(accountId));
path = path.Replace("{" + "mint" + "}", ApiClient.ParameterToString(mint));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetHistory: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetHistory: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<HistoryResponse>) ApiClient.Deserialize(response.Content, typeof(List<HistoryResponse>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="accountId"></param>
        /// <param name="mint"></param>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetTokenAccounts (string environment, int? index, string accountId, string mint)
        {
            // verify the required parameter 'environment' is set
            if (environment == null) throw new ApiException(400, "Missing required parameter 'environment' when calling GetTokenAccounts");
            // verify the required parameter 'index' is set
            if (index == null) throw new ApiException(400, "Missing required parameter 'index' when calling GetTokenAccounts");
            // verify the required parameter 'accountId' is set
            if (accountId == null) throw new ApiException(400, "Missing required parameter 'accountId' when calling GetTokenAccounts");
            // verify the required parameter 'mint' is set
            if (mint == null) throw new ApiException(400, "Missing required parameter 'mint' when calling GetTokenAccounts");
    
            var path = "/api/account/token-accounts/{environment}/{index}/{accountId}/{mint}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "environment" + "}", ApiClient.ParameterToString(environment));
path = path.Replace("{" + "index" + "}", ApiClient.ParameterToString(index));
path = path.Replace("{" + "accountId" + "}", ApiClient.ParameterToString(accountId));
path = path.Replace("{" + "mint" + "}", ApiClient.ParameterToString(mint));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTokenAccounts: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTokenAccounts: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<string>) ApiClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
        }
    
    }
}
