using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using DiplomEm.Core;
using DiplomEm.Core.Objects;
using Hangfire;
using System.Web.Configuration;
using System.Data.Entity;

namespace DiplomEm
{
    public class MvcApplication : NinjectHttpApplication
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(new RepositoryModule());
            kernel.Bind<INewsRepository>().To<NewsRepository>();
            return kernel;
        }
        protected override void OnApplicationStarted()
        {
            logger.Info("Application Start");
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            base.OnApplicationStarted();
        }
    }
}
