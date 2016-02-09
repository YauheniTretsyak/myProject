using KnowledgeAccounting.Dal.EF;
using KnowledgeAccounting.Dal.Entities;
using KnowledgeAccounting.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccounting.Dal.Repositories
{
  public class RoleRepository:IRepository<Role>
  {
        private Context db;

        public RoleRepository(Context context)
        {
            this.db = context;
        }
    public IEnumerable<Role> GetAll()
    {
      return db.Roles;
    }

    public Role GetById(int id)
    {
      return db.Roles.FirstOrDefault(x => x.RoleId == id);    
    }

    public IEnumerable<Role> Find(Func<Role, bool> predicate)
    {
      return db.Roles.Where(predicate).ToList();
    }

    public void Create(Role item)
    {
      db.Roles.Add(item);
    }

    public void Update(Role item)
    {
      db.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      var item = db.Roles.Find(id);
      if (item != null)
        db.Roles.Remove(item);
    }
  }
}
