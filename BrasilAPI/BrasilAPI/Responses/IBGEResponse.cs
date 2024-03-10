using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{

    public class IBGEResponse : BaseResponse
    {
        public IEnumerable<IBGE> IBGEs { get; set; }
    }

    public class IBGE
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        public UF UF { get => (UF)ID; }

        [JsonPropertyName("sigla")]
        public string Sigla { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("regiao")]
        public Regiao Regiao { get; set; }
    }

    [DataContract]
    public class Regiao
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("sigla")]
        public string Sigla { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }
    }

}
