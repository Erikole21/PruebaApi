using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /// <summary>
    /// Producto
    /// </summary>
    /// <seealso cref="Entities.Identificador{System.Int32}" />
    public class Producto : Identificador<int>
    {
        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the precio.
        /// </summary>
        /// <value>
        /// The precio.
        /// </value>
        public decimal Precio { get; set; }
    }
}
