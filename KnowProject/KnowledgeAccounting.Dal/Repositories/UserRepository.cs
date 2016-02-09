using KnowledgeAccounting.Dal.EF;
using KnowledgeAccounting.Dal.Entities;
using KnowledgeAccounting.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccounting.Dal.Repository

{
  public class UserRepository : IRepository<User>
  {
        private Context db;

        public UserRepository(Context context)
        {
            this.db = context;
        }
    public IEnumerable<User> GetAll()
    {
      return db.Users;
    }

    public User GetById(int id)
    {
      return db.Users.FirstOrDefault(user => user.UserId == id);
    }

    public IEnumerable<User> Find(Func<User, Boolean> predicate)
    {
      return db.Users.Where(predicate).ToList();
    }

    public void Create(User item)
    {
      db.Users.Add(item);        
    }

    public void Update(User item)
    {
      db.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      var user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
    }
  }
}
