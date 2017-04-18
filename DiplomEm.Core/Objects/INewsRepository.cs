using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomEm.Core.Objects
{
    public interface INewsRepository
    {
        IList<News> NewsList();
        void insertNews(List<News> n);
    }
}
