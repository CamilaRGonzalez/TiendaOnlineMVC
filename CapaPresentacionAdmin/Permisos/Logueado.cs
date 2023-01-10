using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;

namespace CapaPresentacionAdmin.Permisos
{
    public class Logueado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] == null)                     
                filterContext.Result = new RedirectResult("~/Ingreso/Index");
       
        }
    }
}