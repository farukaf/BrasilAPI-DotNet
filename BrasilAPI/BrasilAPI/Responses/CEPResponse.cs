using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SDKBrasilAPI
{
    [DataContract]
    public class CEPResponse : BaseResponse
    {
        [DataMember(Name = "cep")]
        public string CEP { get; set; }
        [DataMember(Name = "state")]
        public UF UF { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "neighborhood")]
        public string Neighborhood { get; set; }
        [DataMember(Name = "street")]
        public string Street { get; set; }
    }

}
