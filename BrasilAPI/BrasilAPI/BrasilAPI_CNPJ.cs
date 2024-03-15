using System.Text.Json;
using SDKBrasilAPI.Responses;
using System; 
using System.Threading.Tasks;

namespace SDKBrasilAPI
{
    public partial class BrasilAPI : IDisposable
    {  
        /// <summary>
        /// Busca por CNPJ na API Minha Receita.
        /// </summary>
        /// <param name="cnpj">
        /// O Cadastro Nacional da Pessoa Jurídica é um número único que identifica uma pessoa 
        /// jurídica e outros tipos de arranjo jurídico sem personalidade jurídica junto à Receita Federal.
        /// </param>
        /// <returns></returns>
        public async Task<CNPJResponse> CNPJ(string cnpj)
        {
            //Adicionado para remover mascaras caso venha... 
            cnpj = OnlyNumbers(cnpj);
            string baseUrl = $"{BASE_URL}/cnpj/v1/{cnpj}";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var cnpjResponse = CustomJsonSerializer<CNPJResponse>(json);

            cnpjResponse.CalledURL = baseUrl;
            cnpjResponse.JsonResponse = json;

            return cnpjResponse;
        } 
    }
}
