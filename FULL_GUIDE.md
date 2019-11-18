# CSharp code generation using Swagger

Here are some tips and tricks that we have learned to obtain some client code generation in csharp.

When you access our Swagger UI, you can obtain the JSON specification. Usually it will be available in `/swagger/api/swagger.json`.

You can now go to [Swagger Generator](https://generator.swagger.io/) to have some code auto-generated for you.

There, you can use the POST `/gen/clients/csharp` endpoint to auto-generate a csharp client.

The body for that endpoint takes in the following payload:

```json
{
  "spec": <<paste our JSON specification here>>
}
```

If you issue this POST you will receive a response with the following payload:
```json
{
  "code": "a-guid-value-here",
  "link": "https://generator.swagger.io/api/gen/download/the-same-guid-value-as-above"
}
```

You can now download the file referenced in `link` from this response. The file is usually named `csharp-client-generated.zip`.

Upon unzipping this file, you will find in it an `IO.Swagger.sln`.

Opening this `sln` (using Visual Studio) file presents you with two projects: `IO.Swagger` and `IO.Swagger.Test`.

You can unload or remove the `Test` project, to make your life easier.

If you try to build the solution, you might obtain a few errors stating `The type or namespace name 'RestSharp' could not be found`.

To solve this problem you need to uninstall the referenced RestSharp package (`105.1.0`) and install RestSharp package `105.2.3`, by running in the `Package Manager Console` (`View > Other windows > Package Manager Console`):

```
Uninstall-Package RestSharp
Install-Package RestSharp -Version 105.2.3
```

This will now enable you to **build** your solution.

---

# Adding a console application

It is a good practice that any code you add, you add on your own project, instead of on the auto-generated project.

So, let's create a console application to interact with the A-maze-ing server.

In Visual Studio, create a new `.net framework` console app. Sorry, it can't be a net core app, because the auto-generated code relies on some .net framework features.

You can call the console app whatever you fancy, but in our example, we'll call it `Client`. Much imagination, such wow.

You can now add a **Project Reference** to `IO.Swagger`, and let's create the minimum code to register ourselves and obtain all available mazes. MVP FTW.

```csharp
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Configure API key authorization
            IO.Swagger.Client.Configuration.Default.BasePath = "<<THE SERVER ADDRESS>>";
            IO.Swagger.Client.Configuration.Default.AddDefaultHeader("Authorization", "<<YOUR TOKEN>>");

            var playerApi = new IO.Swagger.Api.PlayerApi();
            Console.WriteLine("About to register...");
            await playerApi.RegisterAsync(name: "Amazing Player");

            var mazesApi = new IO.Swagger.Api.MazesApi();
            Console.WriteLine("About to obtain all mazes...");
            var allMazes = await mazesApi.AllAsync();

            foreach (var maze in allMazes)
                Console.WriteLine($"[{maze.Name}] has a potential reward of [{maze.PotentialReward}] and contains [{maze.TotalTiles}] tiles;");

            Console.ReadLine();
        }
    }
}

```

Remember to set the `Client` project as Startup project and replace the server address and your access token variables. 

Let's take it for a spin. If all went well, you can now see the following output:

```
About to register...
About to obtain all mazes...
[Example maze] has a potential reward of [160] and contains [17] tiles;
[Hello maze] has a potential reward of [110] and contains [8] tiles;
```

ℹ We have observed, in Visual Studio 2019, that for whatever reason, the console doesn't show up when you run the application. Like so many strange bugs, restarting Visual Studio seems to solve this issue. 🤷🏻‍

This code is the minimum thing that works and it has problems such as the second time you run it, it will throw an exception because you are already registered.

But we don't want to give you all the code. Instead, we want to help you hit the road running, by facilitating your communication with the server.

And always remember: Have fun! 👍🏻

---

This example was written and tested on [2019-06-24], and it "worked on my machine". Hopefully it will work on yours as well 😅.
