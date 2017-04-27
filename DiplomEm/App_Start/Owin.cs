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
            String conn = WebConfigurationManager.ConnectionStrings["hangfire"].ToString();
                if (conn != null)
                    GlobalConfiguration.Configuration.UseSqlServerStorage(conn.ToString());
            GlobalConfiguration.Configuration.UseNinjectActivator(new Ninject.Web.Common.Bootstrapper().Kernel);
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
