using CashSite.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CashSite.Data.Dal;
using CashSite.Data.Model;
using CashSite.Data;
using CashSite.Code;

namespace CashSite.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormViewModel model)
        {
            if (MembershipService.ValidateUser(model.Email, model.Password))
            {
                var user = UsersRepository.GetUser(model.Email);

                FormsAuthentication.SetAuthCookie(user.UserId.ToString(), false);
            }

            var returnUrl = Request.QueryString["ReturnUrl"].ToString();

            return Redirect(returnUrl);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (UsersRepository.GetUser(model.Email) != null)
            {
                ModelState.AddModelError("EmailInUser", "Email address is already in user");
                return View(model);
            }

            MembershipService.CreateUser(new UserInfo
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            }, model.Password);

            return View(model);
        }
    }
}