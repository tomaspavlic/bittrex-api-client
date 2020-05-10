using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public partial class OrderToCreate
    {
        [JsonPropertyName("marketSymbol")]
        public string MarketSymbol { get; set; }

        [JsonPropertyName("direction")]
        public string Direction { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("quantity")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public string Quantity { get; set; }

        [JsonPropertyName("ceiling")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public string Ceiling { get; set; }

        [JsonPropertyName("limit")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public string Limit { get; set; }

        [JsonPropertyName("timeInForce")]
        public string TimeInForce { get; set; }

        [JsonPropertyName("clientOrderId")]
        public string ClientOrderId { get; set; }

        [JsonPropertyName("useAwards")]
        public bool UseAwards { get; set; }
    }
}