using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class CptecCidadeResponse : BaseResponse
    {
        public IEnumerable<CptecCidade> Cidades { get; set; }

    }

    [DataContract]
    public class CptecCidade
    {
        [DataMember(Name = "id")]
        public int id { get; set; }
        [DataMember(Name = "nome")]
        public string nome { get; set; }
        [DataMember(Name = "estado")]
        public string estado { get; set; }
    } 
}
