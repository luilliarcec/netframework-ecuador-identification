using Luilliarcec.Identification.Ecuador;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Unit
{
    [TestClass]
    public class OtherValidationsTest
    {
        [TestMethod]
        public void ValidateThatAllTypesDocumenReturnCorrectValue()
        {
            Assert.AreEqual("07", Identification.ValidateAllTypeIdentification("9999999999999"));
            Assert.AreEqual("05", Identification.ValidateAllTypeIdentification("1710034065"));
            Assert.AreEqual("04", Identification.ValidateAllTypeIdentification("1710034065001"));
            Assert.AreEqual("04", Identification.ValidateAllTypeIdentification("1760001550001"));
            Assert.AreEqual("04", Identification.ValidateAllTypeIdentification("1790011674001"));
        }

        [TestMethod]
        public void ValidateIsJuridicalPerson()
        {
            Assert.IsNull(Identification.ValidateIsJuridicalPerson("9999999999999"));
            Assert.IsNull(Identification.ValidateIsJuridicalPerson("1710034065"));
            Assert.IsNull(Identification.ValidateIsJuridicalPerson("1710034065001"));

            Assert.AreEqual("04", Identification.ValidateIsJuridicalPerson("1760001550001"));
            Assert.AreEqual("04", Identification.ValidateIsJuridicalPerson("1790011674001"));
        }

        [TestMethod]
        public void ValidateIsNaturalPerson()
        {
            Assert.IsNull(Identification.ValidateIsNaturalPerson("9999999999999"));
            Assert.IsNull(Identification.ValidateIsNaturalPerson("1760001550001"));
            Assert.IsNull(Identification.ValidateIsNaturalPerson("1790011674001"));

            Assert.AreEqual("05", Identification.ValidateIsNaturalPerson("1710034065"));
            Assert.AreEqual("04", Identification.ValidateIsNaturalPerson("1710034065001"));
        }

        [TestMethod]
        public void ValidateRuc()
        {
            Assert.IsNull(Identification.ValidateRuc("9999999999999"));
            Assert.IsNull(Identification.ValidateRuc("1710034065"));

            Assert.AreEqual("04", Identification.ValidateRuc("1710034065001"));
            Assert.AreEqual("04", Identification.ValidateRuc("1760001550001"));
            Assert.AreEqual("04", Identification.ValidateRuc("1790011674001"));
        }
    }
}
