[![NuGet Status](https://img.shields.io/nuget/v/Kong.svg)](https://www.nuget.org/packages/Kong/)

# Kong.Net

.Net Rest Client for https://getkong.org/

## Install With NuGet

    install-package Kong

## Create a KongClient
```
var clientFactory = new KongClientFactory("http://kongserver:8001");
var client = clientFactory.Create();
```

## About the Node
Retrieve information about the node
```
var node = await client.Node();
```

## Node Status
Retrieve node status
```
var status = await client.Status();
```

## Cluster status
Retrieve the cluser status
```
var cluser = await client.Cluster();
```

## Apis
Access the admin api for your api's via the Apis property exposed on the client.
```
var apis = client.Apis;
```

### Listing Apis
```
var apis = await client.Apis.List();
```

### Retrieving an api
An api can be retrieved by either the id or the name.
```
var api = await client.Apis.Get("name or id of api");
```

### Updating an api
```
var api = await client.Apis.Get("name or id of api");
api.RequestPath = "/";
await api.Save();
```
Under the hood the client library is using the PUT api call. PATCH is not currently supported.

### Deleting an api
```
var api = await client.Apis.Get("name or id of api");
await api.Delete();
```

## Consumers

Access the admin api for your consumers via the Apis property exposed on the client.
```
var consumers = client.Consumers;
```

### Listing Consumers
```
var apis = await client.Consumers.List();
```

### Retrieving a consumer
A consumer can be retrieved by the consumer id.
```
var api = await client.Consumers.Get("id");
```

### Updating a consumer
```
var api = await client.Consumers.Get("id");
api.CustomId = "56789";
await api.Save();
```
Under the hood the client library is using the PUT api call. PATCH is not currently supported.

### Deleting a consumer
```
var api = await client.Consumers.Get("id");
await api.Delete();
```
## Plugins

The api for configuring plugins is exposed as a property on the IApi interface

```
var api = await client.Apis.Get("name or id of api");
var plugins = api.Plugins;
```

### Creating a Plugin

The Kong admin api supports configuring multiple types of plugins through the same interface. Kong knows which plugin you are configuring based on the plugin name property.

The client library attempts to abstract some of this away using the .Net type system to set the type name based on the concrete plugin object being used.

For example, you can add the basic-auth plugin to an api as follows:

```
var api = client.Apis.Get("id").Result;

await api.Plugins.Create(new PluginData
{
    Config = new BasicAuthPlugin
    {
        HideCredentials = false
    }
});
```
The client library will know which plugin you are trying to create by inspecting the Type of the Config property.

### Updating a Plugin configuration

Currently to update a plugin configuration you will need to know what type of plugin you are working with. This is in place in order to keep the interface clean and in most use cases you will likely know the type of the plugin you are trying to configure.

For example, if you wanted to retrieve the basic auth plugin created previously and change a property on it you would need to do the following:

```
var api = client.Apis.Get("id").Result;

var plugin = await api.Plugins.Get("plugin id");

var configuration = plugin.Configure<BasicAuthPlugin>();

configuration.HideCredentials = true;

await plugin.Save();
```

The client library will throw a PluginConfigurationException if you attempt to configure a plugin of the incorrect type.

### Plugin specific configuration

Where the plugin exposes additional admin interfaces, configuring consumer credentials for instance, then the additional api calls with be exposed on the plugin configuration object.

For example, to create a basic auth credential for a consumer you would do the following

```
var api = client.Apis.Get("id").Result;

var plugin = await api.Plugins.Get("plugin id");

var configuration = plugin.Configure<BasicAuthPlugin>();

var credentials = configuration.Credentials("consumer id);

await credentials.Create("username", "password");
```

Each plugin has it's own interface to expose the nescessary api calls and will be documented independently.