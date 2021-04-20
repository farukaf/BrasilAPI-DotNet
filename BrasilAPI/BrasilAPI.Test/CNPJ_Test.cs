using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDKBrasilAPI;
using System;
using System.Threading.Tasks;

namespace BrasilAPI_Test
{
    [TestClass]
    public class CNPJ_Test
    {
        [TestMethod]
        public async Task Test01()
        {
            //Arrange
            var cnpj = "00.000.000/0001-91";
            CNPJResponse cnpjResponse = new CNPJResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                cnpjResponse = await brasilAPI.CNPJ(cnpj);
            }

            //Assert
            Assert.IsNotNull(cnpjResponse);
            Assert.IsTrue(cnpjResponse.RazaoSocial.Contains("Brasil", System.StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public async Task Test02()
        {
            //Arrange
            var cnpj = "19131243000197";
            CNPJResponse cnpjResponse = new CNPJResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                cnpjResponse = await brasilAPI.CNPJ(cnpj);
            }

            //Assert
            Assert.IsNotNull(cnpjResponse);
            Assert.IsTrue(cnpjResponse.RazaoSocial.Contains("OPEN", System.StringComparison.InvariantCultureIgnoreCase));
        }
         
        [TestMethod]
        public async Task Test03()
        {
            //Arrange
            //CNPJ inválido
            var cnpj = "00.000.000/0001-00";
            CNPJResponse cnpjResponse = new CNPJResponse();

            //Act
            try
            {
                using (var brasilAPI = new BrasilAPI())
                {
                    cnpjResponse = await brasilAPI.CNPJ(cnpj);
                }
            }
            catch (BrasilAPIException ex)
            {
                //Assert 
                Assert.IsTrue(ex.Code >= 400);
                Console.WriteLine(ex.Message);
                Assert.IsFalse(string.IsNullOrEmpty(ex.Message));
            } 
        }
    }
}
