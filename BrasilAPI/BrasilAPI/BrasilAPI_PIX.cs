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
        /// Retorna informações de todos os participantes do PIX no dia atual ou anterior
        /// </summary>
        /// <returns></returns>
        public async Task<ParticipantePIXResponse> ParticipantesPIX()
        {
            string baseUrl = $"{BASE_URL}/pix/v1/participants";

            var httpResponse = await Client.GetAsync(baseUrl);

            await EnsureSuccess(httpResponse, baseUrl);

            var json = await httpResponse.Content.ReadAsStringAsync();

            var response = new ParticipantePIXResponse()
            {
                Parcipantes = CustomJsonSerializer<IEnumerable<ParticipantePIX>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return response;
        }
         
    }
}
