using System;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class RegistroBrResponse : BaseResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("fqdn")]
        public string Fqdn { get; set; }
        [JsonPropertyName("fqdnace")]
        public string Fqdnace { get; set; }
        [JsonPropertyName("exempt")]
        public bool Exempt { get; set; }
        [JsonPropertyName("hosts")]
        public string[] Hosts { get; set; }
        [JsonPropertyName("publicationstatus")]
        public string PublicationStatus { get; set; }
        [JsonPropertyName("expiresat")]
        public DateTime ExpiresAt { get; set; }
        [JsonPropertyName("suggestions")]
        public string[] Suggestions { get; set; }
    }
}
