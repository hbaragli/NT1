using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestorRecursosHumanos.Controllers
{
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Gestor de Recursos Humanos.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página diseñada por Sebastián Reh y Hector Baragli para ORT Belgrano";

            return View();
        }
    }
}