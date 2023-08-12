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
        /// Retorna as corretoras nos arquivos da CVM.
        /// </summary>
        /// <returns></returns>
        public async Task<CorretorasResponse> Corretoras()
        {
            string baseUrl = $"{BASE_URL}/cvm/corretoras/v1";
            var response = await Client.GetAsync(baseUrl);
            await EnsureSuccess(response, baseUrl);
            var json = await response.Content.ReadAsStringAsync();

            var corretorasResponse = new CorretorasResponse()
            {
                Corretoras = JsonConvert.DeserializeObject<List<Corretora>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return corretorasResponse;
        }

        /// <summary>
        /// Busca por corretoras nos arquivos da CVM.
        /// </summary>
        /// <param name="cnpj">
        /// O Cadastro Nacional da Pessoa Jurídica é um número único que identifica uma pessoa jurídica e outros tipos de arranjo jurídico sem personalidade jurídica junto à Receita Federal.
        /// </param>
        /// <returns></returns>
        public async Task<CorretorasResponse> Corretoras(string cnpj)
        {
            //Adicionado para remover mascaras caso venha... 
            cnpj = OnlyNumbers(cnpj);
            string baseUrl = $"{BASE_URL}/cvm/corretoras/v1/{cnpj}";
            var response = await Client.GetAsync(baseUrl);
            await EnsureSuccess(response, baseUrl);
            var json = await response.Content.ReadAsStringAsync();

            var corretorasResponse = new CorretorasResponse()
            {
                Corretoras = new List<Corretora>() {
                    JsonConvert.DeserializeObject<Corretora>(json)
                },
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return corretorasResponse;
        }
         
    }
}
