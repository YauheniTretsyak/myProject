using KnowledgeAccounting.Dal.Entities;
using KnowledgeAccounting.Dal.Interfaces;
using KnowledgeAccounting.Dal.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace KnowledgeAccounting.Bll.Providers
{
  public class CustomRoleProvider : RoleProvider
  {
      [Inject]
      public IUnitOfWork userService { get; set; }
    public override string[] GetRolesForUser(string username)
    {
   
      string[] role = new string[] { };

      try
      {
          // Получаем пользователя
          User user = userService.Users.GetAll().Where(x => x.Name == username).FirstOrDefault();

          if (user != null)
          {
              // получаем роль
              Role userRole = userService.Roles.GetById(user.RoleId);

              if (userRole != null)
              {
                  role = new string[] { userRole.Name };
              }
          }
      }


      catch
      {
          role = new string[] { };
      }
      
      return role;
    }
    public override void CreateRole(string roleName)
    {
      Role newRole = new Role() { Name = roleName };


        userService.Roles.Create(newRole);
        userService.Save();
      

    }

    public override bool IsUserInRole(string username, string roleName)
    {

      bool outputResult = false;
      // Находим пользователя

        try
        {
          // Получаем пользователя
          User user = userService.Users.GetAll().Where(x=>x.Name==username).FirstOrDefault();

          if (user != null)
          {
            // получаем роль
            Role userRole = userService.Roles.GetById(user.RoleId);

            //сравниваем
            if (userRole != null && userRole.Name == roleName)
            {
              outputResult = true;
            }
          }
        }
        catch
        {
          outputResult = false;
        }
      
      return outputResult;
    }


    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
      throw new NotImplementedException();
    }

    public override string ApplicationName
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    

    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
      throw new NotImplementedException();
    }

    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
      throw new NotImplementedException();
    }

    public override string[] GetAllRoles()
    {
      throw new NotImplementedException();
    }

  

    public override string[] GetUsersInRole(string roleName)
    {
      throw new NotImplementedException();
    }

   

    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
      throw new NotImplementedException();
    }

    public override bool RoleExists(string roleName)
    {
      throw new NotImplementedException();
    }
  }
}
