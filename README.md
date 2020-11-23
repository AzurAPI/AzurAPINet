# AzurAPINet
[![NuGet](http://img.shields.io/nuget/v/AzurAPINet)](https://www.nuget.org/packages/AzurAPINet/)
[![Prerelease](http://img.shields.io/nuget/vpre/AzurAPINet)](https://www.nuget.org/packages/AzurAPINet/)
## QuickStart
Install [the NuGet package](https://www.nuget.org/packages/AzurAPINet/)
```csharp
using Jan0660.AzurAPINet;

AzurAPIClient Client = new AzurAPIClient(new AzurAPIClientOptions());
Console.WriteLine($"No. of ships: {Client.getAllShips().Count}");
Console.WriteLine($"Takao's rarity: {Client.getShip("takao").Rarity}");
Console.WriteLine($"Javelin's nationality: {Client.getShipByEnglishName("javelin").Nationality}");
```
Expected output (as of now):

![You ever just boot into linux so you can flex it in your readme](https://i.imgur.com/Q2iTwp9.png)
## [More documentation available on wiki](https://github.com/Jan0660/AzurAPINet/wiki)
## [Or you can also check out the documentation on AzurAPI wiki](https://azurapi.github.io/?csharp#introduction)