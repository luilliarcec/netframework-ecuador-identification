using Luilliarcec.Identification.Ecuador;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Unit
{
    [TestClass]
    public class PersonalIdentificationTest
    {
        [TestMethod]
        public void ValidateThatEmptyValuesAreNotAllowed()
        {
            Assert.IsNull(Identification.ValidatePersonalIdentification(""));
            Assert.AreEqual("Field must have a value.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatOnlyDigitsAreAllowed()
        {
            Assert.IsNull(Identification.ValidatePersonalIdentification("ABC012"));
            Assert.AreEqual("Field must be digits.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheNumberHasTheExactLenght()
        {
            Assert.IsNull(Identification.ValidatePersonalIdentification("12345678901"));
            Assert.AreEqual("Field must be 10 digits.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheProvinceCodeIsValid()
        {
            Assert.IsNull(Identification.ValidatePersonalIdentification("0034567890"));
            Assert.AreEqual("In your province code must be between 01 and 24.",
                            Identification.ErrorMessage);

            Assert.IsNull(Identification.ValidatePersonalIdentification("2534567890"));
            Assert.AreEqual("In your province code must be between 01 and 24.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheThirdDigitIsValid()
        {
            Assert.IsNull(Identification.ValidatePersonalIdentification("0164567890"));
            Assert.AreEqual("Field must have the third digit between 0 and 5.",
                            Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheNumberIsValid()
        {
            Assert.AreEqual("05", Identification.ValidatePersonalIdentification("1710034065"));
            Assert.IsNull(Identification.ErrorMessage);

            Assert.IsNull(Identification.ValidatePersonalIdentification("1710834065"));
            Assert.AreEqual("The identification number is invalid.",
                            Identification.ErrorMessage);
        }
    }
}
