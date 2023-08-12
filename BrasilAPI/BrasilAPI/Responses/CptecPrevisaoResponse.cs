using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SDKBrasilAPI.Responses
{
    [DataContract]
    public class CptecPrevisaoResponse : BaseResponse
    {
        [DataMember(Name = "cidade")]
        public string Cidade { get; set; }
        [DataMember(Name = "estado")]
        public string Estado { get; set; }
        [DataMember(Name = "atualizado_em")]
        public string AtualizadoEm { get; set; }
        [DataMember(Name = "clima")]
        public List<Clima> Clima { get; set; }
    }

    [DataContract]
    public class Clima
    {
        [DataMember(Name = "data")]
        public string Data { get; set; }
        [DataMember(Name = "condicao")]
        public string Condicao { get; set; }
        [DataMember(Name = "condicao_desc")]
        public string CondicaoDesc { get; set; }
        [DataMember(Name = "min")]
        public float? Min { get; set; }
        [DataMember(Name = "max")]
        public float? Max { get; set; }
        [DataMember(Name = "indice_uv")]
        public float? IndiceUv { get; set; }
    }

}
