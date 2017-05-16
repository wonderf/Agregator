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
        IList<News> NewsList(String sourceUrl);
        void insertNews(List<News> n, String sourceUrl);
        void insertUrl(String url);
    }
}
