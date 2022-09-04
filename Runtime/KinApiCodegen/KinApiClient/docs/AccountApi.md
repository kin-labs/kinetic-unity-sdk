# IO.Swagger.Api.AccountApi

All URIs are relative to *https://devnet.kinetic.kin.org*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateAccount**](AccountApi.md#createaccount) | **POST** /api/account/create | 
[**GetAccountInfo**](AccountApi.md#getaccountinfo) | **GET** /api/account/info/{environment}/{index}/{accountId} | 
[**GetBalance**](AccountApi.md#getbalance) | **GET** /api/account/balance/{environment}/{index}/{accountId} | 
[**GetHistory**](AccountApi.md#gethistory) | **GET** /api/account/history/{environment}/{index}/{accountId}/{mint} | 
[**GetTokenAccounts**](AccountApi.md#gettokenaccounts) | **GET** /api/account/token-accounts/{environment}/{index}/{accountId}/{mint} | 

<a name="createaccount"></a>
# **CreateAccount**
> AppTransaction CreateAccount (CreateAccountRequest body)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateAccountExample
    {
        public void main()
        {

            var apiInstance = new AccountApi();
            var body = new CreateAccountRequest(); // CreateAccountRequest | 

            try
            {
                AppTransaction result = apiInstance.CreateAccount(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.CreateAccount: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**CreateAccountRequest**](CreateAccountRequest.md)|  | 

### Return type

[**AppTransaction**](AppTransaction.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getaccountinfo"></a>
# **GetAccountInfo**
> void GetAccountInfo (string environment, int? index, string accountId)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAccountInfoExample
    {
        public void main()
        {

            var apiInstance = new AccountApi();
            var environment = environment_example;  // string | 
            var index = 56;  // int? | 
            var accountId = accountId_example;  // string | 

            try
            {
                apiInstance.GetAccountInfo(environment, index, accountId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.GetAccountInfo: " + e.Message );
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
 **accountId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbalance"></a>
# **GetBalance**
> BalanceResponse GetBalance (string environment, int? index, string accountId)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetBalanceExample
    {
        public void main()
        {

            var apiInstance = new AccountApi();
            var environment = environment_example;  // string | 
            var index = 56;  // int? | 
            var accountId = accountId_example;  // string | 

            try
            {
                BalanceResponse result = apiInstance.GetBalance(environment, index, accountId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.GetBalance: " + e.Message );
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
 **accountId** | **string**|  | 

### Return type

[**BalanceResponse**](BalanceResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gethistory"></a>
# **GetHistory**
> List<HistoryResponse> GetHistory (string environment, int? index, string accountId, string mint)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetHistoryExample
    {
        public void main()
        {

            var apiInstance = new AccountApi();
            var environment = environment_example;  // string | 
            var index = 56;  // int? | 
            var accountId = accountId_example;  // string | 
            var mint = mint_example;  // string | 

            try
            {
                List&lt;HistoryResponse&gt; result = apiInstance.GetHistory(environment, index, accountId, mint);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.GetHistory: " + e.Message );
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
 **accountId** | **string**|  | 
 **mint** | **string**|  | 

### Return type

[**List<HistoryResponse>**](HistoryResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettokenaccounts"></a>
# **GetTokenAccounts**
> List<string> GetTokenAccounts (string environment, int? index, string accountId, string mint)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTokenAccountsExample
    {
        public void main()
        {

            var apiInstance = new AccountApi();
            var environment = environment_example;  // string | 
            var index = 56;  // int? | 
            var accountId = accountId_example;  // string | 
            var mint = mint_example;  // string | 

            try
            {
                List&lt;string&gt; result = apiInstance.GetTokenAccounts(environment, index, accountId, mint);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.GetTokenAccounts: " + e.Message );
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
 **accountId** | **string**|  | 
 **mint** | **string**|  | 

### Return type

**List<string>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

