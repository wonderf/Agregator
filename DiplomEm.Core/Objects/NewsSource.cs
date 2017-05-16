using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomEm.Core
{
    public class NewsSource
    {
        public virtual int id
        { get; set; }
        public virtual String url
        { get; set; }
        public virtual List<News> NewsSet
        { get; set; }
    }
}
