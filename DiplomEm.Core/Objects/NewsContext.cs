using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
namespace DiplomEm.Core
{
    public class NewsContext :DbContext
    {
        public NewsContext() : base(WebConfigurationManager.ConnectionStrings["storage"].ToString())
        {  }

        public DbSet<News> NewsSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
