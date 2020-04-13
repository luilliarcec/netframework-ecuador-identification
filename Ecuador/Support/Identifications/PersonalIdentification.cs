using Luilliarcec.Identification.Ecuador.Exceptions;

namespace Luilliarcec.Identification.Ecuador.Support
{
    class PersonalIdentification : BaseIdentification
    {
        public PersonalIdentification() : base()
        {
            Lenght = 10;
            BillingCode = "05";
            Coefficients = new int[] { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            CheckDigitPosition = 10;
            ThirdDigit = 5;
        }

        protected override void ThirdDigitValidation(string identification_number)
        {
            int third_digit = GetThirdDigitValue(identification_number);

            if (third_digit > ThirdDigit)
            {
                throw new IdentificationException($"Field must have the third digit less than or equal to {ThirdDigit}.");
            }
        }
    }
}
