
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomEm.Core.Mappings
{
    public class NewsMap : EntityTypeConfiguration<News>
    {
        public NewsMap()
        {
            HasKey(x => x.id);
            Property(x => x.id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.title);
            Property(x => x.text);
            Property(x => x.img);
            Property(x => x.url);
            HasRequired(x => x.source);
            ToTable("NewsSet");
        }
    }
    public class SourceMap : EntityTypeConfiguration<NewsSource>
    {
        public SourceMap(){
            HasKey(x => x.id);
            Property(x => x.id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasMany(x => x.NewsSet);
            ToTable("NewSource");
        }
    }
}
