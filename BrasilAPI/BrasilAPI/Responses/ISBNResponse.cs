using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class ISBNResponse : BaseResponse
    {
        [JsonPropertyName("isbn")]
        public string Isbn { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; }
        
        [JsonPropertyName("authors")]
        public List<string> Authors { get; set; }
        
        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }
        
        [JsonPropertyName("synopsis")]
        public string Synopsis { get; set; }
        
        [JsonPropertyName("dimensions")]
        public IsbnDimensions IsbnDimensions { get; set; }
        
        [JsonPropertyName("year")]
        public int? Year { get; set; }
        
        [JsonPropertyName("format")]
        public IsbnFormat Format { get; set; }
        
        [JsonPropertyName("page_count")]
        public int? PageCount { get; set; }
        
        [JsonPropertyName("subjects")]
        public List<string> Subjects { get; set; }
        
        [JsonPropertyName("location")]
        public string Location { get; set; }
        
        [JsonPropertyName("retail_price")]
        public IsbnPrice RetailPrice { get; set; }
        
        [JsonPropertyName("cover_url")]
        public string CoverUrl { get; set; }
        
        [JsonPropertyName("provider")]
        public IsbnProviders Provider { get; set; }
        
    }

    public class IsbnPrice
    {
        
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
    }

    public class IsbnDimensions
    {
        
        [JsonPropertyName("width")]
        public double Width { get; set; }
        
        [JsonPropertyName("height")]
        public double Height { get; set; }
        
        [JsonPropertyName("unit")]
        public IsbnDimensionUnit Unit { get; set; }
    }
}