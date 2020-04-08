namespace Luilliarcec.Identification.Ecuador.Support
{
    class PrivateRuc : BaseIdentification
    {
        public PrivateRuc() : base()
        {
            Lenght = 13;
            BillingCode = "04";
            Coefficients = new int[] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            CheckDigitPosition = 10;
            ThirdDigit = 9;
            LastsDigits = "001";
        }
    }
}
