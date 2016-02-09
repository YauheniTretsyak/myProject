using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccounting.Dal.Entities
{
  public class Role
  {
      [Key]
      public int RoleId { get; set; }
      public string Name { get; set; }
      public virtual ICollection<User> Users { get; set; } 
  }
}
