using ORM;
using Repository.DTO;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class UsersKnowledgeRepository : IUsersKnowledgeRepository
    {
        private readonly DbContext context;

        public UsersKnowledgeRepository(DbContext uow)
        {
            this.context = uow;
        }
        public IEnumerable<UsersKnowledgeDal> GetAll()
        {
            return context.Set<UsersKnowledge>().Select(x => new UsersKnowledgeDal()
            {
                Degree = x.Degree,
                Description = x.Description,
                Id = x.UsersKnowledgeId,
                KnowledgeId = x.KnowledgeId,
                UserId = x.UserId
                
            });
        }

        public UsersKnowledgeDal GetById(int id)
        {
            var temp = context.Set<UsersKnowledge>().FirstOrDefault(x => x.UsersKnowledgeId == id);
            return new UsersKnowledgeDal()
            {
                Degree = temp.Degree,
                Description = temp.Description,
                Id = temp.UsersKnowledgeId,
                KnowledgeId = temp.KnowledgeId,
                UserId = temp.UserId
            };

        }


        public void Create(UsersKnowledgeDal item)
        {
            var temp = new UsersKnowledge()
            {
                Degree = item.Degree,
                Description = item.Description,
                KnowledgeId = item.KnowledgeId,
                UserId = item.UserId,
                UsersKnowledgeId = item.Id

            };
            context.Set<UsersKnowledge>().Add(temp);
           
        }

        public void Update(UsersKnowledgeDal item)
        {
            var temp = new UsersKnowledge()
            {
                Degree = item.Degree,
                Description = item.Description,
                KnowledgeId = item.KnowledgeId,
                UserId = item.UserId,
                UsersKnowledgeId = item.Id
                
            };
            var local = context.Set<UsersKnowledge>()
                         .Local
                         .FirstOrDefault(f => f.UsersKnowledgeId == item.Id);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(temp).State = EntityState.Modified;
           
        }

        public void Delete(int id)
        {
            var temp = context.Set<UsersKnowledge>().Find(id);
            if (temp != null)
            {
                context.Set<UsersKnowledge>().Remove(temp);
            }
        }


        public UsersKnowledgeDal GetByPredicate(System.Linq.Expressions.Expression<Func<UsersKnowledgeDal, bool>> f)
        {
            throw new NotImplementedException();
        }
    }
}
