# IO.Swagger.Api.DefaultApi

All URIs are relative to *https://devnet.kinetic.kin.org*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiCoreFeatureControllerMetrics**](DefaultApi.md#apicorefeaturecontrollermetrics) | **GET** /api/metrics | 
[**ApiCoreFeatureControllerUptime**](DefaultApi.md#apicorefeaturecontrolleruptime) | **GET** /api/uptime | 

<a name="apicorefeaturecontrollermetrics"></a>
# **ApiCoreFeatureControllerMetrics**
> void ApiCoreFeatureControllerMetrics ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiCoreFeatureControllerMetricsExample
    {
        public void main()
        {

            var apiInstance = new DefaultApi();

            try
            {
                apiInstance.ApiCoreFeatureControllerMetrics();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.ApiCoreFeatureControllerMetrics: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apicorefeaturecontrolleruptime"></a>
# **ApiCoreFeatureControllerUptime**
> void ApiCoreFeatureControllerUptime ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiCoreFeatureControllerUptimeExample
    {
        public void main()
        {

            var apiInstance = new DefaultApi();

            try
            {
                apiInstance.ApiCoreFeatureControllerUptime();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.ApiCoreFeatureControllerUptime: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

