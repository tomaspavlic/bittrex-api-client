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

        private readonly string _baseApiUrl;

        private static HttpClient _httpClient = new HttpClient();

        public BittrexRestClient(string key, string secret, string baseApiUrl = "https://api.bittrex.com/v3")
        {
            _secret = secret;
            _key = key;
            _baseApiUrl = baseApiUrl;
        }

        /// <summary>
        /// Get response using message request containing all request information.
        /// </summary>
        /// <param name="message"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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

        /// <summary>
        /// Get paged result for resources with pageable objects.
        /// </summary>
        /// <param name="path"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async IAsyncEnumerable<T> GetPagedResponseAsync<T>(string path)
        {
            T[] response = null;
            var nextPageTokenProperty = PageTokenAttribute.GetPageTokenProperty<T>();

            do
            {
                var url = (response == null) ? path : $"{path}?nextPageToken={nextPageTokenProperty.GetValue(response[^1])}";
                response = await GetResponseAsync<T[]>(url, HttpMethod.Get, true);

                foreach (var r in response)
                    yield return r;

            } while (response.Length > 0);
        }

        /// <summary>
        /// Get a response.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="method"></param>
        /// <param name="authentication"></param>
        /// <param name="content"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> GetResponseAsync<T>(string path, HttpMethod method, bool authentication = false, object content = null)
        {
            var url = $"{_baseApiUrl}/{path}";
            HttpRequestMessage request;

            if (authentication)
            {
                if (string.IsNullOrWhiteSpace(_key) || string.IsNullOrWhiteSpace(_secret))
                    throw new UnauthorizedAccessException("This request requires authentication.");

                request = new AuthenticatedHttpRequestMessage(method, url, _key, _secret);
            }
            else
            {
                request = new HttpRequestMessage(method, url);
            }

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