using System;

namespace Entities
{
    /// <summary>
    /// Cliente
    /// </summary>
    /// <seealso cref="Entities.Identificador{System.Int32}" />
    public class Cliente : Identificador<int>
    {
        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }        

    }
}
