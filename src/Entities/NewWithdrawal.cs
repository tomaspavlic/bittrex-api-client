
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class NewWithdrawal
    {
        [JsonPropertyName("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonPropertyName("quantity")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Quantity { get; set; }

        [JsonPropertyName("cryptoAddress")]
        public string CryptoAddress { get; set; }

        [JsonPropertyName("cryptoAddressTag")]
        public string CryptoAddressTag { get; set; }
    }
}
