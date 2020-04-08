namespace Luilliarcec.Identification.Ecuador.Support
{
    class PublicRuc : BaseIdentification
    {
        public PublicRuc() : base()
        {
            Lenght = 13;
            BillingCode = "04";
            Coefficients = new int[] { 3, 2, 7, 6, 5, 4, 3, 2 };
            CheckDigitPosition = 9;
            ThirdDigit = 6;
            LastsDigits = "0001";
        }
    }
}
