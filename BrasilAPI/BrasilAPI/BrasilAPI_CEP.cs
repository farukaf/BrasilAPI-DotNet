using Newtonsoft.Json;
using SDKBrasilAPI.Responses;
using System;
using System.Threading.Tasks;

namespace SDKBrasilAPI
{
    public partial class BrasilAPI : IDisposable
    {
        /// <summary>
        /// Busca por CEP com múltiplos providers de fallback.
        /// <para />
        /// Obsoleto: Utilize o CEP_V2 para receber as informações de localização e coordenadas 
        /// </summary>
        /// <param name="cep">
        /// O CEP (Código de Endereçamento Postal) é um sistema de códigos que visa 
        /// racionalizar o processo de encaminhamento e entrega de correspondências através da divisão do país em regiões postais. ... 
        /// Atualmente, o CEP é composto por oito dígitos, cinco de um lado e três de outro. Cada algarismo do CEP possui um significado.
        /// </param>
        /// <returns></returns>
        [Obsolete("Utilizar CEP_V2")]
        public async Task<CEPResponse> CEP(string cep)
        {
            //Na doc. ta colocando cep como int64, porem todos os sistemas (que eu tenha visto) trabalham com cep como string...
            //Como estou adicionando esse processo pra remover alguma mascara creio "resolver" o problema
            cep = OnlyNumbers(cep);
            string baseUrl = $"{BASE_URL}/cep/v1/{cep}";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var cepResponse = JsonConvert.DeserializeObject<CEPResponse>(json);

            cepResponse.CalledURL = baseUrl;
            cepResponse.JsonResponse = json;

            return cepResponse;
        }


        /// <summary>
        /// Busca por CEP com múltiplos providers de fallback.
        /// </summary>
        /// <param name="cep">
        /// O CEP (Código de Endereçamento Postal) é um sistema de códigos que visa 
        /// racionalizar o processo de encaminhamento e entrega de correspondências através da divisão do país em regiões postais. ... 
        /// Atualmente, o CEP é composto por oito dígitos, cinco de um lado e três de outro. Cada algarismo do CEP possui um significado.
        /// </param>
        /// <returns></returns>
        public async Task<CEPResponse> CEP_V2(string cep)
        {
            //Na doc. ta colocando cep como int64, porem todos os sistemas (que eu tenha visto) trabalham com cep como string...
            //Como estou adicionando esse processo pra remover alguma mascara creio "resolver" o problema
            cep = OnlyNumbers(cep);
            string baseUrl = $"{BASE_URL}/cep/v2/{cep}";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var cepResponse = JsonConvert.DeserializeObject<CEPResponse>(json);

            cepResponse.CalledURL = baseUrl;
            cepResponse.JsonResponse = json;

            return cepResponse;
        }
    }
}
