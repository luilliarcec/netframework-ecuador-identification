using Luilliarcec.Identification.Ecuador.Contracts;
using Luilliarcec.Identification.Ecuador.Exceptions;
using System;
using System.Linq;

namespace Luilliarcec.Identification.Ecuador.Support
{
    class BaseIdentification : IIdentification
    {
        /// <summary>
        /// Number of provinces of Ecuador
        /// </summary>
        protected int Provinces { get; set; } = 24;

        /// <summary>
        /// Length of the different types of identification
        /// </summary>
        protected int Lenght { get; set; } = 0;

        /// <summary>
        /// Billing code for identification types
        /// </summary>
        protected string BillingCode { get; set; } = null;

        /// <summary>
        /// Third digit of the identification number
        /// </summary>
        protected int ThirdDigit { get; set; }

        /// <summary>
        /// Lasts digits of the identification number
        /// </summary>
        protected string LastsDigits { get; set; }

        /// <summary>
        /// Represents the position of the verifying digit in the identification number
        /// </summary>
        protected int CheckDigitPosition { get; set; }

        /// <summary>
        /// Represents the check coefficients for the identification number
        /// </summary>
        protected int[] Coefficients { get; set; }

        /// <summary>
        /// Validate length identification, province code, third digit
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC</param>
        /// <returns>Billing code or Error message</returns>
        public virtual string Validate(string identification_number)
        {
            LengthValidation(identification_number);
            ProvinceCodeValidation(identification_number);
            ThirdDigitValidation(identification_number);
            if (GetType() == typeof(PrivateRuc) || GetType() == typeof(PrivateRuc))
            {
                LastsDigitsValidation(identification_number);
                ModuleElevenValidation(identification_number);
            }
            else
            {
                if (GetType() == typeof(NaturalRuc))
                {
                    LastsDigitsValidation(identification_number);
                }
                ModuleTenValidation(identification_number);
            }

            return BillingCode;
        }

        #region <<< Private Functions >>>
        /// <summary>
        /// Initial validation of the identification, not empty, only digits, not less than the given length.
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC</param>
        private void LengthValidation(string identification_number)
        {
            if (string.IsNullOrEmpty(identification_number))
            {
                throw new IdentificationException("Field must have a value.");
            }

            if (!ulong.TryParse(identification_number, out _))
            {
                throw new IdentificationException("Field must be digits.");
            }

            if (identification_number.Length != Lenght)
            {
                throw new IdentificationException($"Field must be {Lenght} digits.");
            }
        }

        /// <summary>
        /// Validate the province code (first two numbers of CI/RUC) 
        /// The first 2 positions correspond to the province where it was issued,
        /// so the first two numbers will not be greater than 24 or less than 1
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC</param>
        private void ProvinceCodeValidation(string identification_number)
        {
            int code = GetProvinceCodeValue(identification_number);

            if (code < 1 || code > Provinces)
            {
                throw new IdentificationException($"In your province code must be between 01 and {Provinces}.");
            }
        }

        /// <summary>
        /// Valid the third digit
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC</param>
        private void ThirdDigitValidation(string identification_number)
        {
            int third_digit = GetThirdDigitValue(identification_number);

            if (GetType() == typeof(NaturalRuc) || GetType() == typeof(PersonalIdentification))
            {
                if (third_digit < 0 || third_digit > ThirdDigit)
                {
                    throw new IdentificationException($"Field must have the third digit between {0} and {ThirdDigit}.");
                }
            }
            else if (third_digit != ThirdDigit)
            {
                throw new IdentificationException($"Field must have the third digit equal to {ThirdDigit}.");
            }
        }

        /// <summary>
        /// Valid the lasts digits
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC</param>
        private void LastsDigitsValidation(string identification_number)
        {
            string lasts_digits = GetLastsDigitsValue(identification_number);

            if (lasts_digits != LastsDigits)
            {
                throw new IdentificationException($"Field does not have the last digits equal to {LastsDigits}.");
            }
        }

        /// <summary>
        /// Module 10 Algorithm to validate if Certificates and RUC of natural person are valid.
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC of natural person</param>
        private void ModuleTenValidation(string identification_number)
        {
            int check_digit_value = GetCheckDigitValue(identification_number);
            char[] numbers = GetNumbersAsArray(identification_number);

            int key = 0; decimal total = 0;
            foreach (char number in numbers)
            {
                var proceeds = int.Parse(number.ToString()) * Coefficients[key];

                if (proceeds >= 10)
                {
                    proceeds = Array.ConvertAll(proceeds.ToString().ToArray(), c => (int)char.GetNumericValue(c)).Sum();
                }

                total += proceeds;
                key++;
            }

            decimal residue = total % 10;
            int verified_digit_value = (int)(residue == 0 ? 0 : (10 - residue));

            if (verified_digit_value != check_digit_value)
            {
                throw new IdentificationException("The identification number is invalid.");
            }
        }

        /// <summary>
        /// Module 11 Algorithm to validate if RUC of Public Companies and Private Companies are valid.
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC</param>
        private void ModuleElevenValidation(string identification_number)
        {
            int check_digit_value = GetCheckDigitValue(identification_number);
            char[] numbers = GetNumbersAsArray(identification_number);

            int key = 0; decimal total = 0;
            foreach (char number in numbers)
            {
                var proceeds = int.Parse(number.ToString()) * Coefficients[key];
                total += proceeds;
                key++;
            }

            decimal residue = total % 11;
            int verified_digit_value = (int)(residue == 0 ? 0 : (11 - residue));

            if (verified_digit_value != check_digit_value)
            {
                throw new IdentificationException("The identification number is invalid.");
            }
        }

        #region <<< Sub Functions Private >>>
        /// <summary>
        /// Gets the lasts digits value
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC</param>
        /// <returns>Value of the lasts digits</returns>
        private string GetLastsDigitsValue(string identification_number)
        {
            return identification_number.Substring(Lenght - LastsDigits.Length, LastsDigits.Length);
        }

        /// <summary>
        /// Gets the province code value
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC</param>
        /// <returns>Value of the province code number</returns>
        private int GetProvinceCodeValue(string identification_number)
        {
            return int.Parse(identification_number.Substring(0, 2));
        }

        /// <summary>
        /// Gets the third digit number
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC</param>
        /// <returns>Value of the third digit number</returns>
        private int GetThirdDigitValue(string identification_number)
        {
            return int.Parse(identification_number.Substring(2, 1));
        }

        /// <summary>
        /// Gets the value of the verification number
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC</param>
        /// <returns>Value of the verification number</returns>
        private int GetCheckDigitValue(string identification_number)
        {
            return int.Parse(identification_number.Substring(CheckDigitPosition - 1, 1));
        }

        /// <summary>
        /// Get identification numbers for verification as Array
        /// </summary>
        /// <param name="identification_number">Personal identification or RUC</param>
        /// <returns>Identification numbers for verification</returns>
        private char[] GetNumbersAsArray(string identification_number)
        {
            var index = LastsDigits != null ? LastsDigits.Length : 0;

            return identification_number.Substring(0, Lenght - (index + 1)).ToArray();
        }
        #endregion
        #endregion
    }
}
