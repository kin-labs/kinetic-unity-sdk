# IO.Swagger.Api.AppApi

All URIs are relative to *https://devnet.kinetic.kin.org*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiAppFeatureControllerAppWebhook**](AppApi.md#apiappfeaturecontrollerappwebhook) | **POST** /api/app/{environment}/{index}/webhook/{type} | 
[**GetAppConfig**](AppApi.md#getappconfig) | **GET** /api/app/{environment}/{index}/config | 
[**GetAppHealth**](AppApi.md#getapphealth) | **GET** /api/app/{environment}/{index}/health | 

<a name="apiappfeaturecontrollerappwebhook"></a>
# **ApiAppFeatureControllerAppWebhook**
> void ApiAppFeatureControllerAppWebhook (string environment, decimal? index, string type)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAppFeatureControllerAppWebhookExample
    {
        public void main()
        {

            var apiInstance = new AppApi();
            var environment = environment_example;  // string | 
            var index = 1.2;  // decimal? | 
            var type = type_example;  // string | 

            try
            {
                apiInstance.ApiAppFeatureControllerAppWebhook(environment, index, type);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppApi.ApiAppFeatureControllerAppWebhook: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **environment** | **string**|  | 
 **index** | **decimal?**|  | 
 **type** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getappconfig"></a>
# **GetAppConfig**
> AppConfig GetAppConfig (string environment, decimal? index)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAppConfigExample
    {
        public void main()
        {

            var apiInstance = new AppApi();
            var environment = environment_example;  // string | 
            var index = 1.2;  // decimal? | 

            try
            {
                AppConfig result = apiInstance.GetAppConfig(environment, index);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppApi.GetAppConfig: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **environment** | **string**|  | 
 **index** | **decimal?**|  | 

### Return type

[**AppConfig**](AppConfig.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getapphealth"></a>
# **GetAppHealth**
> AppHealth GetAppHealth (string environment, decimal? index)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAppHealthExample
    {
        public void main()
        {

            var apiInstance = new AppApi();
            var environment = environment_example;  // string | 
            var index = 1.2;  // decimal? | 

            try
            {
                AppHealth result = apiInstance.GetAppHealth(environment, index);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppApi.GetAppHealth: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **environment** | **string**|  | 
 **index** | **decimal?**|  | 

### Return type

[**AppHealth**](AppHealth.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

