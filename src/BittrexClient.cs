using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Topdev.Bittrex
{
    public class BittrexClient : IBittrexClient, IDisposable
    {
        private readonly BittrexRestClient _restClient;

        public BittrexClient(string key, string secret)
        {
            _restClient = new BittrexRestClient(key, secret);
        }

        public BittrexClient() : this(null, null)
        {
            
        }

        #region Accounts

        public Task<Account> GetAccountAsync()
        {
            return _restClient.GetResponseAsync<Account>("account", HttpMethod.Get, true);
        }

        public Task<Volume> GetAccountVolumeAsync()
        {
            return _restClient.GetResponseAsync<Volume>("account/volume", HttpMethod.Get, true);
        }

        #endregion

        #region Markets
        public Task<Candle[]> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval)
        {
            return _restClient.GetResponseAsync<Candle[]>($"markets/{marketSymbol}/candles/{interval}/recent", HttpMethod.Get);
        }

        public Task<Candle[]> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval, int year, int month, int day)
        {
            // construct date from the parameters to validate them
            var date = new DateTime(year, month, day);

            return _restClient.GetResponseAsync<Candle[]>($"markets/{marketSymbol}/candles/{interval}/historical/{year}/{month}/{day}", HttpMethod.Get);
        }

        public Task<Market[]> GetMarketsAsync() => _restClient.GetResponseAsync<Market[]>("markets", HttpMethod.Get);

        public Task<Summary[]> GetMarketSummariesAsync() => _restClient.GetResponseAsync<Summary[]>("markets/summaries", HttpMethod.Get);

        public Task<Ticker[]> GetMarketTickersAsync() => _restClient.GetResponseAsync<Ticker[]>("markets/tickers", HttpMethod.Get);

        public Task<Market> GetMarketAsync(string marketSymbol) => _restClient.GetResponseAsync<Market>($"markets/{marketSymbol}", HttpMethod.Get);

        public Task<Summary> GetMarketSummaryAsync(string marketSymbol) => _restClient.GetResponseAsync<Summary>($"markets/{marketSymbol}/summary", HttpMethod.Get);

        public Task<OrderBook> GetMarketOrderBookAsync(string marketSymbol) => _restClient.GetResponseAsync<OrderBook>($"markets/{marketSymbol}/orderbook", HttpMethod.Get);

        public Task<Trade[]> GetMarketTradesAsync(string marketSymbol) => _restClient.GetResponseAsync<Trade[]>($"markets/{marketSymbol}/trades", HttpMethod.Get);

        public Task<Ticker> GetMarketTickerAsync(string marketSymbol) => _restClient.GetResponseAsync<Ticker>($"markets/{marketSymbol}/ticker", HttpMethod.Get);
        #endregion

        #region Ping
        public async Task<long> PingAsync()
        {
            var pong = await _restClient.GetResponseAsync<Pong>("ping", HttpMethod.Get);

            return pong.ServerTime;
        }
        #endregion

        #region Addresses

        public Task<Address[]> GetAddressesAsync()
        {
            return _restClient.GetResponseAsync<Address[]>("addresses", HttpMethod.Get, true);
        }

        public Task<Address> ProvisionNewAddressAsync(string currencySymbol)
        {
            var newAddress = new NewAddress
            {
                CurrencySymbol = currencySymbol
            };

            return _restClient.GetResponseAsync<Address>("addresses", HttpMethod.Post, true, newAddress);
        }

        public Task<Address> GetAddressAsync(string currencySymbol)
        {
            return _restClient.GetResponseAsync<Address>($"addresses/{currencySymbol}", HttpMethod.Get);
        }

        #endregion

        #region Balances
        public Task<Balance[]> GetBalancesAsync()
        {
            return _restClient.GetResponseAsync<Balance[]>("balances", HttpMethod.Get, true);
        }

        public Task<Balance> GetBalanceAsync(string currencySymbol)
        {
            return _restClient.GetResponseAsync<Balance>($"balances/{currencySymbol}", HttpMethod.Get, true);
        }
        #endregion

        #region Currencies
        public Task<Currency[]> GetCurrenciesAsync()
        {
            return _restClient.GetResponseAsync<Currency[]>("currencies", HttpMethod.Get);
        }

        public Task<Currency> GetCurrencyAsync(string symbol)
        {
            return _restClient.GetResponseAsync<Currency>($"currencies/{symbol}", HttpMethod.Get);
        }
        #endregion

        #region ConditionalOrders
        public Task<ConditionalOrder> GetConditionalOrderAsync(string orderId)
        {
            return _restClient.GetResponseAsync<ConditionalOrder>($"conditional-orders/{orderId}", HttpMethod.Get, true);
        }

        public Task DeleteConditionalOrderAsync(string orderId)
        {
            return _restClient.GetResponseAsync<ConditionalOrder>($"conditional-orders/{orderId}", HttpMethod.Delete, true);
        }

        public IAsyncEnumerable<ConditionalOrder> GetConditionalOrdersAsync(State state)
        {
            var stateName = Enum.GetName(typeof(State), state).ToLower();
            return _restClient.GetPagedResponseAsync<ConditionalOrder>($"conditional-orders/{stateName}", HttpMethod.Get, true);
        }

        public Task<ConditionalOrder> CreateConditionalOrderAsync(NewConditionalOrder newOrder)
        {
            return _restClient.GetResponseAsync<ConditionalOrder>("conditional-orders", HttpMethod.Post, true, newOrder);
        }
        #endregion

        #region Deposits
        public Task<IEnumerable<Deposit>> GetDepositsAsync(State state)
        {
            var stateName = Enum.GetName(typeof(State), state).ToLower();
            return _restClient.GetResponseAsync<IEnumerable<Deposit>>($"deposits/{stateName}", HttpMethod.Get, true);
        }

        public Task<Deposit> GetDepositAsync(string depositId)
        {
            return _restClient.GetResponseAsync<Deposit>($"deposits/{depositId}", HttpMethod.Get, true);
        }

        public Task<Deposit> GetDepositByTxIdAsync(string txId)
        {
            return _restClient.GetResponseAsync<Deposit>($"deposits/ByTxId/{txId}", HttpMethod.Get, true);
        }
        #endregion

        #region Orders
        public Task<Order> GetOrderAsync(string orderId)
        {
            return _restClient.GetResponseAsync<Order>($"orders/{orderId}", HttpMethod.Get, true);
        }

        public Task<Order> DeleteOrderAsync(string orderId)
        {
            return _restClient.GetResponseAsync<Order>($"orders/{orderId}", HttpMethod.Delete, true);
        }

        public Task<Order> CreateOrderAsync(NewOrder newOrder)
        {
            return _restClient.GetResponseAsync<Order>($"orders", HttpMethod.Post, true, newOrder);
        }

        public IAsyncEnumerable<Order> GetOrdersAsync(State state)
        {
            var stateName = Enum.GetName(typeof(State), state).ToLower();
            return _restClient.GetPagedResponseAsync<Order>($"orders/{stateName}", HttpMethod.Get, true);
        }
        #endregion

        #region Subaccounts
        public IAsyncEnumerable<Subaccount> GetSubaccountsAsync()
        {
            return _restClient.GetPagedResponseAsync<Subaccount>("subaccounts", HttpMethod.Get, true);
        }

        public Task<Subaccount> CreateSubaccountAsync(NewSubaccount newSubaccount)
        {
            return _restClient.GetResponseAsync<Subaccount>("subaccounts", HttpMethod.Get, true, newSubaccount);
        }

        public Task<Subaccount> GetSubaccountAsync(string subAccountId)
        {
            return _restClient.GetResponseAsync<Subaccount>($"subaccounts/{subAccountId}", HttpMethod.Get, true);
        }
        #endregion

        #region Transfers
        public IAsyncEnumerable<SentTransferInfo> GetSendTransfersAsync()
        {
            return _restClient.GetPagedResponseAsync<SentTransferInfo>("transfers/sent", HttpMethod.Get, true);
        }

        public IAsyncEnumerable<ReceivedTransferInfo> GetReceiveTransfersAsync()
        {
            return _restClient.GetPagedResponseAsync<ReceivedTransferInfo>("transfers/received", HttpMethod.Get, true);
        }

        public Task<ReceivedTransferInfo> GetReceivedTransferAsync(string transferId)
        {
            return _restClient.GetResponseAsync<ReceivedTransferInfo>($"transfers/{transferId}", HttpMethod.Get, true);
        }

        public Task<NewTransfer> CreateTransferAsync(NewTransfer newTransfer)
        {
            return _restClient.GetResponseAsync<NewTransfer>("transfers", HttpMethod.Post, true, newTransfer);
        }
        #endregion

        #region Withdrawals
        public Task<IEnumerable<Withdrawal>> GetWithdrawalsAsync(State state, string currencySymbol)
        {
            var stateName = Enum.GetName(typeof(State), state).ToLower();
            return _restClient.GetResponseAsync<IEnumerable<Withdrawal>>($"withdrawals/{stateName}", HttpMethod.Get, true);
        }

        public Task<Withdrawal> GetWithdrawalByTxIdAsync(string txId)
        {
            return _restClient.GetResponseAsync<Withdrawal>($"withdrawals/ByTxId/{txId}", HttpMethod.Get, true);
        }

        public Task<Withdrawal> GetWithdrawalAsync(string withdrawalId)
        {
            return _restClient.GetResponseAsync<Withdrawal>($"withdrawals/{withdrawalId}", HttpMethod.Get, true);
        }

        public Task DeleteWithdrawalAsync(string withdrawalId)
        {
            throw new NotImplementedException();
            // return _restClient.GetResponseAsync<Withdrawal>($"withdrawals/{withdrawalId}", HttpMethod.Get, true);
        }

        public Task<Withdrawal> CreateWithdrawalAsync(NewWithdrawal newWithdrawal)
        {
            return _restClient.GetResponseAsync<Withdrawal>($"withdrawals", HttpMethod.Post, true, newWithdrawal);
        }
        #endregion
    
        public void Dispose()
        {
            _restClient.Dispose();
        }
    }
}
