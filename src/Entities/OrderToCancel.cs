using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public partial class OrderToCancel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}