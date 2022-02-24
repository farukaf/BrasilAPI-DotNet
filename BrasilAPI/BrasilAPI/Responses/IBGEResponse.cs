using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SDKBrasilAPI
{

    public class IBGEResponse : BaseResponse
    {
        public IEnumerable<IBGE> IBGEs { get; set; }
    }

    [DataContract]
    public class IBGE
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        public UF UF { get => (UF)ID; }

        [DataMember(Name = "sigla")]
        public string Sigla { get; set; }

        [DataMember(Name = "nome")]
        public string Nome { get; set; }

        [DataMember(Name = "regiao")]
        public Regiao Regiao { get; set; }
    }

    [DataContract]
    public class Regiao
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "sigla")]
        public string Sigla { get; set; }

        [DataMember(Name = "nome")]
        public string Nome { get; set; }
    }

}
