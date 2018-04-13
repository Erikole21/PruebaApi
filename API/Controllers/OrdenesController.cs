using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    /// <summary>
    /// API para Manejo de ordenes
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Ordenes")]
    public class OrdenesController : ApiController
    {
        /// <summary>
        /// Guarda la orden.
        /// </summary>
        /// <param name="orden">La orden.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GuardarOrden")]
        public int GuardarOrden([FromBody]Orden orden)
        {
            using (Logica.OrdenesBll rule = new Logica.OrdenesBll())
                return rule.GuardarOrden(orden);
        }

        /// <summary>
        /// Consulta las ordenes de un cliente en un rango de fechas.
        /// </summary>
        /// <param name="parametro">El parametro. con los valores de id cliente y rango de fechas</param>
        /// <returns></returns>
        [HttpGet]
        [Route("OrdenesClienteRango")]
        public List<Orden> OrdenesClienteRango([FromBody]Entities.ParametroConsultaClienteRango parametro)
        {
            if (parametro != null)
            {
                using (Logica.OrdenesBll rule = new Logica.OrdenesBll())
                    return rule.ConsultarOrdenesClienteRango(parametro.IdCliente, parametro.FechaInicio, parametro.FechaFin);
            }
            else
                return new List<Orden>();
        }


        /// <summary>
        /// Consulta los clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Clientes")]
        public List<Cliente> Clientes()
        {
            using (Logica.OrdenesBll rule = new Logica.OrdenesBll())
                return rule.ConsultarClientes();
        }

        /// <summary>
        /// Cantidad de productos adquiridos por cliente.
        /// </summary>
        /// <param name="idCliente">el identificador del cliente.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("CantidadProductosAdquiridosCliente/{idCliente}")]
        public int CantidadProductosAdquiridosCliente(int idCliente)
        {
            using (Logica.OrdenesBll rule = new Logica.OrdenesBll())
                return rule.CantidadProductosAdquiridosCliente(idCliente);
        }
    }
}
