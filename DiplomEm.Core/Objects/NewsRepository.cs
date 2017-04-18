using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomEm.Core.Objects
{
    public class NewsRepository : INewsRepository
    {
        private readonly ISession _session;
        public NewsRepository(ISession session)
        {
            _session = session;
        }

        public void insertNews(List<News> n)
        {
            var table = _session.Query<News>().ToList();
            List<News> ins = new List<News>();
            ins.AddRange(n);
            foreach(var e in table)
            {
                ins.RemoveAll(x=>x.url==e.url&&x.title==e.title);
            }
            var tx =_session.BeginTransaction();
            for(int i = 0; i < ins.Count; i++)
            {
                _session.Save(ins[i]);
                if (i % 20==0)
                {
                    _session.Flush();
                    _session.Clear();
                }
            }
            _session.Flush();
            _session.Clear();
            tx.Commit();
        }

        public IList<News> NewsList()
        {
            return _session.Query<News>().ToList();
        }
    }
}
