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
    }
}
