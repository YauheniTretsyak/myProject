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
  public  class RoleService:IService<RoleDTO>
  {
    private readonly IUnitOfWork database;

    public RoleService(IUnitOfWork uow)
    {
      this.database = uow;

    }
    public IEnumerable<RoleDTO> GetAll()
    {
      return database.Roles.GetAll().Select(x => x.ToBllRole());
    }

    public RoleDTO GetById(int id)
    {
      return database.Roles.GetById(id).ToBllRole();
    }


    public void Create(RoleDTO item)
    {
      database.Roles.Create(item.ToDalRole());
      database.Save();
    }

    public void Update(RoleDTO item)
    {
      database.Roles.Update(item.ToDalRole());
      database.Save();
    }

    public void Delete(int id)
    {
      database.Roles.Delete(id);
      database.Save();
    }
     public void Dispose()
    {
      database.Dispose();
    }
  }
}
