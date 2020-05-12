
using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Withdrawal
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonPropertyName("quantity")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Quantity { get; set; }

        [JsonPropertyName("cryptoAddress")]
        public string CryptoAddress { get; set; }

        [JsonPropertyName("cryptoAddressTag")]
        public string CryptoAddressTag { get; set; }

        [JsonPropertyName("txCost")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double TxCost { get; set; }

        [JsonPropertyName("txId")]
        public string TxId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("completedAt")]
        public DateTimeOffset CompletedAt { get; set; }
    }
}
