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
  class KnowledgeRepository : IRepository<Knowledge>
  {
        private Context db;

        public KnowledgeRepository(Context context)
        {
            this.db = context;
        }

    public IEnumerable<Knowledge> GetAll()
    {
      return db.Knowledges;
    }

    public Knowledge GetById(int id)
    {
      return db.Knowledges.FirstOrDefault(x => x.KnowledgeId == id);       
    }

    public IEnumerable<Knowledge> Find(Func<Knowledge, bool> predicate)
    {
      return db.Knowledges.Where(predicate).ToList();
 
    }

    public void Create(Knowledge item)
    {

      db.Knowledges.Add(item);
    }

    public void Update(Knowledge item)
    {
      db.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      var item = db.Knowledges.Find(id);
      if (item != null)
        db.Knowledges.Remove(item);
    }
  }
}
