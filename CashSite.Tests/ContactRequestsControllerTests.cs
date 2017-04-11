using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashSite.Data.Dal;
using System.Collections.Generic;
using CashSite.Tests.RepoMocks;
using CashSite.Controllers;
using CashSite.Data.Interfaces;
using System.Web.Routing;
using System.Web;
using System.Web.Mvc;

namespace CashSite.Tests
{
    [TestClass]
    public class ContactRequestsControllerTests
    {
        private ContactController ContactController { get; set; }
        private int Identifier { get; set; }

        public ContactRequestsControllerTests()
        {
            RepositoryBase.ContextDictionaryGetter = (() => {
                return new Dictionary<string, object>();
            });

            RepositoryBase.RepositoryInitializer = ((T) => {
                if (T == typeof(IContactRequestsRepository))
                    return new ContactRequestsRepo();

                throw new ArgumentException($"No initializer found for {T.ToString()}. You must add an initializer for this repository when the application starts.");
            });

            ContactController = new ContactController();

            Identifier = 0;
        }
        
        [TestMethod]
        public void TestMockRepoActuallyWorks()
        {
            var request = ContactController.ContactRequestsRepository.GetRequest(1);

            Assert.AreEqual("TestRepo", request.FirstName);
        }

        [TestMethod]
        public void TestIndexPost_ValidInput()
        {

            var viewResult = ContactController.Index(new Viewmodels.ContactFormViewModel
            {
                FirstName = "Test",
                LastName = "User",
                Email = "test.user@gmail.com",
                Subject = "Subject",
                Message = "Message"
            });

            //var model = viewResult.Model as Viewmodels.ContactFormViewModel;

            //Assert.IsTrue(model.RequestSent);
        }

        [TestMethod]
        public void TestIndexPost_InValidInput()
        {
            var viewResult = ContactController.Index(new Viewmodels.ContactFormViewModel
            {
                FirstName = null,
                LastName = "User",
                Email = null,
                Subject = "Subject",
                Message = "Message"
            });
            
            Assert.IsFalse(ContactController.ModelState.IsValid);
        }
    }
}
