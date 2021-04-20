using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SDKBrasilAPI
{
    public class FeriadosResponse : BaseResponse
    {
        public IEnumerable<Feriado> Feriados { get; set; }
    }

    [DataContract]
    public class Feriado
    {
        [DataMember(Name = "date")]
        public DateTime? Date { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
