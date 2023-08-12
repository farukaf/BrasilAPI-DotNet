using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDKBrasilAPI; 
using System.Linq; 
using System.Threading.Tasks;

namespace BrasilAPI_Test
{
    [TestClass]
    public class NCM_Test
    {
        [TestMethod]
        public async Task Test01()
        {
            //Arrange 

            //Act
            using var brasilAPI = new BrasilAPI();
            var corretorasResponse = await brasilAPI.NCM();

            //Assert
            Assert.IsNotNull(corretorasResponse);
            Assert.IsTrue(corretorasResponse.NCMs.Any());
        }

        [TestMethod]
        public async Task Test02()
        {
            //Arrange 

            //Act
            using var brasilAPI = new BrasilAPI();
            var corretorasResponse = await brasilAPI.NCM_Busca("33");

            //Assert
            Assert.IsNotNull(corretorasResponse);
            Assert.IsTrue(corretorasResponse.NCMs.Any());
        }

        [TestMethod]
        public async Task Test03()
        {
            //Arrange 

            //Act
            using var brasilAPI = new BrasilAPI();
            var corretorasResponse = await brasilAPI.NCM("3305.10.00");

            //Assert
            Assert.IsNotNull(corretorasResponse);
            Assert.IsTrue(corretorasResponse.NCMs.Any());
            Assert.IsTrue(corretorasResponse.NCMs.Count() == 1);
        }
    }
}
