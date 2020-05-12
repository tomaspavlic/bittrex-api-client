
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Subaccount
    {
        [PageToken]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }
    }
}
