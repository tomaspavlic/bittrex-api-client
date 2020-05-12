
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class NewTransfer
    {
        [JsonPropertyName("toSubaccountId")]
        public string ToSubaccountId { get; set; }

        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        [JsonPropertyName("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonPropertyName("amount")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Amount { get; set; }

        [JsonPropertyName("toMasterAccount")]
        public bool ToMasterAccount { get; set; }
    }
}
