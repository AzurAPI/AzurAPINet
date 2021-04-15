# AzurAPINet
[![NuGet](http://img.shields.io/nuget/v/AzurAPINet)](https://www.nuget.org/packages/AzurAPINet/)
[![Prerelease](http://img.shields.io/nuget/vpre/AzurAPINet)](https://www.nuget.org/packages/AzurAPINet/)
## QuickStart
Install [the NuGet package](https://www.nuget.org/packages/AzurAPINet/)
```csharp
using Jan0660.AzurAPINet;

var client = new AzurAPIClient(new AzurAPIClientOptions());
Console.WriteLine($"No. of ships: {client.getAllShips().Count}");
Console.WriteLine($"Takao's rarity: {client.getShip("takao").Rarity}");
Console.WriteLine($"Javelin's nationality: {client.getShipByEnglishName("javelin").Nationality}");
```
Expected output (as of now):

![You ever just boot into linux so you can flex it in your readme](https://i.imgur.com/Q2iTwp9.png)
## [Or you can also check out the documentation on AzurAPI wiki](https://azurapi.github.io/v2/?csharp#introduction)