using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class CptecOndasResponse : BaseResponse
    {
        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }
        [JsonPropertyName("estado")]
        public string Estado { get; set; }
        [JsonPropertyName("atualizado_em")]
        public string AtualizadoEm { get; set; }
        [JsonPropertyName("ondas")]
        public IEnumerable<Onda> Ondas { get; set; }
    }

    public class Onda
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }
        [JsonPropertyName("dados_ondas")]
        public DadosOndas[] dados_ondas { get; set; }
    }

    public class DadosOndas
    {
        [JsonPropertyName("hora")]
        public string hora { get; set; }
        [JsonPropertyName("vento")]
        public float vento { get; set; }
        [JsonPropertyName("direcao_vento")]
        public string direcao_vento { get; set; }
        [JsonPropertyName("direcao_vento_desc")]
        public string direcao_vento_desc { get; set; }
        [JsonPropertyName("altura_onda")]
        public float? altura_onda { get; set; }
        [JsonPropertyName("direcao_onda")]
        public string direcao_onda { get; set; }
        [JsonPropertyName("direcao_onda_desc")]
        public string direcao_onda_desc { get; set; }
        [JsonPropertyName("agitation")]
        public string agitation { get; set; }
    }


}
