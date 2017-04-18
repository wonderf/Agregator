using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomEm.Core.Mappings
{
    class NewsMap : ClassMap<News>
    {
        public NewsMap()
        {
            Table("NewsSet");
            Id(x => x.id).GeneratedBy.Identity();
            Map(x => x.title);
            Map(x => x.text);
            Map(x => x.img);
            Map(x => x.url);
        
        }
    }
}
