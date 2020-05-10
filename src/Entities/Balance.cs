using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Balance
    {
        [JsonPropertyName("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonPropertyName("total")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public string Total { get; set; }

        [JsonPropertyName("available")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public string Available { get; set; }
    }
}