using CashSite.Data;
using CashSite.Data.Dal;
using CashSite.Data.Interfaces;
using CashSite.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

namespace CashSite.Code
{
    // Creae a full memberhsip provider later. This'll do for now
    public class MembershipService
    {
        public enum UserValidateStatus
        {
            Valid,
            InvalidPassword,
            EmailExists,
        }
        
        private static UsersRepository _UsersRepository { get; set; }

        private static UsersRepository UsersRepository {
            get
            {
                if (_UsersRepository == null)
                    _UsersRepository = new UsersRepository();

                return _UsersRepository;
            }
        }

        public static UserInfo CreateUser(UserInfo user, string password)
        {
            var membershipUser = Membership.CreateUser(GenerateUsername(user), password, user.Email);

            user.UserId = (Guid) membershipUser.ProviderUserKey;

            return UsersRepository.AddUser(user);
        }

        public static void DeleteUser(UserInfo user)
        {
            var membershipUser = Membership.GetUser(user.UserId);
            UsersRepository.RemoveUser(user);

            Membership.DeleteUser(membershipUser.UserName);
        }

        public static bool ValidateUser(string email, string password)
        {
            var user = UsersRepository.GetUser(email);
            var membershipUser = Membership.GetUser(user.UserId);

            return Membership.ValidateUser(membershipUser.UserName, password);
        }

        private static string GenerateUsername(UserInfo user)
        {
            return user.FirstName + user.LastName + "_" + Guid.NewGuid();
        }
    }
}