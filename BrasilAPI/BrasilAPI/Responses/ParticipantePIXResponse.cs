using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class ParticipantePIXResponse : BaseResponse
    {
        public IEnumerable<ParticipantePIX> Parcipantes { get; set; }
    }

    public class ParticipantePIX
    {
        [JsonPropertyName("ispb")]
        public string ISPB { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("nome_reduzido")]
        public string NomeReduzido { get; set; }
        [JsonPropertyName("modalidade_participacao")]
        public string ModalidadeParticipacao { get; set; }
        [JsonPropertyName("tipo_participacao")]
        public string TipoParticipacao { get; set; }
        [JsonPropertyName("inicio_operacao")]
        public DateTime? InicioOperacao { get; set; }
    }
     
}
