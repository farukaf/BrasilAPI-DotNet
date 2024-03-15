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
        /// Retorna informações de todos estados do Brasil
        /// </summary>
        /// <returns></returns>
        public async Task<IBGEResponse> IBGE_UF()
        {
            string baseUrl = $"{BASE_URL}/ibge/uf/v1";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var ibgeResponse = new IBGEResponse()
            {
                IBGEs = CustomJsonSerializer<IEnumerable<IBGE>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return ibgeResponse;
        }

        /// <summary>
        /// Busca as informações de um um estado a partir da sigla(UF) ou código
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<IBGEResponse> IBGE_UF(UF code)
        {
            return IBGE_UF(code.ToString());
        }

        /// <summary>
        /// Busca as informações de um um estado a partir da sigla(UF) ou código
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<IBGEResponse> IBGE_UF(int code)
        {
            return IBGE_UF(code.ToString());
        }

        /// <summary>
        /// Busca as informações de um um estado a partir da sigla(UF) ou código
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<IBGEResponse> IBGE_UF(string code)
        {
            string baseUrl = $"{BASE_URL}/ibge/uf/v1/{code}";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var ibgeResponse = new IBGEResponse()
            {
                IBGEs = new List<IBGE>(),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            (ibgeResponse.IBGEs as List<IBGE>).Add(CustomJsonSerializer<IBGE>(json));

            return ibgeResponse;
        }

        /// <summary>
        /// Lista os municicípios a partir da UF
        /// </summary>
        /// <param name="uf"></param>
        /// <returns></returns>
        public async Task<IBGEMunicipiosResponse> IBGE_Municipios(UF uf)
        {
            string baseUrl = $"{BASE_URL}/ibge/municipios/v1/{uf}";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var ibgeResponse = new IBGEMunicipiosResponse()
            {
                Municipios = CustomJsonSerializer<IEnumerable<Municipio>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return ibgeResponse;
        }
         
    }
}
