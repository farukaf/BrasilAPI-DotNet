using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SDKBrasilAPI.Responses
{
    [DataContract]
    public class RegistroBrResponse : BaseResponse
    {
        [DataMember(Name = "status_code")]
        public int StatusCode { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "fqdn")]
        public string Fqdn { get; set; }
        [DataMember(Name = "fqdnace")]
        public string Fqdnace { get; set; }
        [DataMember(Name = "exempt")]
        public bool Exempt { get; set; }
        [DataMember(Name = "hosts")]
        public string[] Hosts { get; set; }
        [DataMember(Name = "publicationstatus")]
        public string PublicationStatus { get; set; }
        [DataMember(Name = "expiresat")]
        public DateTime ExpiresAt { get; set; }
        [DataMember(Name = "suggestions")]
        public string[] Suggestions { get; set; }
    }
}
