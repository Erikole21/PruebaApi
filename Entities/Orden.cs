using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /// <summary>
    /// Orden
    /// </summary>
    /// <seealso cref="Entities.Identificador{System.Int32}" />
    public class Orden : Identificador<int>
    {
        /// <summary>
        /// Gets or sets the cliente.
        /// </summary>
        /// <value>
        /// The cliente.
        /// </value>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Gets or sets the fecha registro.
        /// </summary>
        /// <value>
        /// The fecha registro.
        /// </value>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Gets or sets the direccion entrega.
        /// </summary>
        /// <value>
        /// The direccion entrega.
        /// </value>
        public string DireccionEntrega { get; set; }

        /// <summary>
        /// Gets or sets the valor total.
        /// </summary>
        /// <value>
        /// The valor total.
        /// </value>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Gets or sets the detalle.
        /// </summary>
        /// <value>
        /// The detalle.
        /// </value>
        public List<DetalleOrden> Detalle { get; set; }

    }
}
