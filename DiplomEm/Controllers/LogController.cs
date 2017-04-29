using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace DiplomEm.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index()
        {
            String log="";
            string appDataPath = System.Web.HttpContext.Current.Server.MapPath(@"~/");
            string fileName = "log.txt";
            string absolutePathToFile = Path.Combine(appDataPath, fileName);
            try
            {
                log=System.IO.File.ReadAllText(absolutePathToFile);
            }
            catch(Exception ignore)
            {}
            String[] separotrs = log.Split(new char[] { '\r', '\n' });
            log = String.Empty;
            for(int i = separotrs.Length-1; i > 0; i--)
            {
                if (separotrs[i] != "")
                {
                    log += separotrs[i];
                }
            }
            ViewBag.log = log;
            return View();
        }
    }
}