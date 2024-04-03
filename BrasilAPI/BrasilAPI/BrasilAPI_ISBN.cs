using System;
using System.Threading.Tasks;
using SDKBrasilAPI.Responses;

namespace SDKBrasilAPI
{
    public partial class BrasilAPI : IDisposable
    {
        /// <summary>
        /// Consulta informações de livros livros publicados no Brasil a partir do ISBN.
        /// </summary>
        /// <returns></returns>
        public async Task<ISBNResponse> ISBN(string isbn)
        {
            string baseUrl = $"{BASE_URL}/isbn/v1/{isbn}";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var isbnResponse = CustomJsonSerializer<ISBNResponse>(json);

            isbnResponse.CalledURL = baseUrl;
            isbnResponse.JsonResponse = json;

            return isbnResponse;
        }
    }
}