using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class NCMResponse : BaseResponse
    {
        public IEnumerable<NCM> NCMs { get; set; }
    }
     
    public class NCM
    {
        [JsonPropertyName("codigo")]
        public string codigo { get; set; }
        [JsonPropertyName("descricao")]
        public string descricao { get; set; }
        [JsonPropertyName("data_inicio")]
        public string DataInicio { get; set; }
        [JsonPropertyName("data_fim")]
        public string DataFim { get; set; }
        [JsonPropertyName("tipo_ato")]
        public string TipoAto { get; set; }
        [JsonPropertyName("numero_ato")]
        public string NumeroAto { get; set; }
        [JsonPropertyName("ano_ato")]
        public string AnoAto { get; set; }
    }

}
