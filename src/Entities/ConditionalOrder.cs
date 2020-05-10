
using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    [Paginable]
    public class ConditionalOrder
    {
        [PageToken]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("marketSymbol")]
        public string MarketSymbol { get; set; }

        [JsonPropertyName("operand")]
        public string Operand { get; set; }

        [JsonPropertyName("triggerPrice")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double TriggerPrice { get; set; }

        [JsonPropertyName("trailingStopPercent")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double TrailingStopPercent { get; set; }

        [JsonPropertyName("createdOrderId")]
        public string CreatedOrderId { get; set; }

        [JsonPropertyName("orderToCreate")]
        public OrderToCreate OrderToCreate { get; set; }

        [JsonPropertyName("orderToCancel")]
        public OrderToCancel OrderToCancel { get; set; }

        [JsonPropertyName("clientConditionalOrderId")]
        public string ClientConditionalOrderId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("orderCreationErrorCode")]
        public string OrderCreationErrorCode { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonPropertyName("closedAt")]
        public DateTimeOffset ClosedAt { get; set; }
    }
}
