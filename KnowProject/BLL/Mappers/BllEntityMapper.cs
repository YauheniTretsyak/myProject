using BLL.Interface.Entities;
using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class BllEntityMapper
    {
        public static UserDal ToDalUser(this UserDTO dtoUser)
        {
            return new UserDal()
            {
                Id = dtoUser.UserId,
                Name = dtoUser.Name,
                RoleId = dtoUser.RoleId,
                Password = dtoUser.Password,
                Email = dtoUser.Email,
                Photo=dtoUser.Photo

            };
        }

        public static UserDTO ToBllUser(this UserDal dalUser)
        {
            return new UserDTO()
            {
                UserId = dalUser.Id,
                Name = dalUser.Name,
                RoleId = dalUser.RoleId,
                Password = dalUser.Password,
                Email = dalUser.Email,
                Photo=dalUser.Photo

            };
        }

        public static RoleDal ToDalRole(this RoleDTO dtoRole)
        {
            return new RoleDal
            {
                Id = dtoRole.RoleId,
                Name = dtoRole.Name
            };
        }

        public static RoleDTO ToBllRole(this RoleDal dalRole)
        {
            return new RoleDTO
            {
                RoleId = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static KnowledgeDal ToDalKnowledge(this KnowledgeDTO dtoKnowledge)
        {
            return new KnowledgeDal
            {
                Id = dtoKnowledge.KnowledgeId,
                Name = dtoKnowledge.Name
            };
        }

        public static KnowledgeDTO ToBllKnowledge(this KnowledgeDal dalKnowledge)
        {
            return new KnowledgeDTO
            {
                KnowledgeId = dalKnowledge.Id,
                Name = dalKnowledge.Name
            };
        }

        public static UsersKnowledgeDal ToDalUsersKnowledge(this UserKnowledgeDTO dtoUsersKnowledge)
        {
            return new UsersKnowledgeDal
            {
                Id = dtoUsersKnowledge.UsersKnowledgeId,
                Degree = dtoUsersKnowledge.Degree,
                Description = dtoUsersKnowledge.Description,
                UserId = dtoUsersKnowledge.UserId,
                KnowledgeId = dtoUsersKnowledge.KnowledgeId,

            };
        }

        public static UserKnowledgeDTO ToBllUserKnowledge(this UsersKnowledgeDal dalUsersKnowledge)
        {
            return new UserKnowledgeDTO
            {
                UsersKnowledgeId = dalUsersKnowledge.Id,
                Degree = dalUsersKnowledge.Degree,
                Description = dalUsersKnowledge.Description,
                UserId = dalUsersKnowledge.UserId,
                KnowledgeId = dalUsersKnowledge.KnowledgeId,

            };

        }
    }
}
