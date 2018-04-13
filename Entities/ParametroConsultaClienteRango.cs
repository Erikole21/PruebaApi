using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /// <summary>
    /// Clase para envio de parametros desde cliente
    /// </summary>
    public class ParametroConsultaClienteRango
    {
        /// <summary>
        /// Gets or sets the identifier cliente.
        /// </summary>
        /// <value>
        /// The identifier cliente.
        /// </value>
        public int IdCliente { get; set; }
        /// <summary>
        /// Gets or sets the fecha inicio.
        /// </summary>
        /// <value>
        /// The fecha inicio.
        /// </value>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Gets or sets the fecha fin.
        /// </summary>
        /// <value>
        /// The fecha fin.
        /// </value>
        public DateTime FechaFin { get; set; }
    }
}
