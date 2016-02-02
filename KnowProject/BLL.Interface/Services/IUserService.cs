using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO GetById(int id);
        void Create(UserDTO item);
        void Update(UserDTO item);
        void Delete(int id);
        
    }
}
