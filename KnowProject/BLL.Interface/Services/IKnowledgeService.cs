using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IKnowledgeService
    {
        IEnumerable<KnowledgeDTO> GetAll();
        KnowledgeDTO GetById(int id);
        void Create(KnowledgeDTO item);
        void Update(KnowledgeDTO item);
        void Delete(int id);
        
    }
}
