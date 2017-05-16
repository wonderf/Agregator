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

        public void insertNews(List<News> n,String sourceUrl)
        {
            var table = NewsList(sourceUrl);
            List<News> ins = new List<News>();
            ins.AddRange(n);
            if (table != null)
            {
                foreach (var e in table)
                {
                    ins.RemoveAll(x => x.title == e.title);
                }
            }
            else
            {
                insertUrl(sourceUrl);
            }
            NewsSource source = _context.SourceSet.Where(s => s.url == sourceUrl).FirstOrDefault();
            ins.ForEach(s => s.source = source);
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

        public IList<News> NewsList(String sourceUrl)
        {
            return _context.SourceSet.Where(s => s.url == sourceUrl).FirstOrDefault() != null ?
                _context.NewsSet.Where(s => s.source.url == sourceUrl).ToList() :null;
        }
        public void insertUrl(String url)
        {
                _context.SourceSet.Add(new NewsSource()
                {
                    url = url
                });
                _context.SaveChanges();
            
            
        }
    }
}
