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
    /// Acceso a datos para la tabla de clientes
    /// </summary>
    public class ClienteCrud : Conexion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClienteCrud"/> class.
        /// </summary>
        public ClienteCrud() : base("PruebaBD")
        {

        }

        /// <summary>
        /// Consultars the clientes.
        /// </summary>
        /// <returns></returns>
        public List<Cliente> ConsultarClientes()
        {
            using (SqlConnection sqlConn = new SqlConnection(Conexion.Cadena))
            {
                List<Cliente> clientes = new List<Cliente>();
                SqlCommand cmd = new SqlCommand("STM_CLIENTES", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    Cliente cliente = null;
                    while (read.Read())
                        clientes.Add(MapearCliente(read, cliente));
                }

                return clientes;
            }
        }

        /// <summary>
        /// Mapears the cliente.
        /// </summary>
        /// <param name="read">The read.</param>
        /// <param name="cliente">The cliente.</param>
        /// <returns></returns>
        private Cliente MapearCliente(SqlDataReader read, Cliente cliente)
        {
            cliente = new Cliente();
            cliente.Id = Convert.ToInt32(read["Id"]);
            cliente.Nombre = read["Nombre"].ToString();
            cliente.Email = read["Email"].ToString();
            return cliente;
        }
    }
}
