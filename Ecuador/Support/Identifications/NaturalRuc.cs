namespace Luilliarcec.Identification.Ecuador.Support
{
    class NaturalRuc : BaseIdentification
    {
        public NaturalRuc() : base()
        {
            Lenght = 13;
            BillingCode = "04";
            Coefficients = new int[] { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            CheckDigitPosition = 10;
            ThirdDigit = 5;
            LastsDigits = "001";
        }
    }
}
