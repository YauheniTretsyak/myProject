using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleDTO> GetAll();
        RoleDTO GetById(int id);
        void Create(RoleDTO item);
        void Update(RoleDTO item);
        void Delete(int id);
        
  
    }
}
