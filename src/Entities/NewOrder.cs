
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class NewOrder
    {
        [JsonPropertyName("marketSymbol")]
        public string MarketSymbol { get; set; }

        [JsonPropertyName("direction")]
        public string Direction { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("quantity")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Quantity { get; set; }

        [JsonPropertyName("ceiling")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Ceiling { get; set; }

        [JsonPropertyName("limit")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Limit { get; set; }

        [JsonPropertyName("timeInForce")]
        public string TimeInForce { get; set; }

        [JsonPropertyName("clientOrderId")]
        public string ClientOrderId { get; set; }

        [JsonPropertyName("useAwards")]
        public bool UseAwards { get; set; }
    }
}
