using CashSite.Data.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSite.Data.Dal
{
    public class RepositoryBase : IRepositoryBase
    {
        public static Func<IDictionary> ContextDictionaryGetter { private get; set; }
        
        public static Func<Type, IRepositoryBase> RepositoryInitializer { private get; set; }

        public static T GetRepository<T>() where T : IRepositoryBase
        {
            var contextDictionary = ContextDictionaryGetter();

            var repositoryKey = "Repo_" + typeof(T).ToString();

            if (!contextDictionary.Contains(repositoryKey))
                contextDictionary[repositoryKey] = RepositoryInitializer(typeof(T));

            return (T) contextDictionary[repositoryKey];
        }

        protected CashContext Db {
            get
            {
                var contextDictionary = ContextDictionaryGetter();

                var cashContextKey = "Db_" + typeof(CashContext).ToString();
                
                if (!contextDictionary.Contains(cashContextKey))
                    contextDictionary[cashContextKey] = new CashContext();

                return contextDictionary[cashContextKey] as CashContext;
            }
        } 
    }
}
