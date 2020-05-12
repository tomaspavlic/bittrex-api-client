# Bittrex API client
![build](https://github.com/tomaspavlic/bittrex-api-client/workflows/build/badge.svg)
![downloads](https://img.shields.io/nuget/dt/Topdev.Bittrex.Client)
![nuget](https://img.shields.io/nuget/v/Topdev.Bittrex.Client)

## Installation
```bash
## .NET CLI
dotnet add package Topdev.Bittrex.Client

## Package Manager
Install-Package Topdev.Bittrex.Client
```

## Description
The Bittrex API client library for .NET enables access to Bittrex APIs such as Account, Addresses, Balances and more. The library supports Bittrex authentication.

Endpoint | Methods
--- | ---
Account | GetAccountAsync, GetAccountVolumeAsync
Addresses | GetAddressesAsync, ProvisionNewAddressAsync, GetAddressAsync
Balances | GetBalancesAsync, GetBalanceAsync
ConditionalOrders | GetConditionalOrderAsync, DeleteConditionalOrderAsync, GetConditionalOrdersAsync, CreateConditionalOrderAsync
Currencies | GetCurrenciesAsync, GetCurrencyAsync
Deposits | GetDepositsAsync, GetDepositAsync, GetDepositByTxIdAsync
Markets | GetMarketCandlesAsync, GetMarketsAsync, GetMarketSummariesAsync, GetMarketTickersAsync, GetMarketAsync, GetMarketSummaryAsync, GetMarketOrderBookAsync, GetMarketTradesAsync, GetMarketTickerAsync
Orders | GetOrderAsync, DeleteOrderAsync, CreateOrderAsync, GetOrdersAsync
Ping | PingAsync
Subaccounts | GetSubaccountsAsync, CreateSubaccountAsync, GetSubaccountAsync
Transfers | GetSendTransfersAsync, GetReceiveTransfersAsync, GetReceivedTransferAsync, CreateTransferAsync
Withdrawals | GetWithdrawalsAsync, GetWithdrawalByTxIdAsync, GetWithdrawalAsync, DeleteWithdrawalAsync, CreateWithdrawalAsync

## Usage

```csharp
using (var client = new BittrexClient("xz8omm6rpck7sx327064g0qcdba12e5p", "hpj2vw0rldh7q1ese03d8oh5tqfmixk6"))
{
    var markets = await client.GetMarketsAsync();
    var candles = await client.GetMarketCandlesAsync("ETH-BTC", CandleInterval.DAY_1);
}
```

### Async paged response

***Install System.Linq.Async***

```csharp
using System.Linq;

await foreach (var order in client.GetOrdersAsync(OrderState.Closed))
{
    System.Console.WriteLine(order.Id);
}
```

## Supported Frameworks
* netstandard2.1, providing [ASP.NET Core Support](https://www.nuget.org/packages/Topdev.Bittrex.Client/)

## Developer documentation
* [Bittrex API v3 (BETA)](https://bittrex.github.io/api/v3)

## Donations
Please feel free to donate to me. I'm not going to force you to donate, you can use my software completely free of charge and without limitation for any purpose you want. If you really want to give something to me then you are welcome to do so. I don't expect donations, nor do I insist that you give them.

**ETH** - 22a99ed4ebe631ff87332e6bcdcc6ef5ec01289f