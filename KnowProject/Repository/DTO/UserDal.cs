using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class UserDal : IEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public byte[] Photo { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }

  }
}
