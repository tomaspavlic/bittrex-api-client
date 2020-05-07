using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Summary
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("lastTradeRate")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double High { get; set; }

        [JsonPropertyName("low")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Low { get; set; }

        [JsonPropertyName("volume")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Volume { get; set; }

        [JsonPropertyName("baseVolume")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double BaseVolume { get; set; }

        [JsonPropertyName("quoteVolume")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double QuoteVolume { get; set; }

        [JsonPropertyName("percentChange")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double PercentChange { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
