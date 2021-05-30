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
    public class CEP_Test
    {
        [TestMethod]
        public async Task Test01()
        {
            //Arrange
            var cep = "89010025";
            CEPResponse cnpjResponse = new CEPResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
#pragma warning disable CS0618 // Type or member is obsolete
                cnpjResponse = await brasilAPI.CEP(cep);
#pragma warning restore CS0618 // Type or member is obsolete
            }

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
            CEPResponse cnpjResponse = new CEPResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                cnpjResponse = await brasilAPI.CEP_V2(cep);
            }

            //Assert
            Assert.IsNotNull(cnpjResponse);
            Assert.IsTrue(cnpjResponse.City.Contains("Blumenau", System.StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UF.SC, cnpjResponse.UF);
        }
    }
}
