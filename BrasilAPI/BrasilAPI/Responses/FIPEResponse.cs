using SDKBrasilAPI;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SDKBrasilAPI
{
    public class FIPEMarcasResponse : BaseResponse
    {
        public IEnumerable<MarcaVeiculo> Marcas { get; set; }
    }

    public class FIPEPrecosResponse : BaseResponse
    {
        public IEnumerable<PrecoFIPE> Precos { get; set; }
    }
     
    public class FIPETabelasResponse : BaseResponse
    {
        public IEnumerable<TabelaFIPE> Tabelas { get; set; }
    }


    [DataContract]
    public class TabelaFIPE
    {
        [DataMember(Name = "codigo")]
        public int Codigo { get; set; }
        [DataMember(Name = "mes")]
        public string Mes { get; set; }
    }


    [DataContract]
    public class MarcaVeiculo
    {
        /// <summary>
        /// Nome da Marca
        /// </summary>
        [DataMember(Name = "nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Codigo da Marca
        /// </summary>
        [DataMember(Name = "valor")]
        public string Valor { get; set; }
    }

    [DataContract]
    public class PrecoFIPE
    {
        [DataMember(Name = "valor")]
        public string valor { get; set; }

        [DataMember(Name = "marca")]
        public string marca { get; set; }

        [DataMember(Name = "modelo")]
        public string modelo { get; set; }

        [DataMember(Name = "anoModelo")]
        public int anoModelo { get; set; }

        [DataMember(Name = "combustivel")]
        public string combustivel { get; set; }

        [DataMember(Name = "codigoFipe")]
        public string codigoFipe { get; set; }

        [DataMember(Name = "mesReferencia")]
        public string mesReferencia { get; set; }

        [DataMember(Name = "tipoVeiculo")]
        public int tipoVeiculo { get; set; }

        [DataMember(Name = "siglaCombustivel")]
        public string siglaCombustivel { get; set; }

        [DataMember(Name = "dataConsulta")]
        public string dataConsulta { get; set; }
    }

}
