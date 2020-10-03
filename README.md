# AzurAPINetCore

##### Create new client

```csharp
using Jan0660.AzurAPINetCore;

AzurAPIClient Client = new AzurAPIClient(@"D:\00.code\azurapi-js-setup\",
                                         new AzurAPIClientOptions());
```



##### Get all ships

```csharp
var ships = Client.GetAllShips();
```

##### Get a ship by name

The client.GetShip method searches for a ship using it's English name, code, id, Japanese and Chinese name, in this order.

```csharp
Client.GetShip("takao");
```

You can also search for a ship using only it's id using 

```csharp
Client.GetShipById("200");
```

#### Caching

This wrapper caches all the ships on the first call to `Client.GetAllShips` (which is also called by the GetShip functions ). It only takes up a few extra Megabytes of ram and saves waiting 3 seconds(on a 3.3ghz CPU) on each call to `Client.GetAllShips` .

Just in case you want to disable it (pls don't, not caching probably causes even memory leaks lol) just set the `EnableCaching` value on the `AzurAPIClientOptions` you're using with your `AzurAPIClient`.