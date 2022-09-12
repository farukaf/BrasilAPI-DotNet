using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDKBrasilAPI;
using SDKBrasilAPI.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasilAPI_Test
{
    [TestClass]
    public class RegistroBR_Test
    {
        [TestMethod]
        public async Task Test01()
        {
            //Arrange 
            TaxasResponse taxasResponse = new TaxasResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                taxasResponse = await brasilAPI.Taxas();
            }

            //Assert
            Assert.IsNotNull(taxasResponse);
            Assert.IsTrue(taxasResponse.Taxas.Any());
        }

        [TestMethod]
        public async Task Test02()
        {
            //Arrange 
            TaxasResponse taxasResponse = new TaxasResponse();
            var testName = "cdi";

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                taxasResponse = await brasilAPI.Taxas(testName);
            }

            //Assert
            Assert.IsNotNull(taxasResponse);
            Assert.IsTrue(taxasResponse.Taxas.Any());
            Assert.IsTrue(taxasResponse.Taxas.First().Nome.ToLower().Contains(testName));
        }
    }
}
