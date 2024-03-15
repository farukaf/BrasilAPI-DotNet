using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{ 
    public class CEPResponse : BaseResponse
    {
        [JsonPropertyName("cep")]
        public string CEP { get; set; }
        [JsonPropertyName("state")]
        public UF UF { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("neighborhood")]
        public string Neighborhood { get; set; }
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("location")]
        public Location Location { get; set; }
    }


    public class Location
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; }
    }

    public class Coordinates
    {
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
    }


}
