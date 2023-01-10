using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class PedidosDB
    {
        public List<Pedido> ListarPedidos(bool filtro = false, int idCliente=0)
        {

            AccesoDB datos = new AccesoDB();
            try
            {
                string query = "select * from Pedido P inner join Cliente C on C.IdCliente= P.IdCliente";

                if (filtro)
                    query += " where P.IdCliente = @IdCliente";

                datos.HacerConsulta(query);
                if (filtro)
                    datos.setearParametro("@IdCliente", idCliente);

                datos.EjecutarLectura();
                List<Pedido> lista = new List<Pedido>();

                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();
                    aux.IdPedido = (int)datos.Lector["IdPedido"];
                    aux.IdTransaccion = (string)datos.Lector["IdTransaccion"];
                    aux.strFechaVenta = ((DateTime)datos.Lector["FechaVenta"]).ToShortDateString();
                    aux.MontoTotal = (decimal)datos.Lector["MontoTotal"];
                    aux.TotalProductos = (int)datos.Lector["TotalProductos"];
                    
                    aux.Cliente = new Cliente();
                    aux.Cliente.Nombre = (string)datos.Lector["Nombre"];
                    aux.Cliente.Apellido = (string)datos.Lector["Apellido"];
                    aux.Cliente.Email = (string)datos.Lector["Email"];
                    aux.Cliente.Password = (string)datos.Lector["Password"];

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
        public int CrearPedido(Pedido pedido)
        {
            AccesoDB datos = new AccesoDB();
            int id;
            try
            {
                datos.setearSP("sp_CrearPedido");
                datos.setearParametro("@IdCliente",pedido.Cliente.IdCliente);
                datos.setearParametro("@IdTransaccion",pedido.IdTransaccion);
                datos.setearParametro("@MontoTotal", pedido.MontoTotal);
                datos.setearParametro("@TotalProductos",pedido.TotalProductos);
                datos.setearParametroSalida("Resultado");

                datos.EjecutarAccion();

                id = (int)datos.obtenerOutput("Resultado");
                return id;
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


        public void CrearDetallePedido(Carrito pedido, int IdPedido)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearSP("sp_DetallePedido");
                datos.setearParametro("@IdPedido", IdPedido);
                datos.setearParametro("@IdProducto", pedido.Producto.IdProducto);
                datos.setearParametro("@Cantidad", pedido.Cantidad);
                datos.setearParametro("@Total", pedido.Total);

                datos.EjecutarAccion();

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

        public List<DetallePedido> DetallePedido(bool filtro = false, int IdPedido = 0)
        {

            AccesoDB datos = new AccesoDB();
            try
            {
                string query = "SELECT P.Nombre,M.Descripcion as Marca,D.Cantidad,D.Total from Producto P inner join Marca M on M.IdMarca = P.IdMarca inner join DetallePedido D on D.IdProducto = P.IdProducto";

                if (filtro)
                    query += " where D.IdPedido= @IdPedido";

                datos.HacerConsulta(query);
                if (filtro)
                    datos.setearParametro("@IdPedido", IdPedido);

                datos.EjecutarLectura();
                List<DetallePedido> lista = new List<DetallePedido>();

                while (datos.Lector.Read())
                {
                    DetallePedido aux = new DetallePedido();
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Total = (decimal)datos.Lector["Total"];

                    aux.Producto = new Producto();
                    aux.Producto.Nombre = (string)datos.Lector["Nombre"];
                    aux.Producto.Marca = new Marca();
                    aux.Producto.Marca.Descripcion = (string)datos.Lector["Marca"];

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
