# IO.Swagger.Api.TransactionApi

All URIs are relative to *http://localhost:3000*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetLatestBlockhash**](TransactionApi.md#getlatestblockhash) | **GET** /api/transaction/latest-blockhash/{environment}/{index} | 
[**GetMinimumRentExemptionBalance**](TransactionApi.md#getminimumrentexemptionbalance) | **GET** /api/transaction/minimum-rent-exemption-balance/{environment}/{index} | 
[**GetTransaction**](TransactionApi.md#gettransaction) | **GET** /api/transaction/transaction/{environment}/{index}/{signature} | 
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

<a name="gettransaction"></a>
# **GetTransaction**
> GetTransactionResponse GetTransaction (string environment, int? index, string signature)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTransactionExample
    {
        public void main()
        {

            var apiInstance = new TransactionApi();
            var environment = environment_example;  // string | 
            var index = 56;  // int? | 
            var signature = signature_example;  // string | 

            try
            {
                GetTransactionResponse result = apiInstance.GetTransaction(environment, index, signature);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TransactionApi.GetTransaction: " + e.Message );
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
 **signature** | **string**|  | 

### Return type

[**GetTransactionResponse**](GetTransactionResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="maketransfer"></a>
# **MakeTransfer**
> Transaction MakeTransfer (MakeTransferRequest body)



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
                Transaction result = apiInstance.MakeTransfer(body);
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

[**Transaction**](Transaction.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

