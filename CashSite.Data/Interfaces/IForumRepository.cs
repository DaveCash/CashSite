using CashSite.Data.Common;
using CashSite.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSite.Data.Interfaces
{
    public interface IForumRepository : IRepositoryBase
    {
        ForumTopic GetTopic(int id);
        PagedList<ForumTopic> GetTopicsByCreator(Guid userId, int page, int pageSize);
        PagedList<ForumTopic> GetTopics(int page, int pageSize);
        ForumTopic SaveTopic(ForumTopic topic);
        void DeleteTopic(ForumTopic topic);
    }
}
