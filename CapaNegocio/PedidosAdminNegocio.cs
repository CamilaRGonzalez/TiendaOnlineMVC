using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class PedidosAdminNegocio
    {
        public List<PedidosAdmin> ListarPedidos(string fechaInicio, string fechaFin, string IdTransaccion, bool filtro = false)
        {
            PedidosAdminDB datos = new PedidosAdminDB();
            if (!filtro)
                return datos.ListarPedidos(fechaInicio, fechaFin, IdTransaccion);
            else
            {
                return datos.ListarPedidos(fechaInicio, fechaFin, IdTransaccion,filtro);
            }
        }
    }
}
