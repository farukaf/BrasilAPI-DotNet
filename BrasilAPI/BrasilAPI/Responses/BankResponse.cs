using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class BankResponse : BaseResponse
    {
        public IEnumerable<Bank> Banks { get; set; }
    }
     
    public class Bank
    {
        [JsonPropertyName("ispb")]
        public string ISPB { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public int? Code { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
    }

}
