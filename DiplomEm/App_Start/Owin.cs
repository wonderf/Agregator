using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using System.Web.Configuration;

[assembly: OwinStartup(typeof(DiplomEm.App_Start.Owin))]

namespace DiplomEm.App_Start
{
    public class Owin
    {
        public void Configuration(IAppBuilder app)
        {
            //GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=DESKTOP-LR1A8BU;Initial Catalog=hangflare;Integrated Security=True");

            String conn = WebConfigurationManager.ConnectionStrings["hangfire"].ToString();
                if (conn != null)
                    GlobalConfiguration.Configuration.UseSqlServerStorage(conn.ToString());
                    //todo make db in memory
            GlobalConfiguration.Configuration.UseNinjectActivator(new Ninject.Web.Common.Bootstrapper().Kernel);
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
