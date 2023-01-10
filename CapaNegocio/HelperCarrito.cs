using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaEntidad;
using System.Configuration;


namespace CapaNegocio
{
    public class HelperCarrito
    {
        public static int ContarProductos(List<Carrito> carrito)
        {
            int total = 0;

            foreach (Carrito item in carrito)
            {
                total += item.Cantidad;
            }

            return total;
        }

        public static decimal MontoTotalCarrito(List<Carrito> carrito)
        {
            decimal total = 0;

            foreach (Carrito item in carrito)
            {
                total += item.Total;
            }

            return total;
        }
    }
}
