using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class OrderBookEntry
    {
        [JsonPropertyName("quantity")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Quantity { get; set; }

        [JsonPropertyName("rate")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Rate { get; set; }
    }
}