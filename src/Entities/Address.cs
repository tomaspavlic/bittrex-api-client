using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Address
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonPropertyName("cryptoAddress")]
        public string CryptoAddress { get; set; }

        [JsonPropertyName("cryptoAddressTag")]
        public string CryptoAddressTag { get; set; }
    }
}