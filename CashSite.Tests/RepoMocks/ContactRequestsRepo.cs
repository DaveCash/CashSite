using CashSite.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashSite.Data.Model;

namespace CashSite.Tests.RepoMocks
{
    internal class ContactRequestsRepo : IContactRequestsRepository, IRepositoryBase
    {
        internal List<ContactRequest> RequestStore { get; private set; }
        
        public ContactRequestsRepo()
        {
            RequestStore = new List<ContactRequest>();
        }

        public ContactRequest AddRequest(ContactRequest contactRequest)
        {
            RequestStore.Add(contactRequest);

            return contactRequest;
        }

        public ContactRequest GetRequest(int contactRequestId)
        {
            return new ContactRequest
            {
                Id = 1,
                FirstName = "TestRepo",
                LastName = "TestRepo",
                Email = "TestRepo@test.com",
                Subject = "This is a test repo contact request",
                Message = "This is the body!",
                CreatedOn = DateTime.Now
            };
        }

        public void RemoveRequest(ContactRequest contactRequest)
        {
            throw new ArgumentException();
        }
    }
}
