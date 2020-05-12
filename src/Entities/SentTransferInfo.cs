
using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class SentTransferInfo
    {
        [JsonPropertyName("toSubaccountId")]
        public string ToSubaccountId { get; set; }

        [JsonPropertyName("toMasterAccount")]
        public bool ToMasterAccount { get; set; }

        [PageToken]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        [JsonPropertyName("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonPropertyName("amount")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Amount { get; set; }

        [JsonPropertyName("executedAt")]
        public DateTimeOffset ExecutedAt { get; set; }
    }
}
