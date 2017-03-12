using EdgeJs;
using System;
using System.Net;
using System.Web.Mvc;


namespace DiplomEm.Controllers
{
    public class HomeController : Controller
    {

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetUrlPage(string url)
        {
            String answer = String.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                try {
                    WebClient wc = new WebClient();
                    wc.Encoding = System.Text.Encoding.UTF8;
                    answer = wc.DownloadString(url);
                }
                catch(Exception e)
                {
                    logger.Error(e);
                }
            }
            ViewData["url"] = answer;
            return PartialView();
        }
        public ActionResult GetJsonResult(string code)
        {
            String answer = String.Empty;
            if (!string.IsNullOrEmpty(code))
            {
                try
                {
                    var func = Edge.Func(@"
                            return function (data, callback) {
                                callback(null, 'Node.js welcomes ' + data);
                             }");
                }
                catch (Exception e)
                {
                    logger.Error(e);
                }
            }
            ViewData["json"] = answer;
            return PartialView();
        }
        
    }
}