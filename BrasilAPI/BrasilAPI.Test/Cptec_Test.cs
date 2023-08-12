using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using SDKBrasilAPI;
using System.Threading.Tasks;
using System.Linq;

namespace BrasilAPI_Test
{
    [TestClass]
    public class Cptec_Test
    {

        [TestMethod]
        public async Task Test01()
        {
            //Arrange 

            //Act
            using var brasilAPI = new BrasilAPI();
            var cidadesResponse = await brasilAPI.CptecCidade();

            //Assert
            Assert.IsNotNull(cidadesResponse);
            Assert.IsTrue(cidadesResponse.Cidades.Any());
        }

        [TestMethod]
        public async Task Test02()
        {
            //Arrange 

            //Act
            using var brasilAPI = new BrasilAPI();
            var cidadesResponse = await brasilAPI.CptecCidade("rio");

            //Assert
            Assert.IsNotNull(cidadesResponse);
            Assert.IsTrue(cidadesResponse.Cidades.Any());
        }

        [TestMethod]
        public async Task Test03()
        {
            //Arrange 
            var cidadeCodigoRj = 241;
            //Act
            using var brasilAPI = new BrasilAPI();
            var climaResponse = await brasilAPI.CptecClimaPrevisao(cidadeCodigoRj);

            //Assert
            Assert.IsNotNull(climaResponse);
            Assert.IsTrue(climaResponse.Cidade.Contains("rio", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public async Task Test04()
        {
            //Arrange 
            var cidadeCodigoRioPretoMg = 4413;
            //Act
            using var brasilAPI = new BrasilAPI();
            var climaResponse = await brasilAPI.CptecClimaPrevisao(cidadeCodigoRioPretoMg, 5);

            //Assert
            Assert.IsNotNull(climaResponse);
            Assert.IsTrue(climaResponse.Cidade.Contains("rio", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public async Task Test05()
        {
            //Arrange 

            //Act
            using var brasilAPI = new BrasilAPI();
            var climaResponse = await brasilAPI.CptecClimaCapital();

            //Assert
            Assert.IsNotNull(climaResponse);
            Assert.IsTrue(climaResponse.Climas.Any());
        }

        [TestMethod]
        public async Task Test06()
        {
            //Arrange
            var codigo = "SBBR";

            //Act
            using var brasilAPI = new BrasilAPI();
            var climaResponse = await brasilAPI.CptecClimaAeroporto(codigo);

            //Assert
            Assert.IsNotNull(climaResponse);
            Assert.IsTrue(climaResponse.Climas.Any());
            Assert.IsTrue(climaResponse.Climas.Count() == 1);
        }

        [TestMethod]
        public async Task Test07()
        {
            //Arrange 
            var cidadeCodigoRj = 241;

            //Act
            using var brasilAPI = new BrasilAPI();
            var climaResponse = await brasilAPI.CptecClimaPrevisao(cidadeCodigoRj);

            //Assert
            Assert.IsNotNull(climaResponse);
            Assert.IsTrue(climaResponse.Cidade.Contains("rio", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(climaResponse.Clima.Any());
        }

        [TestMethod]
        public async Task Test08()
        {
            //Arrange 
            var cidadeCodigoRj = 241;
            var dias = 2;

            //Act
            using var brasilAPI = new BrasilAPI();
            var climaResponse = await brasilAPI.CptecClimaPrevisao(cidadeCodigoRj, dias);

            //Assert
            Assert.IsNotNull(climaResponse);
            Assert.IsTrue(climaResponse.Cidade.Contains("rio", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(climaResponse.Clima.Any());
            Assert.AreEqual(dias, climaResponse.Clima.Count());
        }

        [TestMethod]
        public async Task Test09()
        {
            //Arrange 
            var cidadeCodigoRj = 241;

            //Act
            using var brasilAPI = new BrasilAPI();
            var climaResponse = await brasilAPI.CptecOndas(cidadeCodigoRj);

            //Assert
            Assert.IsNotNull(climaResponse);
            Assert.IsNotNull(climaResponse.Cidade.Contains("rio", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public async Task Test10()
        {
            //Arrange 
            var cidadeCodigoRj = 241;
            var dias = 2;

            //Act
            using var brasilAPI = new BrasilAPI();
            var climaResponse = await brasilAPI.CptecOndas(cidadeCodigoRj, dias);

            //Assert
            Assert.IsNotNull(climaResponse);
            Assert.IsNotNull(climaResponse.Cidade.Contains("rio", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(climaResponse.Ondas.Any());
            Assert.AreEqual(dias, climaResponse.Ondas.Count());
        }


    }
}
