using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /// <summary>
    /// Clase base para Definir el id del objeto
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Identificador<T>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public T Id { get; set; }
    }
}
