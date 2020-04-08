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

        /// <summary>
        /// Validates the Ecuadorian RUC of Public Companies
        /// </summary>
        /// <param name="identification_number">Number of RUC Public Companies</param>
        /// <returns>string|null</returns>
        public static string ValidatePublicRuc(string identification_number)
        {
            ErrorMessage = null;

            try
            {
                return new PublicRuc().Validate(identification_number);
            }
            catch (IdentificationException ex)
            {
                ErrorMessage = ex.Message; return null;
            }
        }

        /// <summary>
        /// Validates the Ecuadorian RUC of Private Companies
        /// </summary>
        /// <param name="identification_number">Number of RUC Private Companies</param>
        /// <returns>string|null</returns>
        public static string ValidatePrivateRuc(string identification_number)
        {
            ErrorMessage = null;

            try
            {
                return new PrivateRuc().Validate(identification_number);
            }
            catch (IdentificationException ex)
            {
                ErrorMessage = ex.Message; return null;
            }
        }

        /// <summary>
        /// Validates the Ecuadorian RUC
        /// </summary>
        /// <param name="identification_number">Number of RUC</param>
        /// <returns>string|null</returns>
        public static string ValidateRuc(string identification_number)
        {
            string result;

            if ((result = ValidatePrivateRuc(identification_number)) != null) {
                return result;
            }

            if ((result = ValidatePublicRuc(identification_number)) != null)
            {
                return result;
            }

            return ValidateNaturalRuc(identification_number);
        }

        /// <summary>
        /// Validate that the number belongs to natural persons
        /// </summary>
        /// <param name="identification_number">Number of identification</param>
        /// <returns>string|null</returns>
        public static string ValidateIsNaturalPerson(string identification_number)
        {
            return ValidatePersonalIdentification(identification_number) ?? ValidateNaturalRuc(identification_number);
        }

        /// <summary>
        /// Validate that the number belongs to juridical persons
        /// </summary>
        /// <param name="identification_number">Number of identification</param>
        /// <returns>string|null</returns>
        public static string ValidateIsJuridicalPerson(string identification_number)
        {
            return ValidatePrivateRuc(identification_number) ?? ValidatePublicRuc(identification_number);
        }

        /// <summary>
        /// Validate the number with all types of documents
        /// </summary>
        /// <param name="identification_number">Number of identification</param>
        /// <returns>string|null</returns>
        public static string ValidateAllTypeIdentification(string identification_number)
        {
            string result;

            if ((result = ValidateFinalCustomer(identification_number)) != null)
            {
                return result;
            }

            if ((result = ValidatePersonalIdentification(identification_number)) != null)
            {
                return result;
            }

            return ValidateRuc(identification_number);
        }
    }
}
