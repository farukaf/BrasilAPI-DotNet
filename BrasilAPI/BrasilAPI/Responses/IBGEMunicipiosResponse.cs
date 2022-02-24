using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SDKBrasilAPI
{
    public class IBGEMunicipiosResponse : BaseResponse
    {
        public IEnumerable<Municipio> Municipios { get; set; }
    }
    [DataContract]
    public class Municipio
    {
        [DataMember(Name = "nome")]
        public string Nome { get; set; }
        [DataMember(Name = "codigo_ibge")]
        public string CodigoIBGE { get; set; }
    }
}
