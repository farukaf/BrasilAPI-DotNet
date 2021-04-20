using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SDKBrasilAPI
{
    public class BankResponse : BaseResponse
    {
        public IEnumerable<Bank> Banks { get; set; }
    }

    [DataContract]
    public class Bank
    {
        [DataMember(Name = "ispb")]
        public string ISPB { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "code")]
        public int? Code { get; set; }

        [DataMember(Name = "fullName")]
        public string FullName { get; set; }
    }

}
