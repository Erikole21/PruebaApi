using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    /// <summary>
    /// Clase CRUD para administrar los detalles de la orden
    /// </summary>
    /// <seealso cref="Data.Conexion" />
    public class DetalleOrdenCrud : Conexion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetalleOrdenCrud"/> class.
        /// </summary>
        public DetalleOrdenCrud() : base("PruebaBD")
        {

        }

        /// <summary>
        /// Guardars the detalle orden.
        /// </summary>
        /// <param name="detalle">The detalle.</param>
        /// <returns></returns>
        public int GuardarDetalleOrden(DetalleOrden detalle)
        {
            using (SqlConnection sqlConn = new SqlConnection(Conexion.Cadena))
            {
                SqlCommand cmd = new SqlCommand("STM_DETALLE_ORDENES", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ORDEN", detalle.IdOrden);
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", detalle.Producto.Id);
                cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", detalle.PrecioUnitario);
                cmd.Parameters.AddWithValue("@CANTIDAD", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@VALOR_TOTAL", detalle.ValorTotal);
                cmd.Parameters.AddWithValue("@OPERACION", 1);
                sqlConn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        /// <summary>
        /// Consultars the detalle orden.
        /// </summary>
        /// <param name="idOrden">The identifier orden.</param>
        /// <returns></returns>
        public List<DetalleOrden> ConsultarDetalleOrden(int idOrden)
        {
            using (SqlConnection sqlConn = new SqlConnection(Conexion.Cadena))
            {
                List<DetalleOrden> detalles = new List<DetalleOrden>();
                SqlCommand cmd = new SqlCommand("STM_DETALLE_ORDENES", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ORDEN", idOrden);
                cmd.Parameters.AddWithValue("@OPERACION", 2);
                sqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    DetalleOrden detalle = null;
                    while (read.Read())
                        detalles.Add(MapearDetalleOrden(read, detalle));
                }

                return detalles;
            }
        }

        /// <summary>
        /// Mapears the detalle orden.
        /// </summary>
        /// <param name="read">The read.</param>
        /// <param name="detalle">The detalle.</param>
        /// <returns></returns>
        private DetalleOrden MapearDetalleOrden(SqlDataReader read, DetalleOrden detalle)
        {
            detalle = new DetalleOrden();
            detalle.Producto = new Producto();
            detalle.Id = Convert.ToInt32(read["IdDetalle"]);
            detalle.Producto.Id = Convert.ToInt32(read["Id"]);
            detalle.Producto.Nombre = read["Nombre"].ToString();
            detalle.PrecioUnitario = Convert.ToDecimal(read["PrecioUnitario"]);
            detalle.Cantidad = Convert.ToInt32(read["Cantidad"]);
            detalle.ValorTotal = Convert.ToDecimal(read["ValorTotal"]);
            return detalle;
        }
    }
}
