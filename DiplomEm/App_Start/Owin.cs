using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.PostgreSql;

[assembly: OwinStartup(typeof(DiplomEm.App_Start.Owin))]

namespace DiplomEm.App_Start
{
    public class Owin
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=DESKTOP-LR1A8BU;Initial Catalog=hangflare;Integrated Security=True");//find string for postgres
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
