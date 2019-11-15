# IO.Swagger.Api.DocsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GRPCCsharpCodeGen**](DocsApi.md#grpccsharpcodegen) | **GET** /docs/codeGen/gRPC/csharp | 📜 Some pointers to having csharp client code generation from a gRPC proto file.
[**GRPCProtoFile**](DocsApi.md#grpcprotofile) | **GET** /docs/codeGen/gRPC/proto | 📜 The gRPC proto file for the client code generation.
[**SwaggerCsharpCodeGen**](DocsApi.md#swaggercsharpcodegen) | **GET** /docs/codeGen/swagger/csharp | 📜 Some pointers to having csharp client code generation from the Swagger/Open API spec.


<a name="grpccsharpcodegen"></a>
# **GRPCCsharpCodeGen**
> string GRPCCsharpCodeGen ()

📜 Some pointers to having csharp client code generation from a gRPC proto file.

Use these guidelines to create a minimal application that allows you to communicate with our servers.     These guidelines provide automatically generated C# client code, with serialization and de-serialization and a way to authenticate your requests.    Keep in mind this is provided under the \"Works on my machine, YMMV.\"™ age-old agreement. 😀 Enjoy!

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GRPCCsharpCodeGenExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new DocsApi();

            try
            {
                // 📜 Some pointers to having csharp client code generation from a gRPC proto file.
                string result = apiInstance.GRPCCsharpCodeGen();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DocsApi.GRPCCsharpCodeGen: " + e.Message );
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

<a name="grpcprotofile"></a>
# **GRPCProtoFile**
> string GRPCProtoFile ()

📜 The gRPC proto file for the client code generation.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GRPCProtoFileExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new DocsApi();

            try
            {
                // 📜 The gRPC proto file for the client code generation.
                string result = apiInstance.GRPCProtoFile();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DocsApi.GRPCProtoFile: " + e.Message );
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
 - **Accept**: application/protobuf; charset=UTF-8

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="swaggercsharpcodegen"></a>
# **SwaggerCsharpCodeGen**
> string SwaggerCsharpCodeGen ()

📜 Some pointers to having csharp client code generation from the Swagger/Open API spec.

Use these guidelines to create a minimal application that allows you to communicate with our servers.     These guidelines provide automatically generated C# client code, with IntelliSense documentation, serialization and de-serialization and a way to authenticate your requests.    Keep in mind this is provided under the \"Works on my machine, YMMV.\"™ age-old agreement. 😀 Enjoy!

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SwaggerCsharpCodeGenExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new DocsApi();

            try
            {
                // 📜 Some pointers to having csharp client code generation from the Swagger/Open API spec.
                string result = apiInstance.SwaggerCsharpCodeGen();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DocsApi.SwaggerCsharpCodeGen: " + e.Message );
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

