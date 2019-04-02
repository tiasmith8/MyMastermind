using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMastermind.Classes;

namespace UnitTestProject2
{
    [TestClass]
    public class CheckInputTests
    {
        [TestMethod]
        public void InvalidInputReturnsFalse()
        {
            // Arrange
            Mastermind test = new Mastermind();

            // Act
            bool actual = test.CheckValidInput("999");

            // Assert
            Assert.AreEqual(false, actual, "999 should return false");
        }
    }

    [TestClass]
    public class CheckGuessTests
    {
        [TestMethod]
        public void InvalidGuessReturnsEmptyString()
        {
            // Arrange
            Mastermind test = new Mastermind();

            // Act
            string actual = test.CheckGuess("9999");

            // Assert
            Assert.AreEqual("", actual, "9999 should return and empty string");
        }
    }

}
