using System;
using Luilliarcec.Identification.Ecuador;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PublicRucTest
    {
        [TestMethod]
        public void ValidateThatEmptyValuesAreNotAllowed()
        {
            Assert.IsNull(Identification.ValidatePublicRuc(""));
            Assert.AreEqual("Field must have a value.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatOnlyDigitsAreAllowed()
        {
            Assert.IsNull(Identification.ValidatePublicRuc("ABC012"));
            Assert.AreEqual("Field must be digits.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheNumberHasTheExactLenght()
        {
            Assert.IsNull(Identification.ValidatePublicRuc("12345678901"));
            Assert.AreEqual("Field must be 13 digits.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheProvinceCodeIsValid()
        {
            Assert.IsNull(Identification.ValidatePublicRuc("0034567898001"));
            Assert.AreEqual("In your province code must be between 01 and 24.",
                            Identification.ErrorMessage);

            Assert.IsNull(Identification.ValidatePublicRuc("2534567898001"));
            Assert.AreEqual("In your province code must be between 01 and 24.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheThirdDigitIsValid()
        {
            Assert.IsNull(Identification.ValidatePublicRuc("0154567898001"));
            Assert.AreEqual("Field must have the third digit equal to 6.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheLastsDigitsIsValid()
        {
            Assert.IsNull(Identification.ValidatePublicRuc("0164567898002"));
            Assert.AreEqual("Field does not have the last digits equal to 0001.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheNumberIsValid()
        {
            Assert.AreEqual("04", Identification.ValidatePublicRuc("1760001550001"));
            Assert.IsNull(Identification.ErrorMessage);

            Assert.IsNull(Identification.ValidatePublicRuc("1760801550001"));
            Assert.AreEqual("The identification number is invalid.",
                            Identification.ErrorMessage);
        }
    }
}
