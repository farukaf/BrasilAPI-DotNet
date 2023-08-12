using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class NCMResponse : BaseResponse
    {
        public IEnumerable<NCM> NCMs { get; set; }
    }

    [DataContract]
    public class NCM
    {
        [DataMember(Name = "codigo")]
        public string codigo { get; set; }
        [DataMember(Name = "descricao")]
        public string descricao { get; set; }
        [DataMember(Name = "data_inicio")]
        public string DataInicio { get; set; }
        [DataMember(Name = "data_fim")]
        public string DataFim { get; set; }
        [DataMember(Name = "tipo_ato")]
        public string TipoAto { get; set; }
        [DataMember(Name = "numero_ato")]
        public string NumeroAto { get; set; }
        [DataMember(Name = "ano_ato")]
        public string AnoAto { get; set; }
    }

}
