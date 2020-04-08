using Luilliarcec.Identification.Ecuador.Exceptions;

namespace Luilliarcec.Identification.Ecuador.Support
{
    class FinalCustomer : BaseIdentification
    {
        public FinalCustomer() : base()
        {
            BillingCode = "07";
        }

        public override string Validate(string identification_number)
        {
            if (identification_number != "9999999999999")
            {
                throw new IdentificationException("The identification number is invalid.");
            }

            return BillingCode;
        }
    }
}
