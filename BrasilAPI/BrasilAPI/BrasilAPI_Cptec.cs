using Newtonsoft.Json;
using SDKBrasilAPI.Responses;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
 

namespace SDKBrasilAPI
{
    public partial class BrasilAPI : IDisposable
    { 
        
        /// <summary>
        /// Abstração e normalização de dados provenientes da CPTEC. Fonte oficial: CPTEC/INPE
        /// <para/>
        /// Retorna listagem com todas as cidades junto a seus respectivos códigos presentes nos serviços da CPTEC. 
        /// O Código destas cidades será utilizado para os serviços de meteorologia e a ondas (previsão oceânica) fornecido pelo centro. 
        /// Leve em consideração que o WebService do CPTEC as vezes é instável, então se não encontrar uma determinada cidade na listagem completa, tente buscando por parte de seu nome no endpoint de busca.
        /// </summary>
        /// <returns></returns>
        public async Task<CptecCidadeResponse> CptecCidade()
        {
            string baseUrl = $"{BASE_URL}/cptec/v1/cidade";
            var httpResponse = await Client.GetAsync(baseUrl);
            await EnsureSuccess(httpResponse, baseUrl);
            var json = await httpResponse.Content.ReadAsStringAsync();

            var response = new CptecCidadeResponse()
            {
                Cidades = JsonConvert.DeserializeObject<IEnumerable<CptecCidade>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return response;
        }

        /// <summary>
        /// Abstração e normalização de dados provenientes da CPTEC. Fonte oficial: CPTEC/INPE
        /// <para/>
        /// Retorna listagem com todas as cidades correspondentes ao termo pesquisado junto a seus respectivos códigos presentes nos serviços da CPTEC.
        /// O Código destas cidades será utilizado para os serviços de meteorologia e a ondas (previsão oceânica) fornecido pelo centro.
        /// </summary> 
        /// <param name="cidadeNome">Nome ou parte do nome da cidade a ser buscada</param>
        /// <returns></returns>
        public async Task<CptecCidadeResponse> CptecCidade(string cidadeNome)
        {
            string baseUrl = $"{BASE_URL}/cptec/v1/cidade/{cidadeNome}";
            var httpResponse = await Client.GetAsync(baseUrl);
            await EnsureSuccess(httpResponse, baseUrl);
            var json = await httpResponse.Content.ReadAsStringAsync();

            var response = new CptecCidadeResponse()
            {
                Cidades = JsonConvert.DeserializeObject<IEnumerable<CptecCidade>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return response;
        }

        /// <summary>
        /// Condições atuais nas capitais
        /// <para/>
        /// Retorna condições meteorológicas atuais nas capitais do país, com base nas estações de solo de seu aeroporto.
        /// </summary>
        /// <returns></returns>
        public async Task<CptecClimaResponse> CptecClimaCapital()
        {
            string baseUrl = $"{BASE_URL}/cptec/v1/clima/capital";
            var httpResponse = await Client.GetAsync(baseUrl);
            await EnsureSuccess(httpResponse, baseUrl);
            var json = await httpResponse.Content.ReadAsStringAsync();

            var response = new CptecClimaResponse()
            {
                Climas = JsonConvert.DeserializeObject<IEnumerable<CptecClima>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return response;
        }


        /// <summary>
        /// Condições atuais no aeroporto 
        /// Retorna condições meteorológicas atuais no aeroporto solicitado.Este endpoint utiliza o código ICAO(4 dígitos) do aeroporto.
        /// </summary>
        /// <param name="icaoCodigo">Código ICAO (4 dígitos) do aeroporto desejado</param>
        /// <returns></returns>
        public async Task<CptecClimaResponse> CptecClimaAeroporto(string icaoCodigo)
        {
            string baseUrl = $"{BASE_URL}/cptec/v1/clima/aeroporto/{icaoCodigo}";
            var response = await Client.GetAsync(baseUrl);
            await EnsureSuccess(response, baseUrl);
            var json = await response.Content.ReadAsStringAsync();

            var corretorasResponse = new CptecClimaResponse()
            {
                Climas = new List<CptecClima>(){
                    JsonConvert.DeserializeObject<CptecClima>(json)
                },
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return corretorasResponse;
        }

        /// <summary>
        /// Previsão meteorológica para uma cidade
        /// Retorna Pervisão meteorológica para 1 dia na cidade informada.
        /// </summary>
        /// <param name="cidadeCodigo">Código da cidade fornecido <see cref="CptecCidade" /></param>
        /// <returns></returns>
        public async Task<CptecPrevisaoResponse> CptecClimaPrevisao(int cidadeCodigo)
        {
            string baseUrl = $"{BASE_URL}/cptec/v1/clima/previsao/{cidadeCodigo}";
            var httpResponse = await Client.GetAsync(baseUrl);
            await EnsureSuccess(httpResponse, baseUrl);
            var json = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<CptecPrevisaoResponse>(json);

            response.CalledURL = baseUrl;
            response.JsonResponse = json;

            return response;
        }

        /// <summary>
        /// Previsão meteorológica para, até, 6 dias
        /// Retorna a previsão meteorológica para a cidade informada para um período de 1 até 6 dias. Devido a inconsistências encontradas nos retornos da CPTEC nossa API só consegue retornar com precisão o período máximo de 6 dias.
        /// </summary>
        /// <param name="cidadeCodigo">Código da cidade fornecido <see cref="CptecCidade" /></param>
        /// <param name="dias">Quantidade de dias desejado para a previsão /></param>
        /// <returns></returns>
        public async Task<CptecPrevisaoResponse> CptecClimaPrevisao(int cidadeCodigo, int dias)
        {
            string baseUrl = $"{BASE_URL}/cptec/v1/clima/previsao/{cidadeCodigo}/{dias}";
            var httpResponse = await Client.GetAsync(baseUrl);
            await EnsureSuccess(httpResponse, baseUrl);
            var json = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<CptecPrevisaoResponse>(json);

            response.CalledURL = baseUrl;
            response.JsonResponse = json;

            return response;
        }

        /// <summary>
        /// Retorna a previsão oceânica para a cidade informada para 1 dia
        /// </summary>
        /// <param name="cidadeCodigo">Código da cidade fornecido <see cref="CptecCidade" /></param>
        /// <returns></returns>
        public async Task<CptecOndasResponse> CptecOndas(int cidadeCodigo)
        {
            string baseUrl = $"{BASE_URL}/cptec/v1/ondas/{cidadeCodigo}";
            var httpResponse = await Client.GetAsync(baseUrl);
            await EnsureSuccess(httpResponse, baseUrl);
            var json = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<CptecOndasResponse>(json);

            response.CalledURL = baseUrl;
            response.JsonResponse = json;

            return response;
        }

        /// <summary>
        /// Retorna a previsão meteorológica para a cidade informada para um período de 1 até 6 dias. 
        /// Devido a inconsistências encontradas nos retornos da CPTEC nossa API só consegue retornar com precisão o período máximo de 6 dias.
        /// </summary>
        /// <param name="cidadeCodigo">Código da cidade fornecido <see cref="CptecCidade" /></param>
        /// <param name="dias">Quantidade de dias desejado para a previsão</param>
        /// <returns></returns>
        public async Task<CptecOndasResponse> CptecOndas(int cidadeCodigo, int dias)
        {
            string baseUrl = $"{BASE_URL}/cptec/v1/ondas/{cidadeCodigo}/{dias}";
            var httpResponse = await Client.GetAsync(baseUrl);
            await EnsureSuccess(httpResponse, baseUrl);
            var json = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<CptecOndasResponse>(json);

            response.CalledURL = baseUrl;
            response.JsonResponse = json;

            return response;
        }
         
    }
}
