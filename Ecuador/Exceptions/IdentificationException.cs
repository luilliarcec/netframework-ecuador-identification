using System;

namespace Luilliarcec.Identification.Ecuador.Exceptions
{
    public class IdentificationException : Exception
    {
        //
        // Resumen:
        //     Inicializa una nueva instancia de la clase System.Exception.
        public IdentificationException() : base()
        {
        }

        //
        // Resumen:
        //     Inicializa una nueva instancia de la clase System.Exception con el mensaje de
        //     error especificado.
        //
        // Parámetros:
        //   message:
        //     Mensaje que describe el error.
        public IdentificationException(string message) : base(message)
        {
        }
    }
}
