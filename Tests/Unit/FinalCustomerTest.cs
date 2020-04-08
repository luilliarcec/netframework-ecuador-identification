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
            var result = Identification.ValidateFinalCustomer("");
            Assert.IsNull(result);
            Assert.AreEqual("The identification number is invalid.", Identification.ErrorMessage);
        }

        [TestMethod]
        public void ValidateThatTheNumberIsValid()
        {
            var result = Identification.ValidateFinalCustomer("9999999999999");
            Assert.AreEqual("07", result);
            Assert.IsNull(Identification.ErrorMessage);
        }
    }
}
