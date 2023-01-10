using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class PedidosAdminDB
    {
        public List<PedidosAdmin> ListarPedidos(string fechaInicio, string fechaFin, string IdTransaccion, bool filtro = false)
        {

            AccesoDB datos = new AccesoDB();
            try
            {   
                if(!filtro)               
                    datos.setearSP("sp_ListarPedidos");                                  
                else
                {
                    datos.setearSP("sp_listarPedidosFiltro");
                    datos.setearParametro("@fechaInicio", fechaInicio);
                    datos.setearParametro("@fechaFin", fechaFin);
                    datos.setearParametro("@IdTransaccion", IdTransaccion);
                }
                
                datos.EjecutarLectura();
                List<PedidosAdmin> lista = new List<PedidosAdmin>();

                while (datos.Lector.Read())
                {
                    PedidosAdmin aux = new PedidosAdmin();

                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Total = (decimal)datos.Lector["Total"];                    
                    aux.Producto = (string)datos.Lector["Producto"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.FechaVenta = ((DateTime)datos.Lector["Fecha"]).ToShortDateString();
                    aux.IdTransaccion = (string)datos.Lector["IdTransaccion"];
                    aux.Cliente = (string)datos.Lector["Cliente"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }
    }
}
