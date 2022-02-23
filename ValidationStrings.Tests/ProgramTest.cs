using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ValidationStrings.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void GetStringConvertedWithSpacesShouldBeReturnCorrectConversion()
        {
            var program = new Program();
            var actual = program.GetStringConvertedWithSpaces("Hello Dear Mom");
            Assert.AreEqual("H2o D2r M1m", actual);
        }

        [TestMethod]
        public void GetStringConvertedNonAlphabeticShouldBeReturnCorrectConversion()
        {
            var program = new Program();
            var actual = program.GetStringConvertedNonAlphabetic("Copyright,Microsoft:Corporation");
            Assert.AreEqual("C7t,M6t:C6n", actual);
        }
    }
}
