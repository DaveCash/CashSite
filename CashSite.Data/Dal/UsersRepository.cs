using CashSite.Data.Interfaces;
using CashSite.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSite.Data.Dal
{
    public class UsersRepository : RepositoryBase, IUsersRepository
    {
        public UserInfo GetUser(Guid userId)
        {
            return Db.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public UserInfo GetUser(string email)
        {
            return Db.Users.FirstOrDefault(u => u.Email == email);
        }

        public UserInfo AddUser(UserInfo user)
        {
            Db.Users.Add(user);
            Db.SaveChanges();

            return user;
        }

        public void RemoveUser(UserInfo user)
        {
            Db.Users.Remove(user);
            Db.SaveChanges();
        }
    }
}
