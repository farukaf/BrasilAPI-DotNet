using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SDKBrasilAPI.Responses
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
