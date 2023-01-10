using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ProductoNegocio
    {
        public List<Producto> ListarProductos()
        {
            ProductoDB accesoDB = new ProductoDB();
            return accesoDB.ListarProductos();
        }

        public List<Producto> ListarActivos(int marca, int categoria)
        {
            ProductoDB accesoDB = new ProductoDB();
            return accesoDB.ListarActivos(categoria,marca);
        }

        public void GuardarRutaImg(Producto prod)
        {
            ProductoDB accesoDB = new ProductoDB();
            accesoDB.GuardarRutaImg(prod);
        }

        public int RegistrarProducto(Producto prod, out string mensaje)
        {
            int id;
            ProductoDB accesoDB = new ProductoDB();
            decimal precio;
            int stock;
            mensaje = "";

            if (HelperProducto.camposVacios(prod) != "")
            {
                mensaje = "false";
            }
            if (!HelperProducto.EsDecimal(prod.strPrecio,out precio))
            {
                mensaje = "false";
            }
            if(!HelperProducto.EsEntero(prod.strStock, out stock))
            {
                mensaje = "false";
            }
            
            if (mensaje != "")
                return 0;

            prod.Precio = precio;
            prod.Stock = stock;
                
            if (prod.IdProducto == 0)
                id = accesoDB.RegistrarProducto(prod);
            else
                id = accesoDB.EditarProducto(prod);

            if (id == 0)
            {
                mensaje = "Ya exsiste el producto " + prod.Nombre;
                return 0;
            }

            mensaje = "ok";
            return id;
        }
    }
}
