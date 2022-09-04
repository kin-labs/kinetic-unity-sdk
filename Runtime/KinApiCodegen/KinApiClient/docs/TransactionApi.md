# IO.Swagger.Api.TransactionApi

All URIs are relative to *https://devnet.kinetic.kin.org*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetLatestBlockhash**](TransactionApi.md#getlatestblockhash) | **GET** /api/transaction/latest-blockhash/{environment}/{index} | 
[**GetMinimumRentExemptionBalance**](TransactionApi.md#getminimumrentexemptionbalance) | **GET** /api/transaction/minimum-rent-exemption-balance/{environment}/{index} | 
[**MakeTransfer**](TransactionApi.md#maketransfer) | **POST** /api/transaction/make-transfer | 

<a name="getlatestblockhash"></a>
# **GetLatestBlockhash**
> LatestBlockhashResponse GetLatestBlockhash (string environment, int? index)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetLatestBlockhashExample
    {
        public void main()
        {

            var apiInstance = new TransactionApi();
            var environment = environment_example;  // string | 
            var index = 56;  // int? | 

            try
            {
                LatestBlockhashResponse result = apiInstance.GetLatestBlockhash(environment, index);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TransactionApi.GetLatestBlockhash: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **environment** | **string**|  | 
 **index** | **int?**|  | 

### Return type

[**LatestBlockhashResponse**](LatestBlockhashResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getminimumrentexemptionbalance"></a>
# **GetMinimumRentExemptionBalance**
> MinimumRentExemptionBalanceResponse GetMinimumRentExemptionBalance (string environment, int? index, int? dataLength)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetMinimumRentExemptionBalanceExample
    {
        public void main()
        {

            var apiInstance = new TransactionApi();
            var environment = environment_example;  // string | 
            var index = 56;  // int? | 
            var dataLength = 56;  // int? | 

            try
            {
                MinimumRentExemptionBalanceResponse result = apiInstance.GetMinimumRentExemptionBalance(environment, index, dataLength);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TransactionApi.GetMinimumRentExemptionBalance: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **environment** | **string**|  | 
 **index** | **int?**|  | 
 **dataLength** | **int?**|  | 

### Return type

[**MinimumRentExemptionBalanceResponse**](MinimumRentExemptionBalanceResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="maketransfer"></a>
# **MakeTransfer**
> AppTransaction MakeTransfer (MakeTransferRequest body)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MakeTransferExample
    {
        public void main()
        {

            var apiInstance = new TransactionApi();
            var body = new MakeTransferRequest(); // MakeTransferRequest | 

            try
            {
                AppTransaction result = apiInstance.MakeTransfer(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TransactionApi.MakeTransfer: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**MakeTransferRequest**](MakeTransferRequest.md)|  | 

### Return type

[**AppTransaction**](AppTransaction.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

