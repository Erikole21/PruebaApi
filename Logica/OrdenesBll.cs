using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Logica
{
    /// <summary>
    /// Logica de negocio para Ordenes de productos
    /// </summary>
    public class OrdenesBll : IDisposable
    {
        /// <summary>
        /// Guardars the orden.
        /// </summary>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public int GuardarOrden(Orden orden)
        {
            if (orden != null && orden.Detalle?.Count > 0 && orden.Detalle?.Count < 6)
            {
                int idOrden = 0;

                using (TransactionScope scope = new TransactionScope())
                {
                    using (Data.OrdenCrud crud = new Data.OrdenCrud())
                        idOrden = crud.GuardarOrden(orden);

                    using (Data.DetalleOrdenCrud detalleCrud = new Data.DetalleOrdenCrud())
                        foreach (var detalle in orden.Detalle)
                        {
                            detalle.IdOrden = idOrden;
                            detalleCrud.GuardarDetalleOrden(detalle);
                        }

                    scope.Complete();
                }

                return idOrden;
            }
            else
                return 0;
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
            List<Orden> ordenes = new List<Orden>();
            if (idCliente != 0)
            {
                using (Data.OrdenCrud crud = new Data.OrdenCrud())
                    ordenes = crud.ConsultarOrdenesClienteRango(idCliente, fechaInicial, fechaFinal);

                //Este punto lo evaluaria con el cliente si funcionalmente necesita de una ver el detalle de cada orden 
                //lo cargo de este modo ya q en la imagen enviada de la solicitud muestran el detalle de una ves 
                //Sugeriria realizar la carga por demanda solo cuando se quiera ver el detalle de una orden seleccionada.
                using (Data.DetalleOrdenCrud crud = new Data.DetalleOrdenCrud())
                    foreach (var orden in ordenes)
                        orden.Detalle = crud.ConsultarDetalleOrden(orden.Id);

            }

            return ordenes;
        }

        /// <summary>
        /// Consultars the clientes.
        /// </summary>
        /// <returns></returns>
        public List<Cliente> ConsultarClientes()
        {
            using (Data.ClienteCrud crud = new Data.ClienteCrud())
                return crud.ConsultarClientes();
        }

        /// <summary>
        /// Cantidads the productos adquiridos cliente.
        /// </summary>
        /// <param name="idCliente">The identifier cliente.</param>
        /// <returns></returns>
        public int CantidadProductosAdquiridosCliente(int idCliente)
        {
            using (Data.ProductoCrud crud = new Data.ProductoCrud())
                return crud.CantidadProductosAdquiridosCliente(idCliente);
        }

        public void Dispose()
        {
            
        }
    }
}
