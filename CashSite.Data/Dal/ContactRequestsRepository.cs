using CashSite.Data.Interfaces;
using CashSite.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSite.Data.Dal
{
    public class ContactRequestsRepository : RepositoryBase, IContactRequestsRepository
    {
        public ContactRequest GetRequest(int requestId)
        {
            return Db.ContactRequests.FirstOrDefault(r => r.Id == requestId);
        }

        public ContactRequest AddRequest(ContactRequest contactRequest)
        {
            Db.ContactRequests.Add(contactRequest);
            Db.SaveChanges();

            return contactRequest;
        }

        public void RemoveRequest(ContactRequest contactRequest)
        {
            Db.ContactRequests.Remove(contactRequest);
            Db.SaveChanges();
        }
    }
}
