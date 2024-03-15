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
        /// Retorna informações de todos os NCMs
        /// </summary>
        /// <returns></returns>
        public async Task<NCMResponse> NCM()
        {
            string baseUrl = $"{BASE_URL}/ncm/v1";

            var httpResponse = await Client.GetAsync(baseUrl);

            await EnsureSuccess(httpResponse, baseUrl);

            var json = await httpResponse.Content.ReadAsStringAsync();

            var response = new NCMResponse()
            {
                NCMs = CustomJsonSerializer<IEnumerable<NCM>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return response;
        }

        /// <summary>
        /// Pesquisa por NCMs a partir de um código ou descrição.
        /// </summary>
        /// <returns></returns>
        public async Task<NCMResponse> NCM_Busca(string codigo)
        {
            string baseUrl = $"{BASE_URL}/ncm/v1/?search={codigo}";

            var httpResponse = await Client.GetAsync(baseUrl);

            await EnsureSuccess(httpResponse, baseUrl);

            var json = await httpResponse.Content.ReadAsStringAsync();

            var response = new NCMResponse()
            {
                NCMs = CustomJsonSerializer<IEnumerable<NCM>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return response;
        }

        /// <summary>
        /// Busca as informações de um NCM a partir de um código
        /// </summary>
        /// <returns></returns>
        public async Task<NCMResponse> NCM(string codigo)
        {
            string baseUrl = $"{BASE_URL}/ncm/v1/{codigo}";

            var httpResponse = await Client.GetAsync(baseUrl);

            await EnsureSuccess(httpResponse, baseUrl);

            var json = await httpResponse.Content.ReadAsStringAsync();

            var response = new NCMResponse()
            {
                NCMs = new List<NCM>(){
                     CustomJsonSerializer<NCM>(json)
                },
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return response;
        }

    }
}
