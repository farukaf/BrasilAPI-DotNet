using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("BrasilAPI.Test")]

namespace BrasilAPI
{
    public class BrasilAPI : IDisposable
    {
        public BrasilAPI()
        {
            Client = CreateHttpClient();
        }



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

            var cnpjResponse = JsonConvert.DeserializeObject<CNPJResponse>(json);

            cnpjResponse.CalledURL = baseUrl;
            cnpjResponse.JsonResponse = json;

            return cnpjResponse;
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

        /// <summary>
        /// Retorna informações de todos estados do Brasil
        /// </summary>
        /// <returns></returns>
        public async Task<IBGEResponse> IBGE_UF()
        {
            string baseUrl = $"{BASE_URL}/ibge/uf/v1";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var ibgeResponse = new IBGEResponse()
            {
                IBGEs = JsonConvert.DeserializeObject<IEnumerable<IBGE>>(json),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            return ibgeResponse; 
        }

        /// <summary>
        /// Busca as informações de um um estado a partir da sigla(UF) ou código
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<IBGEResponse> IBGE_UF(UF code)
        {
            return IBGE_UF(code.ToString());
        }

        /// <summary>
        /// Busca as informações de um um estado a partir da sigla(UF) ou código
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<IBGEResponse> IBGE_UF(int code)
        {
            return IBGE_UF(code.ToString());
        }

        /// <summary>
        /// Busca as informações de um um estado a partir da sigla(UF) ou código
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<IBGEResponse> IBGE_UF(string code)
        {
            string baseUrl = $"{BASE_URL}/ibge/uf/v1/{code}";

            var response = await Client.GetAsync(baseUrl);

            await EnsureSuccess(response, baseUrl);

            var json = await response.Content.ReadAsStringAsync();

            var ibgeResponse = new IBGEResponse()
            {
                IBGEs = new List<IBGE>(),
                CalledURL = baseUrl,
                JsonResponse = json
            };

            (ibgeResponse.IBGEs as List<IBGE>).Add(JsonConvert.DeserializeObject<IBGE>(json));

            return ibgeResponse;
        }


        private const string BASE_URL = "https://brasilapi.com.br/api";
        private HttpClient Client;

        internal string OnlyNumbers(string str)
        {
            return Regex.Replace(str, @"[^\d]", "");
        }

        private HttpClient CreateHttpClient(Dictionary<string, object> headers = null)
        {
            HttpClient client = new HttpClient();

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    if (header.Value != null)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
                    }
                }
            }

            return client;
        }

        private async Task EnsureSuccess(HttpResponseMessage response, string url)
        {
            if ((int)response.StatusCode >= 400)
            {
                throw new BrasilAPIException()
                {
                    ContentData = await response.Content.ReadAsStringAsync(),
                    Code = (int)response.StatusCode,
                    URL = url
                };
            }
        }

        public void Dispose()
        {
            Client = null;
        }
    }
}
