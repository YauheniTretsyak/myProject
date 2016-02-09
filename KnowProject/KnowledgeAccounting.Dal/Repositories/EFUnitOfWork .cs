using KnowledgeAccounting.Dal.EF;
using KnowledgeAccounting.Dal.Interfaces;
using KnowledgeAccounting.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccounting.Dal.Repositories
{
  public class EFUnitOfWork : IUnitOfWork
  {
    private Context db;
    private KnowledgeRepository knowledgeRepository;
    private RoleRepository roleRepository;
    private UserRepository userRepository;
    private UsersKnowledgeRepository usersKnowledgeRepository;

    public EFUnitOfWork(string connectionString)
    {
      db = new Context(connectionString);
    }

    public IRepository<Entities.Role> Roles
    {
      get
      {
        if (roleRepository == null)
          roleRepository = new RoleRepository(db);
        return roleRepository;
      } 
    }

    public IRepository<Entities.User> Users
    {
      get
      {
        if (userRepository == null)
          userRepository = new UserRepository(db);
        return userRepository;
      }
    }

    public IRepository<Entities.Knowledge> Knowledges
    {
      get
      {
        if (knowledgeRepository == null)
          knowledgeRepository = new KnowledgeRepository(db);
        return knowledgeRepository;
      }
    }

    public IRepository<Entities.UsersKnowledge> UsersKnowledges
    {
      get
      {
        if (usersKnowledgeRepository == null)
          usersKnowledgeRepository = new UsersKnowledgeRepository(db);
        return usersKnowledgeRepository;
      }
    }

    public void Save()
    {
      if (db != null)
      {
        db.SaveChanges();
      }
      
    }
    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          db.Dispose();
        }
        this.disposed = true;
      }
    }
 
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
