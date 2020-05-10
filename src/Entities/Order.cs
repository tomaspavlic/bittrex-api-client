using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Order
    {
        [PageToken]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("marketSymbol")]
        public string MarketSymbol { get; set; }

        [JsonPropertyName("direction")]
        public string Direction { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("quantity")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Quantity { get; set; }

        [JsonPropertyName("limit")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Limit { get; set; }

        [JsonPropertyName("ceiling")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Ceiling { get; set; }

        [JsonPropertyName("timeInForce")]
        public string TimeInForce { get; set; }

        [JsonPropertyName("clientOrderId")]
        public string ClientOrderId { get; set; }

        [JsonPropertyName("fillQuantity")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double FillQuantity { get; set; }

        [JsonPropertyName("commission")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Commission { get; set; }

        [JsonPropertyName("proceeds")]
        public string Proceeds { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonPropertyName("closedAt")]
        public DateTimeOffset ClosedAt { get; set; }
    }
}
