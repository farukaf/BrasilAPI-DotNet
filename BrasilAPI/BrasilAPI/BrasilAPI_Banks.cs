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
        /// Retorna informações de todos os bancos do Brasil
        /// </summary>
        /// <returns></returns>
        public async Task<BankResponse> Banks()
        {
            string baseUrl = $"{BASE_URL}/banks/v1";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            BankResponse bankResponse = new BankResponse()
            {
                Banks = JsonConvert.DeserializeObject<IEnumerable<Bank>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return bankResponse;
        }

        /// <summary>
        /// Busca as informações de um banco a partir de um código
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<BankResponse> Banks(int code)
        {
            string baseUrl = $"{BASE_URL}/banks/v1/{code}";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            BankResponse bankResponse = new BankResponse()
            {
                Banks = new List<Bank>(),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            (bankResponse.Banks as List<Bank>).Add(JsonConvert.DeserializeObject<Bank>(json));

            return bankResponse;
        }

    }
}
