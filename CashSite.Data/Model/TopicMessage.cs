using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSite.Data.Model
{
    [Table("Forum_Messages")]
    public class TopicMessage
    {
        [Key]
        public int MessageId { get; set; }

        public string Message { get; set; }

        public int TopicId { get; set; }

        public Guid CreatedBy { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        [ForeignKey("TopicId")]
        public virtual ForumTopic Topic { get; set; }
    }
}
