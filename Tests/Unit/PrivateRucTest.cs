using Luilliarcec.Identification.Ecuador;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Unit
{
    [TestClass]
    public class PrivateRucTest
    {
        [TestMethod]
        public void ValidateThatEmptyValuesAreNotAllowed()
        {
            Assert.IsNull(Identification.ValidatePrivateRuc(""));
            Assert.AreEqual("Field must have a value.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatOnlyDigitsAreAllowed()
        {
            Assert.IsNull(Identification.ValidatePrivateRuc("ABC012"));
            Assert.AreEqual("Field must be digits.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheNumberHasTheExactLenght()
        {
            Assert.IsNull(Identification.ValidatePrivateRuc("12345678901"));
            Assert.AreEqual("Field must be 13 digits.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheProvinceCodeIsValid()
        {
            Assert.IsNull(Identification.ValidatePrivateRuc("0034567898001"));
            Assert.AreEqual("In your province code must be between 01 and 24.",
                            Identification.ErrorMessage);

            Assert.IsNull(Identification.ValidatePrivateRuc("2534567898001"));
            Assert.AreEqual("In your province code must be between 01 and 24.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheThirdDigitIsValid()
        {
            Assert.IsNull(Identification.ValidatePrivateRuc("0154567898001"));
            Assert.AreEqual("Field must have the third digit equal to 9.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheLastsDigitsIsValid()
        {
            Assert.IsNull(Identification.ValidatePrivateRuc("0194567898002"));
            Assert.AreEqual("Field does not have the last digits equal to 001.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheNumberIsValid()
        {
            Assert.AreEqual("04", Identification.ValidatePrivateRuc("1790011674001"));
            Assert.IsNull(Identification.ErrorMessage);

            Assert.IsNull(Identification.ValidatePrivateRuc("1798011674001"));
            Assert.AreEqual("The identification number is invalid.",
                            Identification.ErrorMessage);
        }
    }
}
