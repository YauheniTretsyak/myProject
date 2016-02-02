using BLL.Interface.Entities;
using BLL.Interface.Services;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
            
        }
        public IEnumerable<RoleDTO> GetAll()
        {
            return roleRepository.GetAll().Select(x => x.ToBllRole());
        }

        public RoleDTO GetById(int id)
        {
            return roleRepository.GetById(id).ToBllRole();
        }


        public void Create(RoleDTO item)
        {
            roleRepository.Create(item.ToDalRole());
            uow.Commit();
        }

        public void Update(RoleDTO item)
        {
            roleRepository.Update(item.ToDalRole());
            uow.Commit();
        }

        public void Delete(int id)
        {
            roleRepository.Delete(id);
            uow.Commit();
        }

    }
}
