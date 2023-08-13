using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class CptecClimaResponse : BaseResponse
    {
        public IEnumerable<CptecClima> Climas { get; set; }
    }

    [DataContract]
    public class CptecClima
    {
        [DataMember(Name = "umidade")]
        public int? Umidade { get; set; }
        [DataMember(Name = "intensidade")]
        public string Intensidade { get; set; }
        [DataMember(Name = "codigo_icao")]
        public string CodigoIcao { get; set; }
        [DataMember(Name = "pressao_atmosferica")]
        public int? PressaoAtmosferica { get; set; }
        [DataMember(Name = "vento")]
        public int? Vento { get; set; }
        [DataMember(Name = "direcao_vento")]
        public int? DirecaoVento { get; set; }
        [DataMember(Name = "condicao")]
        public string Condicao { get; set; }
        [DataMember(Name = "condicao_desc")]
        public string CondicaoDesc { get; set; }
        [DataMember(Name = "temp")]
        public int? Temp { get; set; }
        [DataMember(Name = "atualizado_em")]
        public DateTime? AtualizadoEm { get; set; }
    }

}
