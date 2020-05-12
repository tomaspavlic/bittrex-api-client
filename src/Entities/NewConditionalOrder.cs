using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class NewConditionalOrder
    {
        [JsonPropertyName("marketSymbol")]
        public string MarketSymbol { get; set; }

        [JsonPropertyName("operand")]
        public string Operand { get; set; }

        [JsonPropertyName("triggerPrice")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double TriggerPrice { get; set; }

        [JsonPropertyName("trailingStopPercent")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double TrailingStopPercent { get; set; }

        [JsonPropertyName("orderToCreate")]
        public OrderToCreate OrderToCreate { get; set; }

        [JsonPropertyName("orderToCancel")]
        public OrderToCancel OrderToCancel { get; set; }

        [JsonPropertyName("clientConditionalOrderId")]
        public string ClientConditionalOrderId { get; set; }
    }
}
