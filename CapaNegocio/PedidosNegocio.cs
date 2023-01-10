using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class PedidosNegocio
    {
        public static string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0, 6);
            return clave;
        }

        public int CrearPedido(Pedido pedido)
        {
            PedidosDB accesoDB = new PedidosDB();

            return accesoDB.CrearPedido(pedido);

        }

        public void CrearDetallePedido(Carrito pedido, int IdPedido)
        {
            PedidosDB accesoDB = new PedidosDB();

            accesoDB.CrearDetallePedido(pedido, IdPedido);
        }

        public List<Pedido> ListarPedidos(bool filtro = false, int idCliente = 0)
        {
            PedidosDB accesoDB = new PedidosDB();

            return accesoDB.ListarPedidos(filtro, idCliente);
        }

        public List<DetallePedido> DetallePedido(bool filtro = false, int IdPedido = 0)
        {
            PedidosDB accesoDB = new PedidosDB();

            return accesoDB.DetallePedido(filtro, IdPedido);
        }
    }
}
