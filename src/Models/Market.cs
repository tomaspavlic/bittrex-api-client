using System;
using System.Text.Json.Serialization;
using Topdev.Bittrex.Client.Converters;

namespace Topdev.Bittrex.Client.Models
{
    public class Market
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("baseCurrencySymbol")]
        public string BaseCurrencySymbol { get; set; }

        [JsonPropertyName("quoteCurrencySymbol")]
        public string QuoteCurrencySymbol { get; set; }

        [JsonPropertyName("minTradeSize")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double MinTradeSize { get; set; }

        [JsonPropertyName("precision")]
        public int Precision { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("notice")]
        public string Notice { get; set; }

        [JsonPropertyName("prohibitedIn")]
        public string[] ProhibitedIn { get; set; }
    }
}