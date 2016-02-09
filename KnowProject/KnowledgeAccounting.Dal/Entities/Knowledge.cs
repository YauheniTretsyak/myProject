using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccounting.Dal.Entities
{
  public class Knowledge
  {
      [Key]
      public int KnowledgeId { get; set; }
      public string Name { get; set; }
      public virtual ICollection<UsersKnowledge> UserKnowledge { get; set; } 
  }
}
