using Luilliarcec.Identification.Ecuador.Exceptions;
using Luilliarcec.Identification.Ecuador.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luilliarcec.Identification.Ecuador
{
    public static class Identification
    {
        /// <summary>
        /// Error message
        /// </summary>
        public static string ErrorMessage { get; set; }

        /// <summary>
        /// Validates the Ecuadorian Final Consumer
        /// </summary>
        /// <param name="identification_number">Final Consumer Identification</param>
        /// <returns>string|null</returns>
        public static string ValidateFinalCustomer(string identification_number)
        {
            ErrorMessage = null;

            try
            {          
                return new FinalCustomer().Validate(identification_number);
            }
            catch (IdentificationException ex)
            {
                ErrorMessage = ex.Message; return null;
            }
        }

        /// <summary>
        /// Validates the Ecuadorian Identification Card
        /// </summary>
        /// <param name="identification_number">Number of Identification Card</param>
        /// <returns>string|null</returns>
        public static string ValidatePersonalIdentification(string identification_number)
        {
            ErrorMessage = null;

            try
            {
                return new PersonalIdentification().Validate(identification_number);
            }
            catch (IdentificationException ex)
            {
                ErrorMessage = ex.Message; return null;
            }
        }

        /// <summary>
        /// Validates the Ecuadorian RUC of Natural Person
        /// </summary>
        /// <param name="identification_number">Number of RUC Natural</param>
        /// <returns>string|null</returns>
        public static string ValidateNaturalRuc(string identification_number)
        {
            ErrorMessage = null;

            try
            {
                return new NaturalRuc().Validate(identification_number);
            }
            catch (IdentificationException ex)
            {
                ErrorMessage = ex.Message; return null;
            }
        }
    }
}
