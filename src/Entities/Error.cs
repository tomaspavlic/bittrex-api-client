using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Error
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string, string> Data { get; set; }
    }
}