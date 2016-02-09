using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccounting.Dal.Entities
{
  public class User
  {
      [Key]
      public int UserId { get; set; }

      public string Name { get; set; }

      public string Password { get; set; }

      public string Email { get; set; }
      public int RoleId { get; set; }
      public virtual Role Role { get; set; }
      public byte[] Photo { get; set; }
      public virtual ICollection<UsersKnowledge> UserKnowledge { get; set; }
  }
}
