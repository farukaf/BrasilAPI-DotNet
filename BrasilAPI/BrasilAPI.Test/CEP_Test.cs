using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasilAPI.Test
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
                cnpjResponse = await brasilAPI.CEP(cep);
            }

            //Assert
            Assert.IsNotNull(cnpjResponse);
            Assert.IsTrue(cnpjResponse.City.Contains("Blumenau", System.StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UF.SC, cnpjResponse.UF);
        }
    }
}
