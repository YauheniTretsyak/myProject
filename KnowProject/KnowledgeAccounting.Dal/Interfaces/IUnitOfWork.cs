using KnowledgeAccounting.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccounting.Dal.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    IRepository<Role> Roles { get; }
    IRepository<User> Users { get; }
    IRepository<Knowledge> Knowledges { get; }
    IRepository<UsersKnowledge> UsersKnowledges { get; }
    void Save();
  }
}
