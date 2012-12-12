using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OC_Caf_Menu.Models;

namespace OC_Caf_Menu.Controllers
{
    public class HomeController : Controller
    {
        private Cafeteria c = new Cafeteria();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            try
            {
                ViewBag.MealsException = 0;
                c.ParseByXMLDocument();
            }
            catch (System.Xml.XmlException)
            {
                ViewBag.MealsException = 0;
            }
            return View(c);
        }

    }
}
