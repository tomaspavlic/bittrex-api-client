using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Candle
    {
        [JsonPropertyName("startsAt")]
        public DateTimeOffset StartsAt { get; set; }

        [JsonPropertyName("open")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Open { get; set; }

        [JsonPropertyName("high")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double High { get; set; }

        [JsonPropertyName("low")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Low { get; set; }

        [JsonPropertyName("close")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Close { get; set; }

        [JsonPropertyName("volume")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Volume { get; set; }

        [JsonPropertyName("quoteVolume")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double QuoteVolume { get; set; }
    }
}
