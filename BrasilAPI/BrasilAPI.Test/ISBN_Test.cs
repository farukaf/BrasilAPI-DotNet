using System.Linq;
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
    public class ISBN_Test
    {
        [TestMethod]
        public async Task Test01()
        {
            //Arrange
            var isbn = "9788545702870";
            using var brasilAPI = new BrasilAPI();
            var mockHttp = new MockHttpMessageHandler();

            //Os serviços estavam fora no momento do teste, achei uma boa oportunidade para mockar as requisições
            mockHttp.When($"{BrasilAPI.BASE_URL}*")
                .Respond(
                    HttpStatusCode.OK,
                    "application/json",
                    @"{
  ""isbn"": ""9788545702870"",
  ""title"": ""Akira"",
  ""subtitle"": null,
  ""authors"": [
    ""KATSUHIRO OTOMO"",
    ""DRIK SADA"",
    ""CASSIUS MEDAUAR"",
    ""MARCELO DEL GRECO"",
    ""DENIS TAKATA""
  ],
  ""publisher"": ""Japorama Editora e Comunicação"",
  ""synopsis"": ""Um dos marcos da ficção científica oriental que revolucionou a chegada dos mangás e da cultura pop japonesa no Ocidente retorna em uma nova edição especial. Após atropelar uma criança de aparência estranha, Tetsuo Shima (o melhor amigo de Kaneda), começa a sentir algumas reações anormais. Isso acaba chamando a atenção do governo que está projetando diversas experiências secretas e acabam sequestrando Tetsuo. Nesta aventura cheia de ficção, Kaneda entra em cena para salvar o amigo, enquanto uma terrível e monstruosa entidade ameaça despertar."",
  ""dimensions"": {
    ""width"": 17.5,
    ""height"": 25.7,
    ""unit"": ""CENTIMETER""
  },
  ""year"": 2017,
  ""format"": ""PHYSICAL"",
  ""page_count"": 364,
  ""subjects"": [
    ""Cartoons; caricaturas e quadrinhos"",
    ""mangá"",
    ""motocicleta"",
    ""gangue"",
    ""Delinquência""
  ],
  ""location"": ""SÃO PAULO, SP"",
  ""retail_price"": null,
  ""cover_url"": null,
  ""provider"": ""mercado-editorial""
}");
            brasilAPI.Client = new HttpClient(mockHttp);


            //Act 
            var isbnResponse = await brasilAPI.ISBN(isbn);

            //Assert
            Assert.IsNotNull(isbnResponse);
            Assert.IsTrue(isbnResponse.Title.Contains("Akira"));
            Assert.IsTrue(isbnResponse.Authors.Any(x => x.Contains("CASSIUS MEDAUAR")));
            Assert.IsTrue(isbnResponse.Subjects.Any(x => x.Contains("mangá")));
            Assert.AreEqual(IsbnProviders.MERCADO_EDITORIAL, isbnResponse.Provider);
            Assert.AreEqual(isbnResponse.IsbnDimensions.Unit, IsbnDimensionUnit.CENTIMETER);
            Assert.AreEqual(isbnResponse.IsbnDimensions.Height, 25.7);
            Assert.AreEqual(isbnResponse.IsbnDimensions.Width, 17.5);
        }

        [TestMethod]
        public async Task TestNotFoundError()
        {
            //Arrange
            var isbn = "9788545702870";
            using var brasilAPI = new BrasilAPI();
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When($"{BrasilAPI.BASE_URL}*")
                .Respond(
                    HttpStatusCode.NotFound,
                    "application/json",
                    "{\n  \"name\": \"InternalError\",\n  \"message\": \"Todos os serviços de ISBN retornaram erro.\",\n  \"type\": \"internal\"\n}");

            brasilAPI.Client = new HttpClient(mockHttp);

            //Act
            //Assert
            await Assert.ThrowsExceptionAsync<BrasilAPIException>(async () => await brasilAPI.ISBN(isbn));
        }
    }
}