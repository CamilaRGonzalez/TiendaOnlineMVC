using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public Cliente Cliente { get; set; }
        public string IdTransaccion { get; set; }
        public DateTime FechaVenta { get; set; }
        public string strFechaVenta { get; set; }
        public decimal MontoTotal { get; set; }
        public int TotalProductos { get; set; }

    }
}
