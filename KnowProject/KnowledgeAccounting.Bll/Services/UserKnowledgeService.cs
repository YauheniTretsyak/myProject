using KnowledgeAccounting.Bll.DTO;
using KnowledgeAccounting.Bll.Interfaces;
using KnowledgeAccounting.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeAccounting.Bll.Mappers;

namespace KnowledgeAccounting.Bll.Providers
{
  public class UserKnowledgeService : IService<UserKnowledgeDTO>
  {
    private readonly IUnitOfWork database;

    public UserKnowledgeService(IUnitOfWork uow)
    {
      this.database = uow;

    }
    public IEnumerable<UserKnowledgeDTO> GetAll()
    {
      return database.UsersKnowledges.GetAll().Select(x => x.ToBllUserKnowledge());
    }

    public UserKnowledgeDTO GetById(int id)
    {
      return database.UsersKnowledges.GetById(id).ToBllUserKnowledge();
    }

    public void Create(UserKnowledgeDTO item)
    {
      database.UsersKnowledges.Create(item.ToDalUsersKnowledge());
      database.Save();
    }

    public void Update(UserKnowledgeDTO item)
    {
      database.UsersKnowledges.Update(item.ToDalUsersKnowledge());
      database.Save();
    }

    public void Delete(int id)
    {
      database.UsersKnowledges.Delete(id);
      database.Save();
    }
    public void Dispose()
    {
      database.Dispose();
    }
  }
}
