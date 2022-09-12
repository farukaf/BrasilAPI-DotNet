using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SDKBrasilAPI.Responses
{
    public class TaxasResponse : BaseResponse
    {
        public IEnumerable<Taxa> Taxas { get; set; }
    }


    [DataContract]
    public class Taxa
    {
        [DataMember(Name = "nome")]
        public string Nome { get; set; }
        [DataMember(Name = "valor")]
        public float Valor { get; set; }
    }

}
