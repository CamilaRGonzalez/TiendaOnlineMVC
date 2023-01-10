using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using static System.Net.Mime.MediaTypeNames;
using CapaPresentacionAdmin.Permisos;

namespace CapaPresentacionAdmin.Controllers
{
    [Logueado]
    public class HomeController : Controller
    {
        [PermisosRol(1)]
        public ActionResult Index()
        {
            return View();
        }
        [PermisosRol(1)]
        public ActionResult Usuarios()
        {
            return View();
        }

        public ActionResult SinPermiso()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Cliente> oLista = new List<Cliente>();

            oLista = new ClienteNegocio().ListarClientes();

            return Json(new { data = oLista } , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarUsuario(Cliente cliente)
        {
            ClienteNegocio registro = new ClienteNegocio();
            string mensaje = string.Empty;
            int resultado;

            if(cliente.IdCliente == 0)
            {
                resultado = registro.RegistrarUsuario(cliente, out mensaje);
                return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                resultado = registro.ModificarUsuario(cliente, out mensaje) ? 1 : 0;
                return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
            }           
        }

        [HttpPost]
        public JsonResult EliminarUsuario(int idCliente)
        {
            ClienteNegocio registro = new ClienteNegocio();
            string mensaje = string.Empty;
            bool resultado;

            resultado = registro.EliminarUsuario(idCliente, out mensaje);
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult ListarPedidos(string fechaInicio, string fechaFin, string IdTransaccion)
        {
            List<PedidosAdmin> oLista = new List<PedidosAdmin>();

            bool filtro = fechaInicio == "" ? false : true;

            oLista = new PedidosAdminNegocio().ListarPedidos(fechaInicio, fechaFin, IdTransaccion,filtro);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public FileResult ExportarVentas(string fechaInicio, string fechaFin, string IdTransaccion)
        {

            List<PedidosAdmin> oLista = new List<PedidosAdmin>();

            oLista = new PedidosAdminNegocio().ListarPedidos(fechaInicio, fechaFin, IdTransaccion, true);

            DataTable dt = new DataTable();

            dt.Locale = new System.Globalization.CultureInfo("es-AR");
            dt.Columns.Add("Fecha Venta", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("IdTransaccion", typeof(string));

 
            foreach (PedidosAdmin rp in oLista)
            {
                
                dt.Rows.Add(new object[] {
                    rp.FechaVenta,
                    rp.Cliente,
                    rp.Producto,
                    rp.Precio,
                    rp.Cantidad,
                    rp.Total,
                    rp.IdTransaccion
                });

            }

            dt.TableName = "Datos";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteVenta" + DateTime.Now.ToString() + ".xlsx");

                }
            }

        }

    }
}