﻿using KnowledgeAccounting.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccounting.Bll.DTO
{
  public class UserDTO
  {
      public int UserId { get; set; }
      public string Email { get; set; }
      public byte[] Photo { get; set; }
      public string Name { get; set; }
      public string Password { get; set; }
      public int RoleId { get; set; }

  }
}
