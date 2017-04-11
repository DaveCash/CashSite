using CashSite.Data.Dal;
using CashSite.Data.Model;
using CashSite.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashSite.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ViewResult Index()
        {
            var x = ContactRequestsRepository.GetRequest(1);

            return View();
        }

        [HttpPost]
        public ViewResult Index(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var newRequest = new ContactRequest();

            if(!TryUpdateModel<ContactRequest>(newRequest))
                return View(model);

            newRequest.CreatedOn = DateTime.Now;

            ContactRequestsRepository.AddRequest(newRequest);
            
            model.RequestSent = true;

            return View(model);
        }
    }
}