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
        [DataMember(Name = "location")]
        public Location Location { get; set; }
    }


    [DataContract]
    public class Location
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "coordinates")]
        public Coordinates Coordinates { get; set; }
    }


    [DataContract]
    public class Coordinates
    {
        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }
        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }
    }


}
