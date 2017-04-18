using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(DiplomEm.App_Start.Owin))]

namespace DiplomEm.App_Start
{
    public class Owin
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=DESKTOP-LR1A8BU;Initial Catalog=hangflare;Integrated Security=True");
            GlobalConfiguration.Configuration.UseNinjectActivator(new Ninject.Web.Common.Bootstrapper().Kernel);
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
