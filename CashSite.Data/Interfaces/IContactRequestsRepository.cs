using CashSite.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSite.Data.Interfaces
{
    public interface IContactRequestsRepository : IRepositoryBase
    {
        ContactRequest AddRequest(ContactRequest contactRequest);

        void RemoveRequest(ContactRequest contactRequest);

        ContactRequest GetRequest(int contactRequestId);
    }
}
