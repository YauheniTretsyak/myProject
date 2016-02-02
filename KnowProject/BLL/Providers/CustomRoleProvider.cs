using BLL.Interface.Entities;
using BLL.Interface.Services;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using BLL.Mappers;
using System.Web.Mvc;

namespace BLL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
       
        public IUserService userService = (IUserService)DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService roleService = (IRoleService)DependencyResolver.Current.GetService(typeof(IRoleService));

        public override string[] GetRolesForUser(string username)
        {
            string[] role = new string[] { };


            try
            {

                // Получаем пользователя
                var user = userService.GetAll().Where(x => x.Name == username).FirstOrDefault();

                if (user != null)
                {
                    // получаем роль
                    var userRole = roleService.GetById(user.RoleId);

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

            RoleDTO newRole = new RoleDTO() { Name = roleName };

            roleService.Create(newRole);
            


        }

        public override bool IsUserInRole(string username, string roleName)
        {

            bool outputResult = false;
   

            try
            {

                UserDTO user = userService.GetAll().Where(x => x.Name == username).FirstOrDefault();

                if (user != null)
                {
                    RoleDTO userRole = roleService.GetById(user.RoleId);

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
