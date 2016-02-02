using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Knowledge
    {
        [Key]
        public int KnowledgeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UsersKnowledge> UserKnowledge { get; set; }
    }
}
