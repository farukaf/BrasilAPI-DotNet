using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SDKBrasilAPI
{
    [DataContract]
    public class DDDResponse : BaseResponse
    {
        [DataMember(Name = "state")]
        public UF UF { get; set; }

        [DataMember(Name = "cities")]
        public IEnumerable<string> Cities { get; set; }
    }
}
