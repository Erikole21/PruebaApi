using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /// <summary>
    /// Detalle de la orden
    /// </summary>
    /// <seealso cref="Entities.Identificador{System.Int32}" />
    public class DetalleOrden : Identificador<int>
    {
        /// <summary>
        /// Gets or sets the identifier orden.
        /// </summary>
        /// <value>
        /// The identifier orden.
        /// </value>
        public int IdOrden { get; set; }

        /// <summary>
        /// Gets or sets the producto.
        /// </summary>
        /// <value>
        /// The producto.
        /// </value>
        public Producto Producto { get; set; }

        /// <summary>
        /// Gets or sets the precio unitario.
        /// </summary>
        /// <value>
        /// The precio unitario.
        /// </value>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Gets or sets the cantidad.
        /// </summary>
        /// <value>
        /// The cantidad.
        /// </value>
        public int Cantidad { get; set; }

        /// <summary>
        /// Gets or sets the valor total.
        /// </summary>
        /// <value>
        /// The valor total.
        /// </value>
        public decimal ValorTotal { get; set; }
    }
}
