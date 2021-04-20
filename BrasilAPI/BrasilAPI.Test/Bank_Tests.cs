using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKBrasilAPI;

namespace BrasilAPI_Test
{
    [TestClass]
    public class Bank_Tests
    {
        [TestMethod]
        public async Task Test01()
        {
            //Arrange 
            BankResponse bankResponse = new BankResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                bankResponse = await brasilAPI.Banks();
            }

            //Assert
            Assert.IsNotNull(bankResponse);
            Assert.IsTrue(bankResponse.Banks.Any());
        }

        [TestMethod]
        public async Task Test02()
        {
            //Arrange 
            int code = 1;
            BankResponse bankResponse = new BankResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                bankResponse = await brasilAPI.Banks(code);
            }

            //Assert
            Assert.IsNotNull(bankResponse);
            Assert.IsTrue(bankResponse.Banks.Any());
            Assert.IsTrue(bankResponse.Banks.Count() == 1);
            Assert.IsTrue(bankResponse.Banks.First().FullName.Contains("Brasil", StringComparison.OrdinalIgnoreCase));
        }
    }
}
