using KnowledgeAccounting.Bll.DTO;
using KnowledgeAccounting.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeAccounting.Bll.Mappers;
using KnowledgeAccounting.Dal.Interfaces;

namespace KnowledgeAccounting.Bll.Providers
{
 public class KnowledgeService : IService<KnowledgeDTO>
  {
    private readonly IUnitOfWork database;

    public KnowledgeService(IUnitOfWork uow)
    {
      this.database = uow;

    }
    public IEnumerable<KnowledgeDTO> GetAll()
    {
      return database.Knowledges.GetAll().Select(x => x.ToBllKnowledge());
    }

    public KnowledgeDTO GetById(int id)
    {
      return database.Knowledges.GetById(id).ToBllKnowledge();
    }

    public void Create(KnowledgeDTO item)
    {
      database.Knowledges.Create(item.ToDalKnowledge());
      database.Save();
    }

    public void Update(KnowledgeDTO item)
    {
      database.Knowledges.Update(item.ToDalKnowledge());
      database.Save();
    }

    public void Delete(int id)
    {
      database.Knowledges.Delete(id);
      database.Save();
    }
     public void Dispose()
    {
      database.Dispose();
    }
  }
}
