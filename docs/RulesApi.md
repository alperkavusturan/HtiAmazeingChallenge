# IO.Swagger.Api.RulesApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Get**](RulesApi.md#get) | **GET** /rules | 📜 Learn all the rules for this evening.


<a name="get"></a>
# **Get**
> string Get ()

📜 Learn all the rules for this evening.

Spoiler alert: rule #1 is to have fun!

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new RulesApi();

            try
            {
                // 📜 Learn all the rules for this evening.
                string result = apiInstance.Get();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RulesApi.Get: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**string**

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/markdown; charset=UTF-8

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

