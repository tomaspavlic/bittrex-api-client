using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class OrderBook
    {
        [JsonPropertyName("bid")]
        public Order[] Bid { get; set; }

        [JsonPropertyName("ask")]
        public Order[] Ask { get; set; }
    }
}