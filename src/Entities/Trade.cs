using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Trade
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("executedAt")]
        public DateTimeOffset ExecutedAt { get; set; }

        [JsonPropertyName("quantity")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Quantity { get; set; }

        [JsonPropertyName("rate")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Rate { get; set; }

        [JsonPropertyName("takerSide")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TradeOperation TakerSide { get; set; }
    }
}