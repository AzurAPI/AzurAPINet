# AzurAPINet
[![NuGet](http://img.shields.io/nuget/v/AzurAPINet)](https://www.nuget.org/packages/AzurAPINet/)
[![Prerelease](http://img.shields.io/nuget/vpre/AzurAPINet)](https://www.nuget.org/packages/AzurAPINet/)
## QuickStart
```csharp
using Jan0660.AzurAPINet;

AzurAPIClient Client = new AzurAPIClient(new AzurAPIClientOptions());
Console.WriteLine($"No. of ships: {Client.GetAllShips().Count}");
Console.WriteLine($"Takao's rarity: {Client.GetShip("takao").Rarity}");
Console.WriteLine($"Javelin's nationality: {Client.GetShipByEnglishName("javelin").Nationality}");
```

## WIP

Please note this library is still work in progress.

You can see the current progress and planned features [here](Progress.md).