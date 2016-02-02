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
    public class KnowledgeService : IKnowledgeService
    {
        private readonly IUnitOfWork uow;
        private readonly IKnowledgeRepository knowlRepository;

        public KnowledgeService(IUnitOfWork uow, IKnowledgeRepository repository)
        {
            this.uow = uow;
            this.knowlRepository = repository;
            
        }
        public IEnumerable<KnowledgeDTO> GetAll()
        {
            return knowlRepository.GetAll().Select(x => x.ToBllKnowledge());
        }

        public KnowledgeDTO GetById(int id)
        {
            return knowlRepository.GetById(id).ToBllKnowledge();
        }

        public void Create(KnowledgeDTO item)
        {
            knowlRepository.Create(item.ToDalKnowledge());
            uow.Commit();
        }

        public void Update(KnowledgeDTO item)
        {
            knowlRepository.Update(item.ToDalKnowledge());
            uow.Commit();
        }

        public void Delete(int id)
        {
            knowlRepository.Delete(id);
            uow.Commit();
        }



    }
}
