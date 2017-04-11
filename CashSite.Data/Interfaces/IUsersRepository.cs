using CashSite.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSite.Data.Interfaces
{
    public interface IUsersRepository : IRepositoryBase
    {
        UserInfo GetUser(string email);
        UserInfo GetUser(Guid userId);
        UserInfo AddUser(UserInfo user);
        void RemoveUser(UserInfo user);
    }
}
