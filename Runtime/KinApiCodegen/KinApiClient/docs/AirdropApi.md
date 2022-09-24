# IO.Swagger.Api.AirdropApi

All URIs are relative to *http://localhost:3000*

Method | HTTP request | Description
------------- | ------------- | -------------
[**RequestAirdrop**](AirdropApi.md#requestairdrop) | **POST** /api/airdrop | 

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

