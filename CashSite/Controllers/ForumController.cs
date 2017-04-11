using CashSite.Data.Model;
using CashSite.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashSite.Controllers
{
    [Authorize]
    public class ForumController : BaseController
    {
        // GET: Forum
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TopicViewModel model)
        {
            var newTopic = new ForumTopic();

            if (!ModelState.IsValid || !TryUpdateModel(newTopic))
                return View(model);

            ForumRepository.SaveTopic(newTopic);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int topicId)
        {
            return View();
        }

        public ActionResult View(int topicId)
        {
            return View();
        }
    }
}