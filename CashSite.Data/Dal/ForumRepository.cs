using CashSite.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashSite.Data.Model;
using CashSite.Data.Common;

namespace CashSite.Data.Dal
{
    public class ForumRepository : RepositoryBase, IForumRepository
    {
        public ForumTopic GetTopic(int id)
        {
            return Db.ForumTopics.FirstOrDefault(t => t.TopicId == id);
        }

        public PagedList<ForumTopic> GetTopicsByCreator(Guid userId, int page, int pageSize)
        {
            var q = Db.ForumTopics
                .Where(t => t.CreatedBy == userId);

            return new PagedList<ForumTopic>(q, page, pageSize);
        }

        public PagedList<ForumTopic> GetTopics(int page, int pageSize)
        {
            return new PagedList<ForumTopic>(Db.ForumTopics, page, pageSize);
        }

        public ForumTopic SaveTopic(ForumTopic topic)
        {
            if (topic.TopicId <= 0)
                Db.ForumTopics.Add(topic);

            return topic;
        }

        public void DeleteTopic(ForumTopic topic)
        {
            Db.ForumTopics.Remove(topic);
            Db.SaveChanges();
        }

    }
}
