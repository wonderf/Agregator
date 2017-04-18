using DiplomEm.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomEm.Controllers
{
    public class ResultController : Controller
    {
        private INewsRepository rep;
       public ResultController(INewsRepository Rep)
        {
            rep = Rep;
        }
        // GET: Result
        public ActionResult Index()
        {
            var set = rep.NewsList().ToList();
            return View(set);
        }
    }
}