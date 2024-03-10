using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class FIPEMarcasResponse : BaseResponse
    {
        public IEnumerable<MarcaVeiculo> Marcas { get; set; }
    }

    public class FIPEPrecosResponse : BaseResponse
    {
        public IEnumerable<PrecoFIPE> Precos { get; set; }
    }
     
    public class FIPETabelasResponse : BaseResponse
    {
        public IEnumerable<TabelaFIPE> Tabelas { get; set; }
    }


    public class TabelaFIPE
    {
        [JsonPropertyName("codigo")]
        public int Codigo { get; set; }
        [JsonPropertyName("mes")]
        public string Mes { get; set; }
    }


    public class MarcaVeiculo
    {
        /// <summary>
        /// Nome da Marca
        /// </summary>
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Codigo da Marca
        /// </summary>
        [JsonPropertyName("valor")]
        public string Valor { get; set; }
    }

    [DataContract]
    public class PrecoFIPE
    {
        [JsonPropertyName("valor")]
        public string valor { get; set; }

        [JsonPropertyName("marca")]
        public string marca { get; set; }

        [JsonPropertyName("modelo")]
        public string modelo { get; set; }

        [JsonPropertyName("anoModelo")]
        public int anoModelo { get; set; }

        [JsonPropertyName("combustivel")]
        public string combustivel { get; set; }

        [JsonPropertyName("codigoFipe")]
        public string codigoFipe { get; set; }

        [JsonPropertyName("mesReferencia")]
        public string mesReferencia { get; set; }

        [JsonPropertyName("tipoVeiculo")]
        public int tipoVeiculo { get; set; }

        [JsonPropertyName("siglaCombustivel")]
        public string siglaCombustivel { get; set; }

        [JsonPropertyName("dataConsulta")]
        public string dataConsulta { get; set; }
    }

}
