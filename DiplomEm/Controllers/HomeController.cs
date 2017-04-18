
using EdgeJs;
using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using DiplomEm.Core;
using System.IO;
using DiplomEm.Core.Objects;

namespace DiplomEm.Controllers
{
    public class HomeController : Controller
    {
        #region private_member
        INewsRepository rep;
        private String template = "var jsdom = require('jsdom');\n" +
                "var deferred = require('deferred')\n" +
                "\n" +
                "extract=function () {{\n" +
                "var def = deferred();\n" +
                "jsdom.env({{\n" +
                "  url: '{0}',\n" +
                "  scripts: ['http://code.jquery.com/jquery.js'],\n" +
                "  done: function (err, window) {{\n" +
                "    var $ = window.$;\n" +
                "{1}\n" +
                "            def.resolve(d);\n" +
                "  }}\n" +
                "  \n" +
                "}})\n" +
                "\treturn def.promise;\n" +
                "}};\n" +
                "\n" +
                "return function (data, callback) {{\n" +
                "extract().done(function (result){{callback(null,result);}});\n" +
                "}}";
        List<News> model = new List<News>();
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion
        public HomeController(INewsRepository Rep)
        {
            rep = Rep;
        }
        public ActionResult Index()
        {

            ViewBag.News = model;
            return View();
        }

        public PartialViewResult GetUrlPage(string url)
        {
            String answer = String.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                try {
                    WebClient wc = new WebClient();
                    answer = wc.DownloadString(url);
                }
                catch(Exception e)
                {
                    logger.Error(e);
                }
            }
            Session["url"] = url;
            ViewData["url"] = answer;
            return PartialView();
        }
        public ActionResult CreateTask(int time)
        {
            if (time < 1)
            {
                BackgroundJob.Enqueue(() => logger.Info("Hello, world!"));
            }
            else
            {
                RecurringJob.AddOrUpdate<TaskExecutor>(x=>x.TaskExec(Session["code"].ToString(),Session["url"].ToString()), Cron.MinuteInterval(time));
                logger.Info("Add new task");
            }
            return PartialView();
        }
        
        public ActionResult GetJsonResult(string js)
        {
            String answer = String.Empty;
            if (!string.IsNullOrEmpty(js))
            {
                try
                {
                    String url = Session["url"].ToString();
                    js = js.Replace("return ", "var d=");
                    String code = String.Format(template, url,js);
                    var func = Edge.Func(code);
                    String jsExecuter = func(@"USE THE FORCE").Result.ToString();
                    model = JsonConvert.DeserializeObject<List<News>>(jsExecuter);
                    Session["code"] = js;
                }
                catch (Exception e)
                {
                    logger.Error(e);
                }
            }
            ViewBag.News = model;
            return PartialView();
        }
        
    }
    
}