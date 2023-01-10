using CapaPresentacionAdmin.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    [Logueado]
    public class ListaPedidosController : Controller
    {
        private PedidosNegocio datos = new PedidosNegocio();

        // GET: ListaPedidos
        public ActionResult Pedidos()
        {
            return View();
        }
        public ActionResult Detalle(string idPedido)
        {
            Session.Add("IdPedido", int.Parse(idPedido));
            return View();
        }

        [HttpGet]
        public JsonResult ListarPedidos()
        {
            Cliente user = (Cliente)Session["Usuario"];
            List<Pedido> lista = datos.ListarPedidos(true, user.IdCliente);

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DetallePedido()
        {
            int id = (int)Session["IdPedido"];
            List<DetallePedido> lista = datos.DetallePedido(true, id);

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}