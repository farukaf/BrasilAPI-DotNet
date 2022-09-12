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
            RegistroBrResponse registroResponse = new RegistroBrResponse();
            var test = "brasilapi.com.br";

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                registroResponse = await brasilAPI.RegistroBR(test);
            }

            //Assert
            Assert.IsNotNull(registroResponse);
            Assert.AreEqual(test, registroResponse.Fqdn);
        }

    }
}
