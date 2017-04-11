using CashSite.Data;
using CashSite.Data.Dal;
using CashSite.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashSite.Controllers
{
    public class BaseController : Controller
    {
        public IUsersRepository UsersRepository
        {
            get { return RepositoryBase.GetRepository<IUsersRepository>(); }
        }

        public IContactRequestsRepository ContactRequestsRepository
        {
            get { return RepositoryBase.GetRepository<IContactRequestsRepository>(); }
        }

        public IForumRepository ForumRepository
        {
            get { return RepositoryBase.GetRepository<IForumRepository>(); }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.Action = ControllerContext.RouteData.Values["action"].ToString();
            ViewBag.Controller = ControllerContext.RouteData.Values["controller"].ToString();
        }
    }
}