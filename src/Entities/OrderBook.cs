using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class OrderBook
    {
        [JsonPropertyName("bid")]
        public OrderBookEntry[] Bid { get; set; }

        [JsonPropertyName("ask")]
        public OrderBookEntry[] Ask { get; set; }
    }
}