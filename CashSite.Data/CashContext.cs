using CashSite.Data.Dal;
using CashSite.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSite.Data
{
    public class CashContext : DbContext
    {
        public DbSet<ContactRequest> ContactRequests { get; set; }

        public DbSet<UserInfo> Users { get; set; }

        public DbSet<ForumTopic> ForumTopics { get; set; }
        
        public DbSet<TopicMessage> TopicMessages { get; set; }

        public CashContext() : base("name=CashDb") { }
    }
}
