using KnowledgeAccounting.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccounting.Bll.DTO
{
  public class UserKnowledgeDTO
  {
      public int UsersKnowledgeId { get; set; }
      public int Degree { get; set; }
      public string Description { get; set; }

      public int UserId { get; set; }

      public int KnowledgeId { get; set; }
    
  }
}
