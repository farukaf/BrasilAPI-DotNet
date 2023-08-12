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
        /// Lista os feriados nacionais de determinado ano.
        /// Calcula os feriados móveis baseados na Páscoa e adiciona os feriados fixos
        /// </summary>
        /// <param name="ano">Ano para calcular os feriados.</param>
        /// <returns></returns>
        public async Task<FeriadosResponse> Feriados(int ano)
        {
            string baseUrl = $"{BASE_URL}/feriados/v1/{ano}";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var feriadoResponse = new FeriadosResponse()
            {
                Feriados = JsonConvert.DeserializeObject<IEnumerable<Feriado>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return feriadoResponse;
        }
    }
}
