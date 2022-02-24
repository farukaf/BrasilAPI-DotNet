using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SDKBrasilAPI
{
    [DataContract]
    public class CNPJResponse : BaseResponse
    {
        [DataMember(Name = "cnpj")]
        public string CNPJ { get; set; }
        [DataMember(Name = "identificador_matriz_filial")]
        public int IdentificadorMatrizFilial { get; set; }
        [DataMember(Name = "descricao_matriz_filial")]
        public string DescricaoMatrizFilial { get; set; }
        [DataMember(Name = "razao_social")]
        public string RazaoSocial { get; set; }
        [DataMember(Name = "nome_fantasia")]
        public string NomeFantasia { get; set; }
        [DataMember(Name = "situacao_cadastral")]
        public int SituacaoCadastral { get; set; }
        [DataMember(Name = "descricao_situacao_cadastral")]
        public string DescricaoSituacaoCadastral { get; set; }
        [DataMember(Name = "data_situacao_cadastral")]
        public string DataSituacaoCadastral { get; set; }
        [DataMember(Name = "motivo_situacao_cadastral")]
        public int MotivoSituacaoCadastral { get; set; }
        [DataMember(Name = "nome_cidade_exterior")]
        public object NomeCidadeExterior { get; set; }
        [DataMember(Name = "codigo_natureza_juridica")]
        public int CodigoNaturezaJuridica { get; set; }
        [DataMember(Name = "data_inicio_atividade")]
        public string DataInicioAtividade { get; set; }
        [DataMember(Name = "cnae_fiscal")]
        public int CNAE_Fiscal { get; set; }
        [DataMember(Name = "cnae_fiscal_descricao")]
        public string CNAE_Descricao { get; set; }
        [DataMember(Name = "descricao_tipo_logradouro")]
        public string DescricaoTipoLogradouro { get; set; }
        [DataMember(Name = "logradouro")]
        public string Logradouro { get; set; }
        [DataMember(Name = "numero")]
        public string Numero { get; set; }
        [DataMember(Name = "complemento")]
        public string Complemento { get; set; }
        [DataMember(Name = "bairro")]
        public string Bairro { get; set; }
        [DataMember(Name = "cep")]
        public int CEP { get; set; }
        [DataMember(Name = "uf")]
        public UF UF { get; set; }
        [DataMember(Name = "codigo_municipio")]
        public int CodigoMunicipio { get; set; }
        [DataMember(Name = "municipio")]
        public string Municipio { get; set; }
        [DataMember(Name = "ddd_telefone_1")]
        public string DDD_Telefone1 { get; set; }
        [DataMember(Name = "ddd_telefone_2")]
        public object DDD_Telefone2 { get; set; }
        [DataMember(Name = "ddd_fax")]
        public object DDD_Fax { get; set; }
        [DataMember(Name = "qualificacao_do_responsavel")]
        public int QualificacaoDoResponsavel { get; set; }
        [DataMember(Name = "capital_social")]
        public float CapitalSocial { get; set; }
        [DataMember(Name = "porte")]
        public string Porte { get; set; }
        [DataMember(Name = "descricao_porte")]
        public string DescricaoPorte { get; set; }
        [DataMember(Name = "opcao_pelo_simples")]
        public bool? OpcaoPeloSimples { get; set; }

        //TODO: ver qual o tipo de objeto pode vir aqui
        [DataMember(Name = "data_opcao_pelo_simples")]
        public object DataOpcaoPeloSimples { get; set; }

        //TODO: ver qual o tipo de objeto pode vir aqui
        [DataMember(Name = "data_exclusao_do_simples")]
        public object DataExclusaoDoSimples { get; set; }

        [DataMember(Name = "opcao_pelo_mei")]
        public bool? OpcaoPeloMEI { get; set; }

        //TODO: ver qual o tipo de objeto pode vir aqui
        [DataMember(Name = "situacao_especial")]
        public object SituacaoEspecial { get; set; }

        //TODO: ver qual o tipo de objeto pode vir aqui
        [DataMember(Name = "data_situacao_especial")]
        public object DataSituacaoEspecial { get; set; }

        [DataMember(Name = "cnaes_secundarios")]
        public IEnumerable<CNAE> CNAEsSecundarios { get; set; }

        /// <summary>
        /// Quadro Societários e de Administradores
        /// </summary>
        [DataMember(Name = "qsa")]
        public IEnumerable<SocioAdministrador> QSA { get; set; }
    }

    [DataContract]
    public class CNAE
    {
        [DataMember(Name = "codigo")]
        public int Codigo { get; set; }
        [DataMember(Name = "descricao")]
        public string Descricao { get; set; }
    }

    /// <summary>
    /// Societário / Administrador
    /// </summary>
    [DataContract]
    public class SocioAdministrador
    {
        [DataMember(Name = "descricao")]
        public int IdentificadorDeSocio { get; set; }
        [DataMember(Name = "nome_socio")]
        public string NomeSocio { get; set; }
        [DataMember(Name = "cnpj_cpf_do_socio")]
        public string CNPJ_CPF_DoSocio { get; set; }
        [DataMember(Name = "codigo_qualificacao_socio")]
        public int CodigoQualificacaoSocio { get; set; }
        [DataMember(Name = "percentual_capital_social")]
        public int PercentualCapitalSocial { get; set; }
        [DataMember(Name = "data_entrada_sociedade")]
        public string DataEntradaSociedade { get; set; }
        [DataMember(Name = "cpf_representante_legal")]
        public string CPF_RepresentanteLegal { get; set; }
        [DataMember(Name = "nome_representante_legal")]
        public string NomeRepresentanteLegal { get; set; }

        //TODO: ver qual o tipo de objeto pode vir aqui
        [DataMember(Name = "codigo_qualificacao_representante_legal")]
        public object CodigoQualificacaoRepresentanteLegal { get; set; }
    }

}
