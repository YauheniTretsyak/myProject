using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IUserKnowledgeService
    {
        IEnumerable<UserKnowledgeDTO> GetAll();
        UserKnowledgeDTO GetById(int id);
        void Create(UserKnowledgeDTO item);
        void Update(UserKnowledgeDTO item);
        void Delete(int id);
        
    }
}
