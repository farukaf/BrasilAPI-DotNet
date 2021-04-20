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
    public class IBGE_Test
    {

        [TestMethod]
        public async Task Test01()
        {
            //Arrange 
            IBGEResponse ibgeResponse = new IBGEResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                ibgeResponse = await brasilAPI.IBGE_UF();
            }

            //Assert
            Assert.IsNotNull(ibgeResponse);
            Assert.IsTrue(ibgeResponse.IBGEs.Any());
        }

        [TestMethod]
        public async Task Test02()
        {
            //Arrange 
            var uf = UF.SP;
            IBGEResponse ibgeResponse = new IBGEResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                ibgeResponse = await brasilAPI.IBGE_UF(uf);
            }

            //Assert
            Assert.IsNotNull(ibgeResponse);
            Assert.IsTrue(ibgeResponse.IBGEs.Any());
            Assert.IsTrue(ibgeResponse.IBGEs.Count() == 1);
            Assert.IsTrue(ibgeResponse.IBGEs.First().Nome.Contains("São", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(ibgeResponse.IBGEs.First().Nome.Contains("Paulo", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
