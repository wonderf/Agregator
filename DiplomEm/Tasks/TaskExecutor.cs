using EdgeJs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using DiplomEm.Core;
using System.Linq;
using DiplomEm.Core.Objects;

namespace DiplomEm
{
    public class TaskExecutor
    {
        #region private_members
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
        private INewsRepository rep;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion
        public TaskExecutor(INewsRepository Rep) { rep = Rep; }
        public void TaskExec(String js, String url)
        {
            js = js.Replace("return ", "var d=");
            String code = String.Format(template, url, js);
            var func = Edge.Func(code);
            String jsExecuter = func(@"USE THE FORCE").Result.ToString();
            model = JsonConvert.DeserializeObject<List<News>>(jsExecuter);
            rep.insertNews(model);
            logger.Info("execute task");
        }
        
    }
}