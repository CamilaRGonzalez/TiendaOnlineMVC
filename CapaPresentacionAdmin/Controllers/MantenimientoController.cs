using CapaEntidad;
using CapaNegocio;
//using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using CapaPresentacionAdmin.Permisos;

namespace CapaPresentacionAdmin.Controllers
{
    [Logueado]
    public class MantenimientoController : Controller
    {
        // GET: Mantenimiento
        [PermisosRol(1)]
        public ActionResult Categoria()
        {
            return View();
        }
        [PermisosRol(1)]
        public ActionResult Marca()
        {
            return View();
        }
        [PermisosRol(1)]
        public ActionResult Producto()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarCategorias()
        {
            List<Categoria> oLista = new List<Categoria>();

            oLista = new CategoriaNegocio().ListarCategorias();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarCategoria(Categoria categ)
        {
            CategoriaNegocio registro = new CategoriaNegocio();
            string mensaje = string.Empty;
            int resultado;

            resultado = registro.RegistrarCategoria(categ, out mensaje);
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult ListarMarcas()
        {
            List<Marca> oLista = new List<Marca>();

            oLista = new MarcaNegocio().ListarMarcas();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarMarca(Marca marca)
        {
            MarcaNegocio registro = new MarcaNegocio();
            string mensaje = string.Empty;
            int resultado;

            resultado = registro.RegistrarMarca(marca, out mensaje);
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult ListarProductos()
        {
            List<Producto> oLista = new List<Producto>();

            oLista = new ProductoNegocio().ListarProductos();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarProducto(string producto,HttpPostedFileBase fileImagen)
        {
            ProductoNegocio registro = new ProductoNegocio();
            string mensaje = string.Empty;
            int resultado;

            Producto prod = new Producto();
            prod = JsonConvert.DeserializeObject<Producto>(producto);
            resultado = registro.RegistrarProducto(prod, out mensaje);

            if(resultado != 0 && fileImagen != null)
            {
                if(prod.IdProducto == 0)
                    prod.IdProducto = resultado;

                string extension = Path.GetExtension(fileImagen.FileName);              
                prod.UrlImagen = "Producto-" + prod.IdProducto + extension;
                string ruta = ConfigurationManager.AppSettings["CarpetaImagenesProductos"];
                string rutaCompleta = ruta + prod.UrlImagen;
                fileImagen.SaveAs(rutaCompleta);
                registro.GuardarRutaImg(prod);
                
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult ImagenProducto(int id)
        {
            bool conversion;
            Producto oproducto = new ProductoNegocio().ListarProductos().Where(p => p.IdProducto == id).FirstOrDefault();
            
            string ruta = ConfigurationManager.AppSettings["CarpetaImagenesProductos"] + oproducto.UrlImagen;
            string textoBase64 = HelperProducto.ConvertirBase64((ruta), out conversion);
            string ext = Path.GetExtension(oproducto.UrlImagen);

            return Json(new
            {
                conversion = conversion,
                textobase64 = textoBase64,
                extension = ext

            },
             JsonRequestBehavior.AllowGet
            );


        }
    }
}