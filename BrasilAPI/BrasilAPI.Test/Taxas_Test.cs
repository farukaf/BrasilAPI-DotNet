using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDKBrasilAPI.Responses;
using SDKBrasilAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BrasilAPI_Test
{
    [TestClass]
    public class Taxas_Test
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
