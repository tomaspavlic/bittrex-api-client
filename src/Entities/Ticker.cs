using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Ticker
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("lastTradeRate")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double LastTradeRate { get; set; }

        [JsonPropertyName("bidRate")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double BidRate { get; set; }

        [JsonPropertyName("askRate")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double AskRate { get; set; }
    }
}
