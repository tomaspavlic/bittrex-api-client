using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Volume
    {
        [JsonPropertyName("updated")]
        public DateTimeOffset Updated { get; set; }

        [JsonPropertyName("volume30days")]
        [JsonConverter(typeof(DoubleConverterWithStringSupport))]
        public double Volume30days { get; set; }
    }
}