using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;

namespace CapaPresentacionAdmin.Permisos
{
    public class PermisosRol : ActionFilterAttribute
    {
        private int idrol;


        public PermisosRol(int _idrol)
        {

            idrol = _idrol;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] != null)
            {

                Cliente usuario = HttpContext.Current.Session["Usuario"] as Cliente;

                int esAdmin = usuario.Admin ? 1 : 0;

                if (esAdmin != this.idrol)
                {
                    
                    filterContext.Result = new RedirectResult("~/Home/SinPermiso");

                }


            }
        }
    }
}