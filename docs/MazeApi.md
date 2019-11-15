# IO.Swagger.Api.MazeApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CollectScore**](MazeApi.md#collectscore) | **POST** /api/maze/collectScore | 💰 Collect score from your hand to your bag.
[**Enter**](MazeApi.md#enter) | **POST** /api/maze/enter | 🌟 Enter a maze.
[**ExitMaze**](MazeApi.md#exitmaze) | **POST** /api/maze/exit | 🚪 Exit the maze.
[**MoveDown**](MazeApi.md#movedown) | **POST** /api/maze/move/down | ⬇ Move down.
[**MoveLeft**](MazeApi.md#moveleft) | **POST** /api/maze/move/left | ⬅ Move left.
[**MoveRight**](MazeApi.md#moveright) | **POST** /api/maze/move/right | ➡ Move right.
[**MoveUp**](MazeApi.md#moveup) | **POST** /api/maze/move/up | ⬆ Move up.
[**PossibleActions**](MazeApi.md#possibleactions) | **GET** /api/maze/possibleActions | 👀 Get the list of possible actions, from the tile where you are standing.


<a name="collectscore"></a>
# **CollectScore**
> PossibleActionsAndCurrentScore CollectScore ()

💰 Collect score from your hand to your bag.

Remember that when you exit a maze, only score in your bag will carry over and be awarded to your overall player score. Any score left in your hand will be lost.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CollectScoreExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();

            try
            {
                // 💰 Collect score from your hand to your bag.
                PossibleActionsAndCurrentScore result = apiInstance.CollectScore();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.CollectScore: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="enter"></a>
# **Enter**
> PossibleActionsAndCurrentScore Enter (string mazeName = null)

🌟 Enter a maze.

Keep in mind that you can only be playing one maze at a time. Invoking this method when you are already in a maze will result in a failure. Also, you can only play the same maze once. If you wish to play the same maze \"multiple times\", you need to request to forget your player data (via the player API).

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class EnterExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();
            var mazeName = mazeName_example;  // string | What maze do you wish to enter. (optional) 

            try
            {
                // 🌟 Enter a maze.
                PossibleActionsAndCurrentScore result = apiInstance.Enter(mazeName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.Enter: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **mazeName** | **string**| What maze do you wish to enter. | [optional] 

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="exitmaze"></a>
# **ExitMaze**
> void ExitMaze ()

🚪 Exit the maze.

Remember that when you exit a maze, only score in your bag will carry over and be awarded to your overall player score. Any score left in your hand will be lost.   Also, remember that you can only play the same maze once, so make sure you have collected as much score as you can.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ExitMazeExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();

            try
            {
                // 🚪 Exit the maze.
                apiInstance.ExitMaze();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.ExitMaze: " + e.Message );
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

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="movedown"></a>
# **MoveDown**
> PossibleActionsAndCurrentScore MoveDown ()

⬇ Move down.

You must have already entered a maze. This method will return 200 even if you could not move in this direction. If there is a \"wall\" in your way and you try to move there.. well, it's gonna hurt, but you will remain in the same place.. which.. technically.. is valid.. 🤷🏻‍

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MoveDownExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();

            try
            {
                // ⬇ Move down.
                PossibleActionsAndCurrentScore result = apiInstance.MoveDown();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.MoveDown: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="moveleft"></a>
# **MoveLeft**
> PossibleActionsAndCurrentScore MoveLeft ()

⬅ Move left.

You must have already entered a maze. This method will return 200 even if you could not move in this direction. If there is a \"wall\" in your way and you try to move there.. well, it's gonna hurt, but you will remain in the same place.. which.. technically.. is valid.. 🤷🏻‍

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MoveLeftExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();

            try
            {
                // ⬅ Move left.
                PossibleActionsAndCurrentScore result = apiInstance.MoveLeft();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.MoveLeft: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="moveright"></a>
# **MoveRight**
> PossibleActionsAndCurrentScore MoveRight ()

➡ Move right.

You must have already entered a maze. This method will return 200 even if you could not move in this direction. If there is a \"wall\" in your way and you try to move there.. well, it's gonna hurt, but you will remain in the same place.. which.. technically.. is valid.. 🤷🏻‍

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MoveRightExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();

            try
            {
                // ➡ Move right.
                PossibleActionsAndCurrentScore result = apiInstance.MoveRight();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.MoveRight: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="moveup"></a>
# **MoveUp**
> PossibleActionsAndCurrentScore MoveUp ()

⬆ Move up.

You must have already entered a maze. This method will return 200 even if you could not move in this direction. If there is a \"wall\" in your way and you try to move there.. well, it's gonna hurt, but you will remain in the same place.. which.. technically.. is valid.. 🤷🏻‍

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MoveUpExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();

            try
            {
                // ⬆ Move up.
                PossibleActionsAndCurrentScore result = apiInstance.MoveUp();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.MoveUp: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="possibleactions"></a>
# **PossibleActions**
> PossibleActionsAndCurrentScore PossibleActions ()

👀 Get the list of possible actions, from the tile where you are standing.

You must have already entered a maze. Also, you shouldn't require this method that much, given than any action you perform on the maze will return this same information.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PossibleActionsExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();

            try
            {
                // 👀 Get the list of possible actions, from the tile where you are standing.
                PossibleActionsAndCurrentScore result = apiInstance.PossibleActions();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.PossibleActions: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

