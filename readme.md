# Kong.Net

.Net Rest Client for https://getkong.org/

## Create a IKongClient

    var client = new KongClient("http://kongserver:8001");

## Modular Request Factories

Apis, Consumers and Plugins are exposed via extension methods on IKongClient. This provides a mechnism to extend the client libray with your own plugins. We will cover extending the library in more detail later in this document.

You will need a requets factory in order to start talking to the Kong API. You can get an instance of a request for via the client.Apis(), client.Consumers() and client.Plugins(api) extension methods

    var apis = client.Apis();

The code above will return a request factory for the Api resource

Each request factory exposes the followng methods:

1. List - Allows you to search the resource
2. Get - Allows you to retrieve a since resource based on the resource id
3. Delete - Allows you to delete the resource with a given id
4. Patch - Updates a given resource
5. Post - Creates a new resource

## Retrieve an api

To retrieve a single api you can use the Get method on the ApiRequestFactory

    var api = apis.Get("apiId");

## Plugins

Once you have retrieved a resource you may want to configure the plugins for it. To do this you will need to grab an instance of the PluginsRequestFactory. You can do this via the extension method on IKongClient. Note you will need to supply an instance of the Api which you want to configure plugins for

    var plugins = client.Plugins(api);

### Creating a Plugin

Once you have a instance of the plugins request factory you can start creating plugins. The code snippet below illustrates how this can be done

    var plugin = new RateLimitingPlugin
    {
        ApiId = api.Id,
        Enabled = true,
        Config = new RateLimitingPluginConfig
        {
            Second = 10
        }
    };

    client.Plugins(api).Post(plugin);