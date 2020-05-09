using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace Topdev.Bittrex
{
    public class AuthenticatedHttpRequestMessage : HttpRequestMessage
    {
        private readonly string _secret;
        private readonly string _key;

        public AuthenticatedHttpRequestMessage(HttpMethod method, string url, string key, string secret)
            : base(method, url)
        {
            _key = key;
            _secret = secret;

            ConstructAuthenticationHeaders();
        }

        private string GetContentHash()
        {
            var shaM = new SHA512Managed();
            var content = (Content != null) ? Content.ReadAsByteArrayAsync().Result : new byte[0];
            var contentHashBytes = shaM.ComputeHash(content);
            var contentHash = BitConverter.ToString(contentHashBytes).ToLower().Replace("-", string.Empty);

            return contentHash;
        }

        private string GetSignature(string timestamp, string url, string method, string contentHash, string subaccountId = "")
        {
            var sign = string.Join(string.Empty, timestamp, RequestUri.ToString(), "GET", contentHash, subaccountId);
            var secret = Encoding.UTF8.GetBytes(_secret);

            using (HMACSHA512 hmac = new HMACSHA512(secret))
            {
                var bytes = Encoding.UTF8.GetBytes(sign);
                var signed = hmac.ComputeHash(bytes);
                return BitConverter.ToString(signed).ToLower().Replace("-", string.Empty);
            }
        }

        private void ConstructAuthenticationHeaders()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            var contentHash = GetContentHash();
            var url = RequestUri.ToString();
            var method = Method.Method;
            var signature = GetSignature(timestamp, url, method, contentHash);
            
            
            Headers.Add("Api-Key", _key);
            Headers.Add("Api-Timestamp", timestamp);
            Headers.Add("Api-Content-Hash", contentHash);
            Headers.Add("Api-Signature", signature);
        }
    }
}