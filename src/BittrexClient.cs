using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Topdev.Bittrex
{
    public class BittrexClient : IBittrexClient
    {
        private static readonly string _baseApiUrl = "https://api.bittrex.com/v3/";

        private static HttpClient _httpClient = new HttpClient();

        public Task<Candle[]> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval)
        {
            return GetResponseAsync<Candle[]>($"{_baseApiUrl}/markets/{marketSymbol}/candles/{interval}/recent");
        }

        public Task<Candle[]> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval, int year, int month, int day)
        {
            // construct date from the parameters to validate them
            var date = new DateTime(year, month, day);

            return GetResponseAsync<Candle[]>($"{_baseApiUrl}/markets/{marketSymbol}/candles/{interval}/historical/{year}/{month}/{day}");
        }

        public Task<Market[]> GetMarketsAsync() => GetResponseAsync<Market[]>($"{_baseApiUrl}/markets");

        public Task<Summary[]> GetMarketSummariesAsync() => GetResponseAsync<Summary[]>($"{_baseApiUrl}/markets/summaries");

        public Task<Ticker[]> GetMarketTickersAsync() => GetResponseAsync<Ticker[]>($"{_baseApiUrl}/markets/tickers");

        public Task<Market> GetMarketAsync(string marketSymbol) => GetResponseAsync<Market>($"{_baseApiUrl}/markets/{marketSymbol}");

        public Task<Summary> GetMarketSummaryAsync(string marketSymbol) => GetResponseAsync<Summary>($"{_baseApiUrl}/markets/{marketSymbol}/summary");

        public Task<OrderBook> GetMarketOrderBookAsync(string marketSymbol) => GetResponseAsync<OrderBook>($"{_baseApiUrl}/markets/{marketSymbol}/orderbook");

        public Task<Trade[]> GetMarketTradesAsync(string marketSymbol) => GetResponseAsync<Trade[]>($"{_baseApiUrl}/markets/{marketSymbol}/trades");

        public Task<Ticker> GetMarketTickerAsync(string marketSymbol) => GetResponseAsync<Ticker>($"{_baseApiUrl}/markets/{marketSymbol}/ticker");

        private async Task<T> GetResponseAsync<T>(string url)
        {
            var result = await _httpClient.GetAsync(url);
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
    }
}
