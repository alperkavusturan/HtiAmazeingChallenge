# IO.Swagger.Api.MazesApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**All**](MazesApi.md#all) | **GET** /api/mazes/all | 📜 All the mazes that exist in the game.


<a name="all"></a>
# **All**
> List<MazeInfo> All ()

📜 All the mazes that exist in the game.

Even though you can only play a maze once, this method will return all the mazes. This is not lazyness from the server side, this is to make it slightly more \"interesting\", because you need to keep track of the mazes you have already played on your implementation.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AllExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazesApi();

            try
            {
                // 📜 All the mazes that exist in the game.
                List&lt;MazeInfo&gt; result = apiInstance.All();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazesApi.All: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<MazeInfo>**](MazeInfo.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

