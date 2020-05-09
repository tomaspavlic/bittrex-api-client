using System;
using System.Text.Json.Serialization;

namespace Topdev.Bittrex
{
    public class Account
    {
        [JsonPropertyName("subaccountId")]
        public string SubaccountId { get; set; }
    }
}