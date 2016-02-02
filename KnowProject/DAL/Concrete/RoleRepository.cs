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
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext uow)
        {
            this.context = uow;
        }
        public IEnumerable<RoleDal> GetAll()
        {
            return context.Set<Role>().Select(user => new RoleDal()
            {
                Id = user.RoleId,
                Name = user.Name
            });
        }

        public RoleDal GetById(int id)
        {
            var temp = context.Set<Role>().FirstOrDefault(x => x.RoleId == id);
            return new RoleDal()
            {
                Id = temp.RoleId,
                Name = temp.Name
            };
        }


        public void Create(RoleDal item)
        {
            var temp = new Role()
            {
                Name = item.Name,
                RoleId = item.Id
            };
            context.Set<Role>().Add(temp);
            
        }

        public void Update(RoleDal item)
        {
            var temp = new Role()
            {
                Name = item.Name,
                RoleId = item.Id
            };

            var local = context.Set<Role>()
                         .Local
                         .FirstOrDefault(f => f.RoleId == item.Id);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(temp).State = EntityState.Modified;
            

            
        }

        public void Delete(int id)
        {

            var local = context.Set<Role>().FirstOrDefault(f => f.RoleId == id);
            if (local != null)
            {
                context.Set<Role>().Remove(local);
            }
            
            
        }


        public RoleDal GetByPredicate(System.Linq.Expressions.Expression<Func<RoleDal, bool>> f)
        {
            throw new NotImplementedException();
        }
    }
}
