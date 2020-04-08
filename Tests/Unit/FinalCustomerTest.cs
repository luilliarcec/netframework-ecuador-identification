using Luilliarcec.Identification.Ecuador;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Unit
{
    [TestClass]
    public class FinalCustomerTest
    {
        [TestMethod]
        public void ValidateThatEmptyValuesAreNotAllowed()
        {
            Assert.IsNull(Identification.ValidateFinalCustomer(""));
            Assert.AreEqual("The identification number is invalid.", Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheNumberIsValid()
        {
            Assert.AreEqual("07", Identification.ValidateFinalCustomer("9999999999999"));
            Assert.IsNull(Identification.ErrorMessage);
        }
    }
}
