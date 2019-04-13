using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NominaWeb.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserLogged"] == null || Convert.ToBoolean(Session["UserLogged"]) == false)
            {
                filterContext.Result = new RedirectResult(Url.Action("Login", "Account", new { returnUrl = "/Home/Index" }));
                ViewBag.NoLogeado = "No tiene permisos para acceder a esta función.";
            }
            else
            {
                // Call the base
                base.OnActionExecuting(filterContext);
            }
        }
    }
}