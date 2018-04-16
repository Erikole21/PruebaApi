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
    /// Acceso a datos para la tabla de productos
    /// </summary>
    public class ProductoCrud : Conexion
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductoCrud"/> class.
        /// </summary>
        public ProductoCrud() : base("PruebaBD")
        {

        }


        /// <summary>
        /// Consultars the productos permitidos cliente.
        /// </summary>
        /// <param name="idCliente">The identifier cliente.</param>
        /// <returns></returns>
        public List<Producto> ConsultarProductosPermitidosCliente(int idCliente)
        {
            using (SqlConnection sqlConn = new SqlConnection(Conexion.Cadena))
            {
                List<Producto> productos = new List<Producto>();
                SqlCommand cmd = new SqlCommand("STM_PRODUCTOS", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCLIENTE", idCliente);
                cmd.Parameters.AddWithValue("@OPERACION", 1);
                sqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    Producto producto = null;
                    while (read.Read())
                        productos.Add(MapearProducto(read, producto));
                }

                return productos;
            }
        }

        /// <summary>
        /// Consulta el porcentaje de venta de cada producto, asigna el porcentaje en la propiedad precio
        /// </summary>
        /// <returns></returns>
        public List<Producto> ConsultarPorcentajeProductosVendidos()
        {
            using (SqlConnection sqlConn = new SqlConnection(Conexion.Cadena))
            {
                List<Producto> productos = new List<Producto>();
                SqlCommand cmd = new SqlCommand("STM_PRODUCTOS", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@OPERACION", 3);
                sqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    Producto producto = null;
                    while (read.Read())
                        productos.Add(MapearProducto(read, producto));
                }

                return productos;
            }
        }

        /// <summary>
        /// Cantidads the productos adquiridos por cliente.
        /// </summary>
        /// <param name="idCliente">The identifier cliente.</param>
        /// <returns></returns>
        public List<Producto> ConsultarCantidadProductosAdquiridosCliente(int idCliente)
        {
            using (SqlConnection sqlConn = new SqlConnection(Conexion.Cadena))
            {
                List<Producto> productos = new List<Producto>();
                SqlCommand cmd = new SqlCommand("STM_PRODUCTOS", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCLIENTE", idCliente);
                cmd.Parameters.AddWithValue("@OPERACION", 2);
                sqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    Producto producto = null;
                    while (read.Read())
                        productos.Add(MapearProducto(read, producto));
                }

                return productos;
            }
        }


        /// <summary>
        /// Mapears the producto.
        /// </summary>
        /// <param name="read">The read.</param>
        /// <param name="producto">The producto.</param>
        /// <returns></returns>
        private Producto MapearProducto(SqlDataReader read, Producto producto)
        {
            producto = new Producto();
            producto.Id = Convert.ToInt32(read["Id"]);
            producto.Nombre = read["Nombre"].ToString();
            producto.Precio = Convert.ToDecimal(read["Precio"]);
            return producto;
        }
    }
}
