using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElementsPlugin.Models;

namespace ElementsPlugin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult UserInterface()
        {
            return View();
        }

        public ActionResult Tables()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }
    }
}