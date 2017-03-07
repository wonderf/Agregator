using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomEm.Controllers
{
    public class HomeController : Controller
    {
        //partial view?
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //return view with page??
        [HttpPost]
        public ActionResult Update()
        {
            return View();
        }
    }
}