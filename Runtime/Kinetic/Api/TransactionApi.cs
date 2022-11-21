using System;
using System.Collections.Generic;
using RestSharp;
using Client;
using Model;

namespace Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITransactionApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <returns>LatestBlockhashResponse</returns>
        LatestBlockhashResponse GetLatestBlockhash (string environment, int index);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="dataLength"></param>
        /// <returns>MinimumRentExemptionBalanceResponse</returns>
        MinimumRentExemptionBalanceResponse GetMinimumRentExemptionBalance (string environment, int index, int dataLength);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="signature"></param>
        /// <returns>GetTransactionResponse</returns>
        GetTransactionResponse GetTransaction (string environment, int index, string signature);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="makeTransferRequest"></param>
        /// <returns>Transaction</returns>
        Transaction MakeTransfer (MakeTransferRequest makeTransferRequest);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TransactionApi : ITransactionApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public TransactionApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TransactionApi(String basePath)
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
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <returns>LatestBlockhashResponse</returns>
        public LatestBlockhashResponse GetLatestBlockhash (string environment, int index)
        {
            
            // verify the required parameter 'environment' is set
            if (environment == null) throw new ApiException(400, "Missing required parameter 'environment' when calling GetLatestBlockhash");
            
            // verify the required parameter 'index' is set
            if (index == null) throw new ApiException(400, "Missing required parameter 'index' when calling GetLatestBlockhash");
            

            var path = "/api/transaction/latest-blockhash/{environment}/{index}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "environment" + "}", ApiClient.ParameterToString(environment));
path = path.Replace("{" + "index" + "}", ApiClient.ParameterToString(index));

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
                throw new ApiException ((int)response.StatusCode, "Error calling GetLatestBlockhash: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetLatestBlockhash: " + response.ErrorMessage, response.ErrorMessage);

            return (LatestBlockhashResponse) ApiClient.Deserialize(response.Content, typeof(LatestBlockhashResponse), response.Headers);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="dataLength"></param>
        /// <returns>MinimumRentExemptionBalanceResponse</returns>
        public MinimumRentExemptionBalanceResponse GetMinimumRentExemptionBalance (string environment, int index, int dataLength)
        {
            
            // verify the required parameter 'environment' is set
            if (environment == null) throw new ApiException(400, "Missing required parameter 'environment' when calling GetMinimumRentExemptionBalance");
            
            // verify the required parameter 'index' is set
            if (index == null) throw new ApiException(400, "Missing required parameter 'index' when calling GetMinimumRentExemptionBalance");
            
            // verify the required parameter 'dataLength' is set
            if (dataLength == null) throw new ApiException(400, "Missing required parameter 'dataLength' when calling GetMinimumRentExemptionBalance");
            

            var path = "/api/transaction/minimum-rent-exemption-balance/{environment}/{index}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "environment" + "}", ApiClient.ParameterToString(environment));
path = path.Replace("{" + "index" + "}", ApiClient.ParameterToString(index));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

             if (dataLength != null) queryParams.Add("dataLength", ApiClient.ParameterToString(dataLength)); // query parameter
                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetMinimumRentExemptionBalance: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetMinimumRentExemptionBalance: " + response.ErrorMessage, response.ErrorMessage);

            return (MinimumRentExemptionBalanceResponse) ApiClient.Deserialize(response.Content, typeof(MinimumRentExemptionBalanceResponse), response.Headers);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <param name="signature"></param>
        /// <returns>GetTransactionResponse</returns>
        public GetTransactionResponse GetTransaction (string environment, int index, string signature)
        {
            
            // verify the required parameter 'environment' is set
            if (environment == null) throw new ApiException(400, "Missing required parameter 'environment' when calling GetTransaction");
            
            // verify the required parameter 'index' is set
            if (index == null) throw new ApiException(400, "Missing required parameter 'index' when calling GetTransaction");
            
            // verify the required parameter 'signature' is set
            if (signature == null) throw new ApiException(400, "Missing required parameter 'signature' when calling GetTransaction");
            

            var path = "/api/transaction/transaction/{environment}/{index}/{signature}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "environment" + "}", ApiClient.ParameterToString(environment));
path = path.Replace("{" + "index" + "}", ApiClient.ParameterToString(index));
path = path.Replace("{" + "signature" + "}", ApiClient.ParameterToString(signature));

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
                throw new ApiException ((int)response.StatusCode, "Error calling GetTransaction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTransaction: " + response.ErrorMessage, response.ErrorMessage);

            return (GetTransactionResponse) ApiClient.Deserialize(response.Content, typeof(GetTransactionResponse), response.Headers);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="makeTransferRequest"></param>
        /// <returns>Transaction</returns>
        public Transaction MakeTransfer (MakeTransferRequest makeTransferRequest)
        {
            
            // verify the required parameter 'makeTransferRequest' is set
            if (makeTransferRequest == null) throw new ApiException(400, "Missing required parameter 'makeTransferRequest' when calling MakeTransfer");
            

            var path = "/api/transaction/make-transfer";
            path = path.Replace("{format}", "json");
            
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

                                                postBody = ApiClient.Serialize(makeTransferRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling MakeTransfer: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling MakeTransfer: " + response.ErrorMessage, response.ErrorMessage);

            return (Transaction) ApiClient.Deserialize(response.Content, typeof(Transaction), response.Headers);
        }

    }
}
