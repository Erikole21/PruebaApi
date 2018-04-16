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
    /// Clase CRUD para administrar las ordenes
    /// </summary>
    /// <seealso cref="Data.Conexion" />
    public class OrdenCrud : Conexion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetalleOrdenCrud"/> class.
        /// </summary>
        public OrdenCrud() : base("PruebaBD")
        {

        }


        /// <summary>
        /// Guardars the orden.
        /// </summary>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public int GuardarOrden(Orden orden)
        {
            using (SqlConnection sqlConn = new SqlConnection(Conexion.Cadena))
            {
                SqlCommand cmd = new SqlCommand("STM_ORDENES", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_CLIENTE", orden.Cliente.Id);
                cmd.Parameters.AddWithValue("@DIRECCION_ENTREGA", orden.DireccionEntrega);
                cmd.Parameters.AddWithValue("@VALOR_TOTAL", orden.ValorTotal);
                cmd.Parameters.AddWithValue("@OPERACION", 1);
                sqlConn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }



        /// <summary>
        /// Consultars the ordenes cliente rango.
        /// </summary>
        /// <param name="idCliente">The identifier cliente.</param>
        /// <param name="fechaInicial">The fecha inicial.</param>
        /// <param name="fechaFinal">The fecha final.</param>
        /// <returns></returns>
        public List<Orden> ConsultarOrdenesClienteRango(int idCliente, DateTime fechaInicial, DateTime fechaFinal)
        {
            using (SqlConnection sqlConn = new SqlConnection(Conexion.Cadena))
            {
                List<Orden> ordenes = new List<Orden>();
                SqlCommand cmd = new SqlCommand("STM_ORDENES", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_CLIENTE", idCliente);
                cmd.Parameters.AddWithValue("@FECHA_INICIAL", fechaInicial);
                cmd.Parameters.AddWithValue("@FECHA_FINAL", fechaFinal);
                cmd.Parameters.AddWithValue("@OPERACION", 2);
                sqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    Orden orden = null;
                    while (read.Read())
                        ordenes.Add(MapearOrden(read, orden));
                }

                return ordenes;
            }
        }



        /// <summary>
        /// Mapears the orden.
        /// </summary>
        /// <param name="read">The read.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        private Orden MapearOrden(SqlDataReader read, Orden orden)
        {
            orden = new Orden();
            orden.Id = Convert.ToInt32(read["Id"]);
            orden.FechaRegistro = Convert.ToDateTime(read["FechaRegistro"]);
            orden.ValorTotal = Convert.ToDecimal(read["ValorTotal"]);
            orden.DireccionEntrega = read["DireccionEntrega"].ToString();

            return orden;
        }
    }
}
