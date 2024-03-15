using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class CptecPrevisaoResponse : BaseResponse
    {
        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }
        [JsonPropertyName("estado")]
        public string Estado { get; set; }
        [JsonPropertyName("atualizado_em")]
        public string AtualizadoEm { get; set; }
        [JsonPropertyName("clima")]
        public IEnumerable<Clima> Clima { get; set; }
    }

    public class Clima
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }
        [JsonPropertyName("condicao")]
        public string Condicao { get; set; }
        [JsonPropertyName("condicao_desc")]
        public string CondicaoDesc { get; set; }
        [JsonPropertyName("min")]
        public float? Min { get; set; }
        [JsonPropertyName("max")]
        public float? Max { get; set; }
        [JsonPropertyName("indice_uv")]
        public float? IndiceUv { get; set; }
    }

}
