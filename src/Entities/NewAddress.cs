using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class NewAddress
    {
        [JsonPropertyName("currencySymbol")]
        public string CurrencySymbol { get; set; }
    }
}