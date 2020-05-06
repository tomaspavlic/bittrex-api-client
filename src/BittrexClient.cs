using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Topdev.Bittrex.Client.Models;

namespace Topdev.Bittrex
{
    public class BittrexClient : IBittrexClient
    {
        private static readonly string _baseApiUrl = "https://api.bittrex.com/v3/";

        private static HttpClient _httpClient = new HttpClient();

        public Task<Candle[]> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval)
        {
            return GetResponseAsync<Candle[]>($"{_baseApiUrl}/markets/{marketSymbol}/candles/31/recent?candleInterval={interval}");
        }

        public Task<Market[]> GetMarketsAsync()
        {
            return GetResponseAsync<Market[]>($"{_baseApiUrl}/markets");
        }

        private async Task<T> GetResponseAsync<T>(string url)
        {
            var result = await _httpClient.GetStreamAsync(url);
            var resultObject = await JsonSerializer.DeserializeAsync<T>(result);

            return resultObject;
        }
    }
}
