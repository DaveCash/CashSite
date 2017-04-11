using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSite.Data.Model
{
    [Table("Forum_Topics")]
    public class ForumTopic
    {
        [Key]
        public int TopicId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CreatedBy { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
