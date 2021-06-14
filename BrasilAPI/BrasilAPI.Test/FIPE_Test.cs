using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDKBrasilAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasilAPI_Test
{
    [TestClass]
    public class FIPE_Test
    {

        [TestMethod]
        public async Task Marcas_01()
        {
            //Arrange 
            FIPEMarcasResponse marcasResponse = new FIPEMarcasResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                marcasResponse = await brasilAPI.FIPE_Marcas();
            }

            //Assert
            Assert.IsNotNull(marcasResponse);
            Assert.IsTrue(marcasResponse.Marcas.Any());
        }

        [TestMethod]
        public async Task Precos_01()
        {
            //Arrange 
            FIPEPrecosResponse precosResponse = new FIPEPrecosResponse();
            var codigo = "001004-9";

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                precosResponse = await brasilAPI.FIPE_Precos(codigo);
            }

            //Assert
            Assert.IsNotNull(precosResponse);
            Assert.IsTrue(precosResponse.Precos.Any());
        }

        [TestMethod]
        public async Task Tabelas_01()
        {
            //Arrange 
            FIPETabelasResponse tabelasResponse = new FIPETabelasResponse(); 

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                tabelasResponse = await brasilAPI.FIPE_Tabelas();
            }

            //Assert
            Assert.IsNotNull(tabelasResponse);
            Assert.IsTrue(tabelasResponse.Tabelas.Any());
        }

    }
}
