using System;
using System.Collections.Generic;
using JeffreyLanters.WebRequests;
using JeffreyLanters.WebRequests.Core;
using Cysharp.Threading.Tasks;
using Client;
using Model;

#pragma warning disable 0472 // The result of the expression is always the same since a value of this type is never equal to 'null'

using Commitment = System.String;
using System.Linq;

namespace Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAppApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <returns>AppConfig</returns>
        UniTask<AppConfig> GetAppConfig (string environment, int index);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <returns>AppHealth</returns>
        UniTask<AppHealth> GetAppHealth (string environment, int index);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AppApi : IAppApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AppApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AppApi(String basePath)
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
        /// <returns>AppConfig</returns>
        public async UniTask<AppConfig> GetAppConfig (string environment, int index)
        {
            
            // verify the required parameter 'environment' is set
            if (environment == null) throw new ApiException(400, "Missing required parameter 'environment' when calling GetAppConfig");
            
            // verify the required parameter 'index' is set
            if (index == null) throw new ApiException(400, "Missing required parameter 'index' when calling GetAppConfig");
            

            var path = "/api/app/{environment}/{index}/config";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "environment" + "}", ApiClient.ParameterToString(environment));
path = path.Replace("{" + "index" + "}", ApiClient.ParameterToString(index));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, String>();
            String postBody = null;

                                                
            // authentication setting, if any
            String[] authSettings = new String[] {  };
            UnityEngine.Debug.Log("Call GetAppConfig");
            // make the HTTP request
            WebRequestResponse response = await ApiClient.CallApi(path, RequestMethod.Get, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
            UnityEngine.Debug.Log("Finish GetAppConfig");
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAppConfig: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAppConfig: " + response.ErrorMessage, response.ErrorMessage);

            return (AppConfig) ApiClient.Deserialize(response.Content, typeof(AppConfig), response.headers.Values.ToList());
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="index"></param>
        /// <returns>AppHealth</returns>
        public async UniTask<AppHealth> GetAppHealth (string environment, int index)
        {
            
            // verify the required parameter 'environment' is set
            if (environment == null) throw new ApiException(400, "Missing required parameter 'environment' when calling GetAppHealth");
            
            // verify the required parameter 'index' is set
            if (index == null) throw new ApiException(400, "Missing required parameter 'index' when calling GetAppHealth");
            

            var path = "/api/app/{environment}/{index}/health";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "environment" + "}", ApiClient.ParameterToString(environment));
path = path.Replace("{" + "index" + "}", ApiClient.ParameterToString(index));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, String>();
            String postBody = null;

                                                
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            // make the HTTP request
            WebRequestResponse response = await ApiClient.CallApi(path, RequestMethod.Get, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAppHealth: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAppHealth: " + response.ErrorMessage, response.ErrorMessage);

            return (AppHealth) ApiClient.Deserialize(response.Content, typeof(AppHealth), response.headers.Values.ToList());
        }

    }
}
