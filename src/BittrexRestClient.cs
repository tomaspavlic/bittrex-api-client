using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Topdev.Bittrex
{
    internal class BittrexRestClient : IDisposable
    {
        private readonly string _key;

        private readonly string _secret;

        private static HttpClient _httpClient = new HttpClient();

        private static readonly string _baseApiUrl = "https://api.bittrex.com/v3";

        public BittrexRestClient(string key, string secret)
        {
            _secret = secret;
            _key = key;
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

        public async IAsyncEnumerable<T> GetPagedResponseAsync<T>(string path, HttpMethod method, bool authentication = false, object content = null)
        {
            T[] response = null;
            var nextPageTokenProperty = typeof(T).GetProperties().FirstOrDefault(x => x.GetCustomAttributes(true).Any(c => c is PageTokenAttribute));

            if (nextPageTokenProperty == null)
                throw new InvalidOperationException("Paginated resource must have page token attribute set.");

            do
            {
                var url = (response == null) ? path : $"{path}?nextPageToken={nextPageTokenProperty.GetValue(response[^1])}";
                response = await GetResponseAsync<T[]>(url, method, authentication, content);

                foreach (var r in response)
                    yield return r;

            } while (response.Length > 0);
        }

        public Task<T> GetResponseAsync<T>(string path, HttpMethod method, bool authentication = false, object content = null)
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
    }
}