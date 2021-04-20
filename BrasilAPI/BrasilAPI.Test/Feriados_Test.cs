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
    public class Feriados_Test
    {

        [TestMethod]
        public async Task Test01()
        {
            //Arrange
            int ano = 2020;
            FeriadosResponse feriadoResponse = new FeriadosResponse();

            //Act
            using (var brasilAPI = new BrasilAPI())
            {
                feriadoResponse = await brasilAPI.Feriados(ano);
            }

            //Assert
            Assert.IsNotNull(feriadoResponse);
            Assert.IsTrue(feriadoResponse.Feriados.Any());
        }

    }
}
