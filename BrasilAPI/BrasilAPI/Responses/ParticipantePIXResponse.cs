using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class ParticipantePIXResponse : BaseResponse
    {
        public IEnumerable<ParticipantePIX> Parcipantes { get; set; }
    }

    [DataContract]
    public class ParticipantePIX
    {
        [DataMember(Name = "ispb")]
        public string ISPB { get; set; }
        [DataMember(Name = "nome")]
        public string Nome { get; set; }
        [DataMember(Name = "nome_reduzido")]
        public string NomeReduzido { get; set; }
        [DataMember(Name = "modalidade_participacao")]
        public string ModalidadeParticipacao { get; set; }
        [DataMember(Name = "tipo_participacao")]
        public string TipoParticipacao { get; set; }
        [DataMember(Name = "inicio_operacao")]
        public DateTime? InicioOperacao { get; set; }
    }
     
}
