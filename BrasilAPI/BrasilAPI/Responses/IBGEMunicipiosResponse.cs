using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class IBGEMunicipiosResponse : BaseResponse
    {
        public IEnumerable<Municipio> Municipios { get; set; }
    }

    public class Municipio
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("codigo_ibge")]
        public string CodigoIBGE { get; set; }
    }
}
