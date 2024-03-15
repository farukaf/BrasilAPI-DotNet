using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;
using SDKBrasilAPI;
using SDKBrasilAPI.Responses;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrasilAPI_Test
{
    [TestClass]
    public class CEP_Test
    {
        [TestMethod]
        public async Task Test01()
        {
            //Arrange
            var cep = "89010025";
            using var brasilAPI = new BrasilAPI();
            var mockHttp = new MockHttpMessageHandler();

            //Os serviços estavam fora no momento do teste, achei uma boa oportunidade para mockar as requisições
            mockHttp.When($"{BrasilAPI.BASE_URL}*")
                .Respond(
                    HttpStatusCode.OK,
                    "application/json",
                    @"{
    ""cep"": ""89010025"",
    ""state"": ""SC"",
    ""city"": ""Blumenau"",
    ""neighborhood"": ""Centro"",
    ""street"": ""Rua Doutor Luiz de Freitas Melro"",
    ""service"": ""viacep""
}");
            brasilAPI.Client = new HttpClient(mockHttp);


            //Act
#pragma warning disable CS0618 // Type or member is obsolete
            var cnpjResponse = await brasilAPI.CEP(cep);
#pragma warning restore CS0618 // Type or member is obsolete

            //Assert
            Assert.IsNotNull(cnpjResponse);
            Assert.IsTrue(cnpjResponse.City.Contains("Blumenau", System.StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UF.SC, cnpjResponse.UF);
        }

        [TestMethod]
        public async Task V2_Test01()
        {
            //Arrange
            var cep = "89010025";
            using var brasilAPI = new BrasilAPI();
            var mockHttp = new MockHttpMessageHandler();

            //Os serviços estavam fora no momento do teste, achei uma boa oportunidade para mockar as requisições
            mockHttp.When($"{BrasilAPI.BASE_URL}*")
                    .Respond(
                        HttpStatusCode.OK,
                        "application/json",
                        @"{
    ""cep"": ""89010025"",
    ""state"": ""SC"",
    ""city"": ""Blumenau"",
    ""neighborhood"": ""Centro"",
    ""street"": ""Rua Principal"",
    ""location"": {
        ""type"": ""Point"",
        ""coordinates"": {
            ""longitude"": ""-46.633308"",
            ""latitude"": ""-23.550520""
        }
    }
}");
            brasilAPI.Client = new HttpClient(mockHttp);


            //Act 
            var cepResponse = await brasilAPI.CEP_V2(cep);


            //Assert
            Assert.IsNotNull(cepResponse);
            Assert.IsTrue(cepResponse.City.Contains("Blumenau", System.StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UF.SC, cepResponse.UF);
        }

        [TestMethod]
        public async Task TestNotFoundError()
        {
            //Arrange
            var cep = "89010025";
            using var brasilAPI = new BrasilAPI();
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When($"{BrasilAPI.BASE_URL}*")
                    .Respond(
                        HttpStatusCode.NotFound,
                        "application/json",
                        "{\"message\":\"Todos os serviços de CEP retornaram erro.\",\"type\":\"service_error\",\"name\":\"CepPromiseError\",\"errors\":[{\"name\":\"ServiceError\",\"message\":\"A autenticacao de null falhou!\",\"service\":\"correios\"},{\"name\":\"ServiceError\",\"message\":\"Erro ao se conectar com o serviço ViaCEP.\",\"service\":\"viacep\"},{\"name\":\"ServiceError\",\"message\":\"Erro ao se conectar com o serviço WideNet.\",\"service\":\"widenet\"},{\"name\":\"ServiceError\",\"message\":\"Erro ao se conectar com o serviço dos Correios Alt.\",\"service\":\"correios-alt\"}]}");

            brasilAPI.Client = new HttpClient(mockHttp);

            //Act
            //Assert
            await Assert.ThrowsExceptionAsync<BrasilAPIException>(async () => await brasilAPI.CEP_V2(cep));

        }
    }
}
