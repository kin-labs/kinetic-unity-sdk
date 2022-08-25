# IO.Swagger.Api.AirdropApi

All URIs are relative to *https://devnet.kinetic.kin.org*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AirdropStats**](AirdropApi.md#airdropstats) | **GET** /api/airdrop/stats | 
[**RequestAirdrop**](AirdropApi.md#requestairdrop) | **POST** /api/airdrop | 

<a name="airdropstats"></a>
# **AirdropStats**
> AirdropStats AirdropStats ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AirdropStatsExample
    {
        public void main()
        {

            var apiInstance = new AirdropApi();

            try
            {
                AirdropStats result = apiInstance.AirdropStats();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AirdropApi.AirdropStats: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**AirdropStats**](AirdropStats.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="requestairdrop"></a>
# **RequestAirdrop**
> RequestAirdropResponse RequestAirdrop (RequestAirdropRequest body)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RequestAirdropExample
    {
        public void main()
        {

            var apiInstance = new AirdropApi();
            var body = new RequestAirdropRequest(); // RequestAirdropRequest | 

            try
            {
                RequestAirdropResponse result = apiInstance.RequestAirdrop(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AirdropApi.RequestAirdrop: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**RequestAirdropRequest**](RequestAirdropRequest.md)|  | 

### Return type

[**RequestAirdropResponse**](RequestAirdropResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

