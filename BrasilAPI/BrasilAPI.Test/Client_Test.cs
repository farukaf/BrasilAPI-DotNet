using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDKBrasilAPI;
using System;

namespace BrasilAPI_Test
{
    [TestClass] 
    public class Client_Test
    {
        [TestMethod]
        [DataRow(null, "")]
        [DataRow("", "")]
        [DataRow("123-456", "123456")]
        [DataRow("123-456*", "123456")]
        [DataRow("1.23-456*", "123456")]
        public void OnlyNumbers_01(string test, string expected)
        {
            //Arrange
            using var brasilAPI = new BrasilAPI(); 

            //Act
            var result = brasilAPI.OnlyNumbers(test);
            Console.WriteLine(result);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UserAgent_01()
        {
            //Arrange
            using var brasilAPI = new BrasilAPI();
            var startWith = "BrasilAPI.DotNet";

            //Act
            var userAgent = brasilAPI.UserAgent();
            Console.WriteLine(userAgent);

            //Assert
            Assert.IsTrue(userAgent.StartsWith(startWith));
        }
    }
}
