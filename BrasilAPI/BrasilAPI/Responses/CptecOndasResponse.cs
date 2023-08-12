using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SDKBrasilAPI.Responses
{
    [DataContract]
    public class CptecOndasResponse : BaseResponse
    {
        [DataMember(Name = "cidade")]
        public string Cidade { get; set; }
        [DataMember(Name = "estado")]
        public string Estado { get; set; }
        [DataMember(Name = "atualizado_em")]
        public string AtualizadoEm { get; set; }
        [DataMember(Name = "ondas")]
        public List<Onda> Ondas { get; set; }
    }

    [DataContract] 
    public class Onda
    {
        [DataMember(Name = "data")]
        public string Data { get; set; }
        [DataMember(Name = "dados_ondas")]
        public DadosOndas[] dados_ondas { get; set; }
    }

    [DataContract]
    public class DadosOndas
    {
        [DataMember(Name = "hora")]
        public string hora { get; set; }
        [DataMember(Name = "vento")]
        public float vento { get; set; }
        [DataMember(Name = "direcao_vento")]
        public string direcao_vento { get; set; }
        [DataMember(Name = "direcao_vento_desc")]
        public string direcao_vento_desc { get; set; }
        [DataMember(Name = "altura_onda")]
        public float? altura_onda { get; set; }
        [DataMember(Name = "direcao_onda")]
        public string direcao_onda { get; set; }
        [DataMember(Name = "direcao_onda_desc")]
        public string direcao_onda_desc { get; set; }
        [DataMember(Name = "agitation")]
        public string agitation { get; set; }
    }


}
