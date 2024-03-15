using System.Text.Json;
using SDKBrasilAPI.Responses;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
 

namespace SDKBrasilAPI
{
    public partial class BrasilAPI : IDisposable
    { 
         
        /// <summary>
        /// Lista as marca de veículos referente ao tipo de veículo
        /// </summary>
        /// <param name="tipoVeiculo">Os tipos suportados são caminhoes, carros e motos. Quando o tipo não é específicado são buscada as marcas de todos os tipos de veículos</param>
        /// <param name="tabelaReferencia">Código da tabela fipe de referência. Por padrão é utilizado o código da tabela fipe atual.</param>
        /// <returns></returns>
        public async Task<FIPEMarcasResponse> FIPE_Marcas(TipoVeiculo? tipoVeiculo = null, long? tabelaReferencia = null)
        {
            string baseUrl = $"{BASE_URL}/fipe/marcas/v1/{tipoVeiculo?.ToString() ?? ""}";

            if (tabelaReferencia != null)
            {
                baseUrl += "?tabela_referencia=" + tabelaReferencia.Value;
            }

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var fipeResponse = new FIPEMarcasResponse()
            {
                Marcas = CustomJsonSerializer<IEnumerable<MarcaVeiculo>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return fipeResponse;
        }

        /// <summary>
        /// Lista as tabelas de referência existentes.
        /// </summary>
        /// <returns></returns>
        public async Task<FIPETabelasResponse> FIPE_Tabelas()
        {
            string baseUrl = $"{BASE_URL}/fipe/tabelas/v1";


            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var fipeResponse = new FIPETabelasResponse()
            {
                Tabelas = CustomJsonSerializer<IEnumerable<TabelaFIPE>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return fipeResponse;
        }
        /// <summary>
        /// Consulta o preço do veículo segundo a tabela fipe.
        /// </summary>
        /// <param name="codigoFipe">Código fipe do veículo.</param>
        /// <param name="tabelaReferencia">Código da tabela fipe de referência. Por padrão é utilizado o código da tabela fipe atual.</param>
        /// <returns></returns>
        public async Task<FIPEPrecosResponse> FIPE_Precos(string codigoFipe, long? tabelaReferencia = null)
        {
            string baseUrl = $"{BASE_URL}/fipe/preco/v1/" + this.OnlyNumbers(codigoFipe);

            if (tabelaReferencia != null)
            {
                baseUrl += "?tabela_referencia=" + tabelaReferencia.Value;
            }

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var fipeResponse = new FIPEPrecosResponse()
            {
                Precos = CustomJsonSerializer<IEnumerable<PrecoFIPE>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return fipeResponse;
        }
         
    }
}
