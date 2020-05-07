using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Pong
    {
        [JsonPropertyName("serverTime")]
        public long ServerTime { get; set; }
    }
}