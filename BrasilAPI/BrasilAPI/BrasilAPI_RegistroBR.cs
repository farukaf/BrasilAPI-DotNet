using System.Text.Json;
using SDKBrasilAPI.Responses;
using System; 
using System.Threading.Tasks; 

namespace SDKBrasilAPI
{
    public partial class BrasilAPI : IDisposable
    { 
        /// <summary>
        /// Avalia o status de um dominio .br
        /// </summary>
        /// <param name="dominio">O domínio ou nome a ser avaliado</param>
        /// <returns></returns>
        public async Task<RegistroBrResponse> RegistroBR(string dominio)
        {
            string baseUrl = $"{BASE_URL}/registrobr/v1/{dominio.Trim()}";
            var response = await Client.GetAsync(baseUrl);
            await EnsureSuccess(response, baseUrl);
            var json = await response.Content.ReadAsStringAsync();

            var registroResponse = CustomJsonSerializer<RegistroBrResponse>(json);

            registroResponse.CalledURL = baseUrl;
            registroResponse.JsonResponse = json;

            return registroResponse;
        } 
    }
}
