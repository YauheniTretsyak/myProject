using BLL.Interface.Entities;
using BLL.Interface.Services;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
            
        }
        public IEnumerable<UserDTO> GetAll()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }

        public UserDTO GetById(int id)
        {
            return userRepository.GetById(id).ToBllUser();
        }


        public void Create(UserDTO item)
        {
            userRepository.Create(item.ToDalUser());
            uow.Commit();
        }

        public void Update(UserDTO item)
        {
            userRepository.Update(item.ToDalUser());
            uow.Commit();
        }


        public void Delete(int id)
        {
            userRepository.Delete(id);
            uow.Commit();
        }

    }
}
