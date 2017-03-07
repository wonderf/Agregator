using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DiplomEm
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            logger.Info("Application Start");
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
