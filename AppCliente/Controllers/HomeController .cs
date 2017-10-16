using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCliente.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.UserWebAPI = System.Configuration.ConfigurationManager.AppSettings["UserWebAPI"];
            ViewBag.PwdWebAPI = System.Configuration.ConfigurationManager.AppSettings["PwdWebAPI"];
            return View();
        }

    }
}