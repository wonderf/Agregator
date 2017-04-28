using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomEm.Core.Objects
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsContext _context;
        public NewsRepository(NewsContext context)
        {
            _context=context;
        }

        public void insertNews(List<News> n)
        {
            var table = NewsList();
            List<News> ins = new List<News>();
            ins.AddRange(n);
            foreach(var e in table)
            {
                ins.RemoveAll(x=>x.url==e.url&&x.title==e.title);
            }
            var tr = _context.Database.BeginTransaction();
            try
            {
                for (int i = 0; i < ins.Count; i++)
                {
                    _context.NewsSet.Add(ins[i]);
                }
                _context.SaveChanges();
                tr.Commit();
            }
            catch(Exception e)
            {
                tr.Rollback();
            }
        }

        public IList<News> NewsList()
        {
            return _context.NewsSet.ToList();
        }
    }
}
