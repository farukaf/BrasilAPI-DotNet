using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDKBrasilAPI; 
using System.Linq; 
using System.Threading.Tasks;

namespace BrasilAPI_Test
{
    [TestClass]
    public class PIX_Test
    {
        [TestMethod]
        public async Task Test01()
        {
            //Arrange 

            //Act
            using var brasilAPI = new BrasilAPI();
            var response = await brasilAPI.ParticipantesPIX();

            //Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Parcipantes.Any());
        }
    }
}
