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
    public class KnowledgeRepository : IKnowledgeRepository
    {
        private readonly DbContext context;

        public KnowledgeRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<KnowledgeDal> GetAll()
        {
            return context.Set<Knowledge>().Select(knowl => new KnowledgeDal()
            {
                Id = knowl.KnowledgeId,
                Name = knowl.Name
            });
        }

        public KnowledgeDal GetById(int id)
        {
            var temp = context.Set<Knowledge>().FirstOrDefault(x => x.KnowledgeId == id);
            return new KnowledgeDal()
            {
                Id = temp.KnowledgeId,
                Name = temp.Name
            };
        }


        public void Create(KnowledgeDal item)
        {

            var temp = new Knowledge()
            {
                KnowledgeId = item.Id,
                Name = item.Name
            };
            context.Set<Knowledge>().Add(temp);
            //context.SaveChanges();
        }

        public void Update(KnowledgeDal item)
        {
            var itemForUpdate = new Knowledge()
            {
                 KnowledgeId=item.Id,
                 Name=item.Name

            };

            var local = context.Set<Knowledge>()
                                .Local
                                .FirstOrDefault(f => f.KnowledgeId == item.Id);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(itemForUpdate).State = EntityState.Modified;

        }

        public void Delete(int id)
        {
            var local = context.Set<Knowledge>().FirstOrDefault(f => f.KnowledgeId == id);
            if (local != null)
            {
                context.Set<Knowledge>().Remove(local);
            }
            
        }


        public KnowledgeDal GetByPredicate(System.Linq.Expressions.Expression<Func<KnowledgeDal, bool>> f)
        {
            throw new NotImplementedException();
        }
    }
}
