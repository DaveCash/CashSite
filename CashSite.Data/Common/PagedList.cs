using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSite.Data.Common
{
    public class PagedList<T>
    {
        public List<T> Results { get; private set; }

        public int TotalResults { get; private set; }

        public PagedList(IQueryable<T> query, int skip, int take){
            TotalResults = query.Count();
            Results = query.ToList();    
        }
    }
}
