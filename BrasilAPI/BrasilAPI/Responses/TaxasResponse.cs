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
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "value")]
        public float Value { get; set; }
    }

}
