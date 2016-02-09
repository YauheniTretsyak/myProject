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
  public class UserService : IService<UserDTO>
  {
    private readonly IUnitOfWork database;
   
    public UserService(IUnitOfWork uow)
    {
      this.database = uow;

    }
    public IEnumerable<UserDTO> GetAll()
    {
      return database.Users.GetAll().Select(user => user.ToBllUser());
    }

    public UserDTO GetById(int id)
    {
      return database.Users.GetById(id).ToBllUser();
    }


    public void Create(UserDTO item)
    {
      database.Users.Create(item.ToDalUser());
      database.Save();
    }

    public void Update(UserDTO item)
    {
      database.Users.Update(item.ToDalUser());
      database.Save();
    }

    public void Delete(int id)
    {
      database.Users.Delete(id);
      database.Save();
    }
    public void Dispose()
    {
      database.Dispose();
    }
  }
}
