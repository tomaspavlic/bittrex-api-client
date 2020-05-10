using System;
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
            return GetResponseAsync<Candle[]>($"{_baseApiUrl}/markets/{marketSymbol}/candles/{interval}/recent", HttpMethod.Get);
        }

        public Task<Candle[]> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval, int year, int month, int day)
        {
            // construct date from the parameters to validate them
            var date = new DateTime(year, month, day);

            return GetResponseAsync<Candle[]>($"{_baseApiUrl}/markets/{marketSymbol}/candles/{interval}/historical/{year}/{month}/{day}", HttpMethod.Get);
        }

        public Task<Market[]> GetMarketsAsync() => GetResponseAsync<Market[]>($"{_baseApiUrl}/markets", HttpMethod.Get);

        public Task<Summary[]> GetMarketSummariesAsync() => GetResponseAsync<Summary[]>($"{_baseApiUrl}/markets/summaries", HttpMethod.Get);

        public Task<Ticker[]> GetMarketTickersAsync() => GetResponseAsync<Ticker[]>($"{_baseApiUrl}/markets/tickers", HttpMethod.Get);

        public Task<Market> GetMarketAsync(string marketSymbol) => GetResponseAsync<Market>($"{_baseApiUrl}/markets/{marketSymbol}", HttpMethod.Get);

        public Task<Summary> GetMarketSummaryAsync(string marketSymbol) => GetResponseAsync<Summary>($"{_baseApiUrl}/markets/{marketSymbol}/summary", HttpMethod.Get);

        public Task<OrderBook> GetMarketOrderBookAsync(string marketSymbol) => GetResponseAsync<OrderBook>($"{_baseApiUrl}/markets/{marketSymbol}/orderbook", HttpMethod.Get);

        public Task<Trade[]> GetMarketTradesAsync(string marketSymbol) => GetResponseAsync<Trade[]>($"{_baseApiUrl}/markets/{marketSymbol}/trades", HttpMethod.Get);

        public Task<Ticker> GetMarketTickerAsync(string marketSymbol) => GetResponseAsync<Ticker>($"{_baseApiUrl}/markets/{marketSymbol}/ticker", HttpMethod.Get);

        public async Task<long> PingAsync()
        {
            var pong = await GetResponseAsync<Pong>($"{_baseApiUrl}/ping", HttpMethod.Get);

            return pong.ServerTime;
        }

        public Task<Account> GetAccountAsync()
        {
            return GetResponseAsync<Account>($"{_baseApiUrl}/account", HttpMethod.Get, true);
        }

        public Task<Volume> GetAccountVolumeAsync()
        {
            return GetResponseAsync<Volume>($"{_baseApiUrl}/account/volume", HttpMethod.Get, true);
        }

        public Task<Address[]> GetAddressesAsync()
        {
            return GetResponseAsync<Address[]>($"{_baseApiUrl}/addresses", HttpMethod.Get, true);
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

        private Task<T> GetResponseAsync<T>(string url, HttpMethod method, bool authentication = false)
        {
            var request = (authentication) ? new AuthenticatedHttpRequestMessage(method, url, _key, _secret) : new HttpRequestMessage(method, url);

            return GetResponseAsync<T>(request);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
