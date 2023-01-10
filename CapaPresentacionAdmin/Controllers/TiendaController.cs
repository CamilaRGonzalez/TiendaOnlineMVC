using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaPresentacionAdmin.Permisos;
using CapaEntidad;
using System.Configuration;
using System.IO;
using System.Globalization;
using Path = System.IO.Path;

namespace CapaPresentacionAdmin.Controllers
{
    public class TiendaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Logueado]
        public ActionResult CarritoCompra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModificarCantidad(int IdProducto, string modo)
        {
            List<Carrito> compra = (List<Carrito>)Session["Carrito"];
            foreach (Carrito item in compra)
            {
                if(IdProducto == item.Producto.IdProducto)
                {
                    if (modo == "sumar")
                        item.Cantidad++;
                    else
                    {
                        if(item.Cantidad -1 <= 0)
                            return Json(new { respuesta = 1 }, JsonRequestBehavior.AllowGet);
                        item.Cantidad--;
                    }
                        
                    item.Total = item.Cantidad * item.Producto.Precio;
                    item.strTotal = item.Total.ToString("C3", CultureInfo.CreateSpecificCulture("es-AR"));
                }
            }

            Session.Add("Carrito", compra);
            return Json(new { respuesta = 1 }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult EliminarDelCarrito(int IdProducto)
        {
            List<Carrito> compra = (List<Carrito>)Session["Carrito"];
            Carrito item = compra.Find(c => c.Producto.IdProducto == IdProducto);
            compra.Remove(item);
            if (compra.Count == 0)
                Session.Remove("Carrito");
            else
                Session.Add("Carrito", compra);
            return Json(new { respuesta = 1 }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerCarrito()
        {
            if (Session["Carrito"] == null)
                return Json(new { data = 0, resultado = 0 }, JsonRequestBehavior.AllowGet);

            List<Carrito> compra = (List<Carrito>)Session["Carrito"];
            int total = HelperCarrito.ContarProductos(compra);
            decimal monto = HelperCarrito.MontoTotalCarrito(compra);

            return Json(new { data = compra, total = total, monto = monto }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AgregarCarrito(int IdProducto)
        {
            ProductoNegocio accesoDB = new ProductoNegocio();
            Producto p = accesoDB.ListarActivos(0, 0).Where(pr => pr.IdProducto == IdProducto).FirstOrDefault();
            Carrito pedido = new Carrito();
            pedido.Cantidad = 1;
            pedido.Producto = p;
            pedido.Total = p.Precio;
            pedido.strTotal = pedido.Total.ToString("C3", CultureInfo.CreateSpecificCulture("es-AR"));
            List<Carrito> compra;
            pedido.Producto.UrlImagen = HelperProducto.rutaBase64(p.UrlImagen);

            if (Session["Carrito"] == null)
                compra = new List<Carrito>();
            else
                compra = (List<Carrito>)Session["Carrito"];
            
            foreach (Carrito item in compra)
            {
                if(item.Producto.IdProducto == IdProducto)
                    return Json(new { resultado = 0 }, JsonRequestBehavior.AllowGet);
            }
            
            compra.Add(pedido);
            Session.Add("Carrito", compra);
            return Json(new { resultado = 1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DetalleProducto(int IdProducto)
        {
            ProductoNegocio accesoDB = new ProductoNegocio();
            Producto p = accesoDB.ListarActivos(0, 0).Where(pr => pr.IdProducto == IdProducto).FirstOrDefault();
        
            if (p != null)
            {
                string precio = p.Precio.ToString("C3", CultureInfo.CreateSpecificCulture("es-AR"));
                p.strPrecio = precio;
                p.UrlImagen = HelperProducto.rutaBase64(p.UrlImagen);
            }
            return View(p);
        }

        [HttpGet]
        public JsonResult MostrarCategorias()
        {
            CategoriaNegocio accesoDB = new CategoriaNegocio();

            List<Categoria> lista = accesoDB.ListarCategorias(true);

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MostrarMarcas(int categoria)
        {
            MarcaNegocio accesoDB = new MarcaNegocio();

            List<Marca> lista = accesoDB.ListarSegunCateg(categoria);

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MostrarProductos(int categoria, int marca)
        {
            ProductoNegocio accesoDB = new ProductoNegocio();

            List<Producto> lista = accesoDB.ListarActivos(marca,categoria).Where(p => p.Stock > 0).ToList();

            string ruta;
            string textoBase64;
            string ext;

            foreach (Producto p in lista)
            {
                bool conversion;
                ruta = ConfigurationManager.AppSettings["CarpetaImagenesProductos"] + p.UrlImagen;
                textoBase64 = HelperProducto.ConvertirBase64((ruta), out conversion);
                ext = Path.GetExtension(p.UrlImagen);

                p.UrlImagen = "data:image/" + ext + ";base64," + textoBase64;
            }

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult RealizarPedido()
        {
            List<Carrito> compra = (List<Carrito>)Session["Carrito"];
            PedidosNegocio datos = new PedidosNegocio();
            Pedido pedido = new Pedido();

            pedido.TotalProductos = HelperCarrito.ContarProductos(compra);
            pedido.MontoTotal = HelperCarrito.MontoTotalCarrito(compra);
            pedido.Cliente = (Cliente)Session["Usuario"];
            pedido.IdTransaccion = PedidosNegocio.GenerarClave();
            pedido.IdPedido = datos.CrearPedido(pedido);

            foreach (Carrito item in compra)
            {
                datos.CrearDetallePedido(item, pedido.IdPedido);
            }

            Session.Remove("Carrito");
            return Json(new { data = pedido.IdPedido }, JsonRequestBehavior.AllowGet);
        }
    }
}