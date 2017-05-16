using Ninject.Modules;

using Ninject;
using Ninject.Web.Common;
using System.Web.Configuration;

namespace DiplomEm.Core
{
    public class RepositoryModule : NinjectModule
    {
        
        public override void Load()
        {
            Bind<NewsContext>().ToSelf().InRequestScope();
        }
    }
}