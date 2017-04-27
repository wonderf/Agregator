using Ninject.Modules;
using NHibernate;
using FluentNHibernate.Cfg;
using NHibernate.Cache;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using Ninject.Web.Common;
using System.Web.Configuration;

namespace DiplomEm.Core
{
    public class RepositoryModule : NinjectModule
    {
        
        public override void Load()
        {
            Bind<ISessionFactory>()
                .ToMethod
                (
                    e =>
                        Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(WebConfigurationManager.ConnectionStrings["storage"].ToString()))
                        .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<News>())
                        .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(false, true, false))
                        .BuildConfiguration()
                        .BuildSessionFactory()
                )
                .InSingletonScope();

            Bind<ISession>()
                .ToMethod((ctx) => ctx.Kernel.Get<ISessionFactory>().OpenSession())
                .InRequestScope();
        }
    }
}
//
