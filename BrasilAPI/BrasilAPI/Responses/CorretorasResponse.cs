
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SDKBrasilAPI.Responses
{
    public class CorretorasResponse : BaseResponse
    {
        public IEnumerable<Corretora> Corretoras { get; set; }

    }
     
    [DataContract]
    public class Corretora
    {
        [DataMember(Name = "bairro")]
        public string Bairro { get; set; }

        [DataMember(Name = "cep")]
        public string Cep { get; set; }

        [DataMember(Name = "cnpj")]
        public string Cnpj { get; set; }

        [DataMember(Name = "codigo_cvm")]
        public string CodigoCvm { get; set; }

        [DataMember(Name = "complemento")]
        public string Complemento { get; set; }

        [DataMember(Name = "data_inicio_situacao")]
        public string DataInicioSituacao { get; set; }

        [DataMember(Name = "data_patrimonio_liquido")]
        public string DataPatrimonioLiquido { get; set; }

        [DataMember(Name = "data_registro")]
        public string DataRegistro { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "logradouro")]
        public string Logradouro { get; set; }

        [DataMember(Name = "municipio")]
        public string Municipio { get; set; }

        [DataMember(Name = "nome_social")]
        public string NomeSocial { get; set; }

        [DataMember(Name = "nome_comercial")]
        public string NomeComercial { get; set; }

        [DataMember(Name = "pais")]
        public string Pais { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "telefone")]
        public string Telefone { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "uf")]
        public string Uf { get; set; }

        [DataMember(Name = "valor_patrimonio_liquido")]
        public string ValorPatrimonioLiquido { get; set; }
    }
}
