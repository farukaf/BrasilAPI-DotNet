using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class TaxasResponse : BaseResponse
    {
        public IEnumerable<Taxa> Taxas { get; set; }
    }

    public class Taxa
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("valor")]
        public float Valor { get; set; }
    }

}
