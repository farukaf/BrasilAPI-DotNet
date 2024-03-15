using SDKBrasilAPI.Responses;
using System.Threading.Tasks;

namespace SDKBrasilAPI
{
    public interface IBrasilAPI
    {
        Task<BankResponse> Banks();
        Task<BankResponse> Banks(int code);
        Task<CEPResponse> CEP(string cep);
        Task<CEPResponse> CEP_V2(string cep);
        Task<CNPJResponse> CNPJ(string cnpj);
        Task<CorretorasResponse> Corretoras();
        Task<CorretorasResponse> Corretoras(string cnpj);
        Task<CptecCidadeResponse> CptecCidade();
        Task<CptecCidadeResponse> CptecCidade(string cidadeNome);
        Task<CptecClimaResponse> CptecClimaAeroporto(string icaoCodigo);
        Task<CptecClimaResponse> CptecClimaCapital();
        Task<CptecPrevisaoResponse> CptecClimaPrevisao(int cidadeCodigo);
        Task<CptecPrevisaoResponse> CptecClimaPrevisao(int cidadeCodigo, int dias);
        Task<CptecOndasResponse> CptecOndas(int cidadeCodigo);
        Task<CptecOndasResponse> CptecOndas(int cidadeCodigo, int dias);
        Task<DDDResponse> DDD(int ddd);
        Task<FeriadosResponse> Feriados(int ano);
        Task<FIPEMarcasResponse> FIPE_Marcas(TipoVeiculo? tipoVeiculo = null, long? tabelaReferencia = null);
        Task<FIPEPrecosResponse> FIPE_Precos(string codigoFipe, long? tabelaReferencia = null);
        Task<FIPETabelasResponse> FIPE_Tabelas();
        Task<IBGEMunicipiosResponse> IBGE_Municipios(UF uf);
        Task<IBGEResponse> IBGE_UF();
        Task<IBGEResponse> IBGE_UF(int code);
        Task<IBGEResponse> IBGE_UF(string code);
        Task<IBGEResponse> IBGE_UF(UF code);
        Task<NCMResponse> NCM();
        Task<NCMResponse> NCM(string codigo);
        Task<NCMResponse> NCM_Busca(string codigo);
        Task<ParticipantePIXResponse> ParticipantesPIX();
        Task<RegistroBrResponse> RegistroBR(string dominio);
        Task<TaxasResponse> Taxas();
        Task<TaxasResponse> Taxas(string sigla = "");


        void Dispose();
    }
}