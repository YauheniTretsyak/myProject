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
  public class UsersKnowledgeRepository : IRepository<UsersKnowledge>
  {
     private Context db;

     public UsersKnowledgeRepository(Context context)
        {
            this.db = context;
        }
    public IEnumerable<UsersKnowledge> GetAll()
    {
      return db.UsersKnowledges.Include(x => x.Knowledge);
    }

    public UsersKnowledge GetById(int id)
    {
      return db.UsersKnowledges.FirstOrDefault(x => x.UsersKnowledgeId == id);

    }

    public IEnumerable<UsersKnowledge> Find(Func<UsersKnowledge, bool> predicate)
    {
      return db.UsersKnowledges.Where(predicate).ToList();
    }

    public void Create(UsersKnowledge item)
    {

      db.UsersKnowledges.Add(item);
    }

    public void Update(UsersKnowledge item)
    {
      db.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      var item = db.UsersKnowledges.Find(id);
      if (item != null)
        db.UsersKnowledges.Remove(item);
    }
  }
}
