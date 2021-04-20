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
    public class DDD_Test
    {

        [TestMethod]
        public async Task Test01()
        {
            //Arrange
            int ddd = 17;
            DDDResponse dddResponse = new DDDResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                dddResponse = await brasilAPI.DDD(ddd);
            }

            //Assert
            Assert.IsNotNull(dddResponse);
            Assert.AreEqual(UF.SP, dddResponse.UF);
            Assert.IsTrue(dddResponse.Cities.Any());
        }
    }
}
