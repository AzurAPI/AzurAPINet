# AzurAPINet

## How to use

### Download AzurAPI database

[Follow the instructions here](https://github.com/AzurAPI/azurapi-js-setup) 

#### Create new client

Replace `DatabaseDirectory` with your path to the downloaded AzurAPI database with a slash at the end.

For example: `@"D:\00.code\azurapi-js-setup\"`

```csharp
using Jan0660.AzurAPINet;

AzurAPIClient Client = new AzurAPIClient(DatabaseDirectory,
                                         new AzurAPIClientOptions());
```

#### Get all ships

```csharp
var ships = Client.GetAllShips();
```

#### Get a ship by name

The client.GetShip method searches for a ship using it's English name, code, id, Japanese and Chinese name, in this order.

```csharp
var ship = Client.GetShip("takao");
// or for the real ones
var waifu = Client.GetWaifu("takao");
```

You can also search for a ship using only it's id

```csharp
Client.GetShipById("200");
```

## Caching

This wrapper caches all the ships on the first call to `Client.GetAllShips` (which is also called by the GetShip functions ). It only takes up a few extra Megabytes of ram and saves waiting 3 seconds(on a 3.3ghz CPU) on each call to `Client.GetAllShips` .

Just in case you want to disable it (pls don't, not caching probably causes even memory leaks lol) just set the `EnableCaching` value on the `AzurAPIClientOptions` you're using with your `AzurAPIClient`.

## WIP

Please note this library is still work in progress.

You can see the current progress and planned features [here](Progress.md).