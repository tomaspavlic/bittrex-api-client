using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Topdev.Bittrex
{
    public class BittrexClient : IBittrexClient, IDisposable
    {
        private static readonly string _baseApiUrl = "https://api.bittrex.com/v3";

        private static HttpClient _httpClient = new HttpClient();
        private static string _key;
        private static string _secret;

        public BittrexClient(string key, string secret)
        {
            _key = key;
            _secret = secret;
        }

        public BittrexClient()
        {

        }


        public Task<Candle[]> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval)
        {
            return GetResponseAsync<Candle[]>($"markets/{marketSymbol}/candles/{interval}/recent", HttpMethod.Get);
        }

        public Task<Candle[]> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval, int year, int month, int day)
        {
            // construct date from the parameters to validate them
            var date = new DateTime(year, month, day);

            return GetResponseAsync<Candle[]>($"markets/{marketSymbol}/candles/{interval}/historical/{year}/{month}/{day}", HttpMethod.Get);
        }

        public Task<Market[]> GetMarketsAsync() => GetResponseAsync<Market[]>("markets", HttpMethod.Get);

        public Task<Summary[]> GetMarketSummariesAsync() => GetResponseAsync<Summary[]>("markets/summaries", HttpMethod.Get);

        public Task<Ticker[]> GetMarketTickersAsync() => GetResponseAsync<Ticker[]>("markets/tickers", HttpMethod.Get);

        public Task<Market> GetMarketAsync(string marketSymbol) => GetResponseAsync<Market>($"markets/{marketSymbol}", HttpMethod.Get);

        public Task<Summary> GetMarketSummaryAsync(string marketSymbol) => GetResponseAsync<Summary>($"markets/{marketSymbol}/summary", HttpMethod.Get);

        public Task<OrderBook> GetMarketOrderBookAsync(string marketSymbol) => GetResponseAsync<OrderBook>($"markets/{marketSymbol}/orderbook", HttpMethod.Get);

        public Task<Trade[]> GetMarketTradesAsync(string marketSymbol) => GetResponseAsync<Trade[]>($"markets/{marketSymbol}/trades", HttpMethod.Get);

        public Task<Ticker> GetMarketTickerAsync(string marketSymbol) => GetResponseAsync<Ticker>($"markets/{marketSymbol}/ticker", HttpMethod.Get);

        public async Task<long> PingAsync()
        {
            var pong = await GetResponseAsync<Pong>("ping", HttpMethod.Get);

            return pong.ServerTime;
        }

        public Task<Account> GetAccountAsync()
        {
            return GetResponseAsync<Account>("account", HttpMethod.Get, true);
        }

        public Task<Volume> GetAccountVolumeAsync()
        {
            return GetResponseAsync<Volume>("account/volume", HttpMethod.Get, true);
        }

        public Task<Address[]> GetAddressesAsync()
        {
            return GetResponseAsync<Address[]>("addresses", HttpMethod.Get, true);
        }

        public Task<Address> ProvisionNewAddressAsync(string currencySymbol)
        {
            var newAddress = new NewAddress
            {
                CurrencySymbol = currencySymbol
            };

            return GetResponseAsync<Address>("addresses", HttpMethod.Post, true, newAddress);
        }

        public Task<Address> GetAddressAsync(string currencySymbol)
        {
            return GetResponseAsync<Address>($"addresses/{currencySymbol}", HttpMethod.Get);
        }

        public Task<Balance[]> GetBalancesAsync()
        {
            return GetResponseAsync<Balance[]>("balances", HttpMethod.Get, true);
        }

        public Task<Balance> GetBalanceAsync(string currencySymbol)
        {
            return GetResponseAsync<Balance>($"balances/{currencySymbol}", HttpMethod.Get, true);
        }

        public Task<Currency[]> GetCurrenciesAsync()
        {
            return GetResponseAsync<Currency[]>("currencies", HttpMethod.Get);
        }

        public Task<Currency> GetCurrencyAsync(string symbol)
        {
            return GetResponseAsync<Currency>($"currencies/{symbol}", HttpMethod.Get);
        }

        private async Task<T> GetResponseAsync<T>(HttpRequestMessage message)
        {
            var result = await _httpClient.SendAsync(message);
            var resultStream = await result.Content.ReadAsStreamAsync();

            if (result.IsSuccessStatusCode)
            {
                var resultObject = await JsonSerializer.DeserializeAsync<T>(resultStream);
                return resultObject;
            }
            else
            {
                var error = await JsonSerializer.DeserializeAsync<Error>(resultStream);
                throw new BittrexApiException(error);
            }
        }

        private async Task<T[]> GetPagedResponseAsync<T>(string path, HttpMethod method, bool authentication = false, object content = null)
        {
            var list = new List<T>();
            var response = await GetResponseAsync<T[]>(path, method, authentication, content);
            var nextPageTokenProperty = typeof(T).GetProperties().FirstOrDefault(x => x.GetCustomAttributes(true).Any(c => c is PageTokenAttribute));
            list.AddRange(response);

            while (response.Length > 0)
            {
                T lastElement = response[^0];
                var nextPageToken = nextPageTokenProperty.GetValue(lastElement);

                var url = $"{path}?nextPageToken={nextPageToken}";
                response = await GetResponseAsync<T[]>(url, method, authentication, content);
                list.AddRange(response);
            }

            return list.ToArray();
        }

        private Task<T> GetResponseAsync<T>(string path, HttpMethod method, bool authentication = false, object content = null)
        {
            var url = $"{_baseApiUrl}/{path}";
            var request = (authentication) ? new AuthenticatedHttpRequestMessage(method, url, _key, _secret) : new HttpRequestMessage(method, url);

            if (content != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(content));
            }

            return GetResponseAsync<T>(request);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public Task<ConditionalOrder> GetConditionalOrderAsync(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConditionalOrderAsync(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<ConditionalOrder[]> GetConditionalOrdersAsync(ConditionalOrderState state)
        {
            var stateName = Enum.GetName(typeof(ConditionalOrderState), state).ToLower();
            return GetPagedResponseAsync<ConditionalOrder>($"conditional-orders/{stateName}", HttpMethod.Get, true);
        }

        public Task<ConditionalOrder> CreateConditionalOrderAsync(ConditionalOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
