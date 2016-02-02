using BLL.Interface.Entities;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Infrastructura
{
    public static class MappersForWeb
    {
        public static UserViewModel ToWebUser(this UserDTO dtoUser)
        {
            return new UserViewModel()
            {
                Email = dtoUser.Email,
                Name = dtoUser.Name,
                Password = dtoUser.Password,
                Photo = dtoUser.Photo,
                RoleId = dtoUser.RoleId,
                UserId = dtoUser.UserId

            };
        }
        public static UserDTO ToDTOUser(this UserViewModel webUser)
        {
            return new UserDTO()
            {
                
                Email = webUser.Email,
                Name = webUser.Name,
                Password = webUser.Password,
                Photo = webUser.Photo,
                RoleId = webUser.RoleId,
                UserId = webUser.UserId

            };
        }

        public static RoleViewModel ToWebRole(this RoleDTO dtoRole)
        {
            return new RoleViewModel()
            {
                Name = dtoRole.Name,
                RoleId = dtoRole.RoleId

            };
        }
        public static RoleDTO ToDTORole(this RoleViewModel webRole)
        {
            return new RoleDTO()
            {
                Name = webRole.Name,
                RoleId = webRole.RoleId
                
            };
        }

        public static KnowledgeViewModel ToWebKnowl(this KnowledgeDTO dtoKnowl)
        {
            return new KnowledgeViewModel()
            {
                KnowledgeId = dtoKnowl.KnowledgeId,
                Name = dtoKnowl.Name

            };
        }
        public static KnowledgeDTO ToDTOKnowl(this KnowledgeViewModel webKnowl)
        {
            return new KnowledgeDTO()
            {
                KnowledgeId = webKnowl.KnowledgeId,
                Name = webKnowl.Name
                
            };
        }

        public static UsersKnowledgeViewModel ToWebUserKnowl(this UserKnowledgeDTO dtoUKnowl)
        {
            return new UsersKnowledgeViewModel()
            {
                Degree = dtoUKnowl.Degree,
                Description = dtoUKnowl.Description,
                KnowledgeId = dtoUKnowl.KnowledgeId,
                UserId = dtoUKnowl.UserId,
                UsersKnowledgeId = dtoUKnowl.UsersKnowledgeId

            };
        }
        public static UserKnowledgeDTO ToDALUserKnowl(this UsersKnowledgeViewModel webUKnowl)
        {
            return new UserKnowledgeDTO()
            {
                Degree = webUKnowl.Degree,
                Description = webUKnowl.Description,
                KnowledgeId = webUKnowl.KnowledgeId,
                UserId = webUKnowl.UserId,
                UsersKnowledgeId = webUKnowl.UsersKnowledgeId
                
            };
        }
    }
}