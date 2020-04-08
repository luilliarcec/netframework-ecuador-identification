using System;
using Luilliarcec.Identification.Ecuador;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class NaturalRucTest
    {
        [TestMethod]
        public void ValidateThatEmptyValuesAreNotAllowed()
        {
            Assert.IsNull(Identification.ValidateNaturalRuc(""));
            Assert.AreEqual("Field must have a value.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatOnlyDigitsAreAllowed()
        {
            Assert.IsNull(Identification.ValidateNaturalRuc("ABC012"));
            Assert.AreEqual("Field must be digits.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheNumberHasTheExactLenght()
        {
            Assert.IsNull(Identification.ValidateNaturalRuc("12345678901"));
            Assert.AreEqual("Field must be 13 digits.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheProvinceCodeIsValid()
        {
            Assert.IsNull(Identification.ValidateNaturalRuc("0034567898001"));
            Assert.AreEqual("In your province code must be between 01 and 24.",
                            Identification.ErrorMessage);

            Assert.IsNull(Identification.ValidateNaturalRuc("2534567898001"));
            Assert.AreEqual("In your province code must be between 01 and 24.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheThirdDigitIsValid()
        {
            Assert.IsNull(Identification.ValidateNaturalRuc("0164567898001"));
            Assert.AreEqual("Field must have the third digit between 0 and 5.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheLastsDigitsIsValid()
        {
            Assert.IsNull(Identification.ValidateNaturalRuc("0154567898002"));
            Assert.AreEqual("Field does not have the last digits equal to 001.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheNumberIsValid()
        {
            Assert.AreEqual("04", Identification.ValidateNaturalRuc("1710034065001"));
            Assert.IsNull(Identification.ErrorMessage);
        }
    }
}
