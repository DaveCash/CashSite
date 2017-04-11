using CashSite.Data;
using CashSite.Data.Dal;
using CashSite.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CashSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RepositoryBase.ContextDictionaryGetter = (() => {
                if (HttpContext.Current.Items != null)
                    return HttpContext.Current.Items;

                return new Dictionary<string, object>();
            });

            RepositoryBase.RepositoryInitializer = ((T) => {
                if (T == typeof(IContactRequestsRepository))
                    return new ContactRequestsRepository();
                if (T == typeof(IUsersRepository))
                    return new UsersRepository();
                if (T == typeof(IForumRepository))
                    return new ForumRepository();
                
                throw new ArgumentException($"No initializer found for {T.ToString()}. You must add an initializer for this repository when the application starts.");
            });

            Database.SetInitializer<CashContext>(null);
        }
    }
}
