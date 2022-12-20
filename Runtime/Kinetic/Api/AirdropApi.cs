using System;
using System.Collections.Generic;
using RestSharp;
using Client;
using Model;

#pragma warning disable 0472 // The result of the expression is always the same since a value of this type is never equal to 'null'

using Commitment = System.String;

namespace Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAirdropApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="requestAirdropRequest"></param>
        /// <returns>RequestAirdropResponse</returns>
        RequestAirdropResponse RequestAirdrop (RequestAirdropRequest requestAirdropRequest);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AirdropApi : IAirdropApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirdropApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AirdropApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AirdropApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AirdropApi(String basePath)
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
        /// <param name="requestAirdropRequest"></param>
        /// <returns>RequestAirdropResponse</returns>
        public RequestAirdropResponse RequestAirdrop (RequestAirdropRequest requestAirdropRequest)
        {
            
            // verify the required parameter 'requestAirdropRequest' is set
            if (requestAirdropRequest == null) throw new ApiException(400, "Missing required parameter 'requestAirdropRequest' when calling RequestAirdrop");
            

            var path = "/api/airdrop";
            path = path.Replace("{format}", "json");
            
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

                                                postBody = ApiClient.Serialize(requestAirdropRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RequestAirdrop: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RequestAirdrop: " + response.ErrorMessage, response.ErrorMessage);

            return (RequestAirdropResponse) ApiClient.Deserialize(response.Content, typeof(RequestAirdropResponse), response.Headers);
        }

    }
}
