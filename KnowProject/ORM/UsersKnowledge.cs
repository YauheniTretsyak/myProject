using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
   public class UsersKnowledge
   {
       [Key]
        public int UsersKnowledgeId { get; set; }

        public int Degree { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int KnowledgeId { get; set; }
        public Knowledge Knowledge { get; set; }
    }
}
