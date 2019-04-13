using MySql.Data.MySqlClient;
using NominaDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NominaWeb.Controllers
{
    public class BaseController : Controller
    {
        public String conection = @"Server=mysqlservernominadb.mysql.database.azure.com; Port=3306; Database=nominadatabase; uid=root1@mysqlservernominadb; password=AdminRoot80; SslMode=Preferred;";
        public MySqlConnection connection;
        public NominaDBEntities db;

        public BaseController()
        {
             connection = new MySqlConnection(conection);
             db = new NominaDBEntities(connection, false);
        }

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