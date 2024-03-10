using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class DDDResponse : BaseResponse
    {
        [JsonPropertyName("state")]
        public UF UF { get; set; }

        [JsonPropertyName("cities")]
        public IEnumerable<string> Cities { get; set; }
    }
}
