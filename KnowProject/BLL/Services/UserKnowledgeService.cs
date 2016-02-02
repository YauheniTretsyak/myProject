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
    public class UserKnowledgeService : IUserKnowledgeService
    {
        private readonly IUnitOfWork uow;
        private readonly IUsersKnowledgeRepository uKnowlRepository;

        public UserKnowledgeService(IUnitOfWork uow, IUsersKnowledgeRepository repository)
        {
            this.uow = uow;
            this.uKnowlRepository = repository;
            
        }
        public IEnumerable<UserKnowledgeDTO> GetAll()
        {
            return uKnowlRepository.GetAll().Select(x => x.ToBllUserKnowledge());
        }

        public UserKnowledgeDTO GetById(int id)
        {
            return uKnowlRepository.GetById(id).ToBllUserKnowledge();
        }

        public void Create(UserKnowledgeDTO item)
        {
            uKnowlRepository.Create(item.ToDalUsersKnowledge());
            uow.Commit();
        }

        public void Update(UserKnowledgeDTO item)
        {
            uKnowlRepository.Update(item.ToDalUsersKnowledge());
            uow.Commit();
        }

        public void Delete(int id)
        {
            uKnowlRepository.Delete(id);
            uow.Commit();
        }


    }
}
