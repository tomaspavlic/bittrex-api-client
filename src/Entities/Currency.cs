using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Currency
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("coinType")]
        public string CoinType { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("minConfirmations")]
        public int MinConfirmations { get; set; }

        [JsonPropertyName("notice")]
        public string Notice { get; set; }

        [JsonPropertyName("txFee")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double TxFee { get; set; }

        [JsonPropertyName("logoUrl")]
        public string LogoUrl { get; set; }
    }
}