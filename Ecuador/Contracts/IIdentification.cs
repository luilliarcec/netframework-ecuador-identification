namespace Luilliarcec.Identification.Ecuador.Contracts
{
    interface IIdentification
    {
        /// <summary>
        /// Validate the identification
        /// </summary>
        /// <param name="identification_number">Number of the identification</param>
        /// <returns>Billing code</returns>
        string Validate(string identification_number);
    }
}
