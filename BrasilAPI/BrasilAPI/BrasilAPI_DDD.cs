using Newtonsoft.Json;
using SDKBrasilAPI.Responses;
using System;
using System.Threading.Tasks;

namespace SDKBrasilAPI
{
    public partial class BrasilAPI : IDisposable
    {
        /// <summary>
        /// Retorna estado e lista de cidades por DDD
        /// </summary>
        /// <param name="ddd">
        /// DDD significa Discagem Direta à Distância. É um sistema de ligação telefônica automática entre diferentes 
        /// áreas urbanas nacionais. O DDD é um código constituído por 2 dígitos que identificam as principais cidades do país e devem ser 
        /// adicionados ao nº de telefone, juntamente com o código da operadora.
        /// </param>
        /// <returns></returns>
        public async Task<DDDResponse> DDD(int ddd)
        {
            string baseUrl = $"{BASE_URL}/ddd/v1/{ddd}";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var dddResponse = JsonConvert.DeserializeObject<DDDResponse>(json);

            dddResponse.CalledURL = baseUrl;
            dddResponse.JsonResponse = json;

            return dddResponse;
        }
    }
}
