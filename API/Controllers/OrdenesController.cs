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
        /// Ordenes realizadas por un cliente en un rango de fechas
        /// </summary>
        /// <param name="idCLiente">el identificador del cliente.</param>
        /// <param name="fechaInicial">Fecha inicial para realizar la busqueda</param>
        /// <param name="fechaFinal">Fecha final para realizar la busqueda</param>
        /// <returns></returns>
        [HttpGet]
        [Route("OrdenesClienteRango")]
        public List<Orden> OrdenesClienteRango([FromUri]int idCLiente, [FromUri] DateTime fechaInicial, [FromUri] DateTime fechaFinal)
        {
            if (idCLiente > 0)
            {
                using (Logica.OrdenesBll rule = new Logica.OrdenesBll())
                    return rule.ConsultarOrdenesClienteRango(idCLiente, fechaInicial, fechaFinal);
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
        /// Cantidads the productos adquiridos cliente. la cantidad de productos la asigna en la propiedad precio
        /// </summary>
        /// <param name="idCliente">el identificador del cliente.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("CantidadProductosAdquiridosCliente/{idCliente}")]
        public List<Producto> ConsultarCantidadProductosAdquiridosCliente(int idCliente)
        {
            using (Logica.OrdenesBll rule = new Logica.OrdenesBll())
                return rule.ConsultarCantidadProductosAdquiridosCliente(idCliente);
        }

        /// <summary>
        /// Consulta el porcentaje de venta de cada producto, asigna el porcentaje en la propiedad precio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ConsultarPorcentajeProductosVendidos")]
        public List<Producto> ConsultarPorcentajeProductosVendidos()
        {
            using (Logica.OrdenesBll rule = new Logica.OrdenesBll())
                return rule.ConsultarPorcentajeProductosVendidos();
        }

        /// <summary>
        /// Consulta los productos permitidos para un cliente
        /// </summary>
        /// <param name="idCliente">El identificador del cliente</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ConsultarProductosPermitidosCliente/{idCliente}")]
        public List<Producto> ConsultarProductosPermitidosCliente(int idCliente)
        {
            using (Logica.OrdenesBll rule = new Logica.OrdenesBll())
                return rule.ConsultarProductosPermitidosCliente(idCliente);
        }


    }
}
