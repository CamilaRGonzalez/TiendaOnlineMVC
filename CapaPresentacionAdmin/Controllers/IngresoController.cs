using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using System.Web.Security;

namespace CapaPresentacionAdmin.Controllers
{
    public class IngresoController : Controller
    {
        // GET: Ingreso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reestablecer()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string email, string pass) 
        {
            ClienteNegocio accesoDB = new ClienteNegocio();

            //listar y filtrar el usuario correspondiente
            Cliente usuario = accesoDB.ListarClientes().Where(user => user.Email == email && user.Password == pass).FirstOrDefault();

            if(usuario == null)
                usuario = accesoDB.ListarClientes(false).Where(user => user.Email == email && user.Password == pass).FirstOrDefault();

            if (usuario == null)
            {
                ViewBag.Error = "Correo o contraseña no correcta";
                return View();
            }
            else
            {
                if(!usuario.Activo)
                {
                    ViewBag.Error = "Cuenta Inactiva";
                    return View();
                }
                ViewBag.Error = null;

                Session.Add("Usuario", usuario);
                Session.Add("nombreUsuario", email);

                if(usuario.Admin)
                    return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("Index", "Tienda");
            }
        }

        [HttpPost]
        public ActionResult Reestablecer(string email)
        {
            ClienteNegocio accesoDB = new ClienteNegocio();

            //listar y filtrar el usuario correspondiente
            Cliente usuario = accesoDB.ListarClientes().Where(user => user.Email == email).FirstOrDefault();

            if (usuario == null)
            {
                ViewBag.Error = "No existe una cuenta asociada a ese correo";
                return View();
            }
            else
            {
                ViewBag.Error = null;
                string newPass = "test456";
                string mensaje = "Su nueva contraseña es " + newPass + ".Se recomienda que la cambie al ingresar";
               
                accesoDB.CambiarPassword(usuario.IdCliente, newPass);

                //HelperRegistro.enviarMail(email, "Recuperar contraseña", mensaje);

                return RedirectToAction("Index", "Ingreso");
            }
        }

        public ActionResult CerrarSesion()
        {

            Session.Remove("Usuario");
            return RedirectToAction("Index", "Ingreso");

        }
    }
}