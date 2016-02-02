using ORM;
using Repository.DTO;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<UserDal> GetAll()
        {
            return context.Set<User>().Select(user => new UserDal()
            {
                Email = user.Email,
                Id = user.UserId,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId,
                Photo=user.Photo

            });
        }

        public UserDal GetById(int id)
        {
            var temp = context.Set<User>().FirstOrDefault(user => user.UserId == id);
            return new UserDal()
            {
                Email = temp.Email,
                Id = temp.UserId,
                Name = temp.Name,
                Password = temp.Password,
                RoleId = temp.RoleId,
                Photo=temp.Photo
            };
        }

        public void Create(UserDal user)
        {
            var item = new User()
            {
                Email = user.Email,
                UserId = user.Id,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId,
                Photo=user.Photo
            };
            context.Set<User>().Add(item);
            
        }

        public void Update(UserDal user)
        {

           User objFromBase = context.Set<User>().FirstOrDefault(user1 => user1.UserId == user.Id);
            var item = new User()
            {
                Email = user.Email,
                UserId = user.Id,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId,
                Photo = user.Photo,
                Role=objFromBase.Role,
                UserKnowledge=objFromBase.UserKnowledge,
                
            };

            var local = context.Set<User>()
                         .Local
                         .FirstOrDefault(f => f.UserId == user.Id);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(item).State = EntityState.Modified;
      
        }

        public void Delete(int id)
        {
            var local = context.Set<User>().First(f => f.UserId == id);
            if (local != null)
            {
                context.Set<User>().Remove(local);
            }
          
            
        }


        public IEnumerable<UserDal> GetByPredicate(Expression<Func<UserDal, bool>> predicate)
        {
            throw new NotImplementedException();
        }

    }

  
}
