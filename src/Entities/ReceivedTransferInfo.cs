
using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class ReceivedTransferInfo
    {
        [JsonPropertyName("fromSubaccountId")]
        public string FromSubaccountId { get; set; }

        [JsonPropertyName("fromMasterAccount")]
        public bool FromMasterAccount { get; set; }

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
