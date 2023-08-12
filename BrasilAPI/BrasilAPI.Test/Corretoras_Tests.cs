using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using SDKBrasilAPI;
using System.Linq;
using System;

namespace BrasilAPI_Test
{
    [TestClass]
    public class Corretoras_Tests
    {
        [TestMethod]
        public async Task Test01()
        {
            //Arrange 

            //Act
            using var brasilAPI = new BrasilAPI();
            var corretorasResponse = await brasilAPI.Corretoras();

            //Assert
            Assert.IsNotNull(corretorasResponse);
            Assert.IsTrue(corretorasResponse.Corretoras.Any());

        }

        [TestMethod]
        [ExpectedException(typeof(BrasilAPIException))]
        public async Task Test02()
        {
            //Arrange
            var cnpj = "00.000.000/0001-91";

            //Act
            using var brasilAPI = new BrasilAPI();
            var corretorasResponse = await brasilAPI.Corretoras(cnpj);

        }

        [TestMethod] 
        public async Task Test03()
        {
            //Arrange
            var cnpj = "17.304.692/0001-64";

            //Act
            using var brasilAPI = new BrasilAPI();
            var corretorasResponse = await brasilAPI.Corretoras(cnpj);

            //Assert
            Assert.IsNotNull(corretorasResponse);
            Assert.IsTrue(corretorasResponse.Corretoras.Any());
            Assert.IsTrue(corretorasResponse.Corretoras.Count() == 1);
        }
         

    }
}
