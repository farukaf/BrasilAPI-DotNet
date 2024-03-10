using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class CptecCidadeResponse : BaseResponse
    {
        public IEnumerable<CptecCidade> Cidades { get; set; }

    }

    public class CptecCidade
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("nome")]
        public string nome { get; set; }
        [JsonPropertyName("estado")]
        public string estado { get; set; }
    } 
}
