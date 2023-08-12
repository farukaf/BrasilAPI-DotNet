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
        /// Retorna as taxas de juros e alguns índices oficiais do Brasil
        /// </summary>
        /// <returns></returns>
        public async Task<TaxasResponse> Taxas()
        {
            string baseUrl = $"{BASE_URL}/taxas/v1";
            var response = await Client.GetAsync(baseUrl);
            await EnsureSuccess(response, baseUrl);
            var json = await response.Content.ReadAsStringAsync();

            var taxasResponse = new TaxasResponse()
            {
                Taxas = JsonConvert.DeserializeObject<IEnumerable<Taxa>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return taxasResponse;
        }

        /// <summary>
        /// Retorna as taxas de juros e alguns índices oficiais do Brasil
        /// <para/>
        /// Busca as informações de uma taxa a partir do seu nome/sigla
        /// </summary>
        /// <param name="sigla"></param>
        /// <returns></returns>
        public async Task<TaxasResponse> Taxas(string sigla = "")
        {
            string baseUrl = $"{BASE_URL}/taxas/v1/{sigla.Trim()}";
            var response = await Client.GetAsync(baseUrl);
            await EnsureSuccess(response, baseUrl);
            var json = await response.Content.ReadAsStringAsync();

            var taxasResponse = new TaxasResponse()
            {
                Taxas = new List<Taxa>()
                {
                    JsonConvert.DeserializeObject<Taxa>(json)
                },
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return taxasResponse;
        }
         
    }
}
