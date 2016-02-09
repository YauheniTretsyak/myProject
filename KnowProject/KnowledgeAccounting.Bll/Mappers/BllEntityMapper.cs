using KnowledgeAccounting.Bll.DTO;
using KnowledgeAccounting.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccounting.Bll.Mappers
{
   public static class BllEntityMapper
  {
    public static User ToDalUser(this UserDTO dtoUser)
    {
      return new User()
      {
          UserId = dtoUser.UserId,
          Name = dtoUser.Name,
          RoleId = dtoUser.RoleId,
          Password = dtoUser.Password,
          Email = dtoUser.Email,
          Photo = dtoUser.Photo
        
      };
    }

    public static UserDTO ToBllUser(this User dalUser)
    {
      return new UserDTO()
      {
          UserId = dalUser.UserId,
          Name = dalUser.Name,
          RoleId = dalUser.RoleId,
          Password = dalUser.Password,
          Email = dalUser.Email,
          Photo = dalUser.Photo
        
      };
    }

    public static Role ToDalRole(this RoleDTO dtoRole) 
    {
      return new Role
      {
        RoleId = dtoRole.RoleId,
        Name = dtoRole.Name
      };
    }

    public static RoleDTO ToBllRole(this Role dalRole) 
    {
      return new RoleDTO
      {
        RoleId = dalRole.RoleId,
        Name = dalRole.Name
      };
    }

    public static Knowledge ToDalKnowledge(this KnowledgeDTO dtoKnowledge) 
    {
      return new Knowledge
      {
        KnowledgeId = dtoKnowledge.KnowledgeId,
        Name = dtoKnowledge.Name
      };
    }

    public static KnowledgeDTO ToBllKnowledge(this Knowledge dalKnowledge) 
    {
      return new KnowledgeDTO
      {
        KnowledgeId = dalKnowledge.KnowledgeId,
        Name = dalKnowledge.Name
      };
    }

    public static UsersKnowledge ToDalUsersKnowledge(this UserKnowledgeDTO dtoUsersKnowledge) 
    {
      return new UsersKnowledge
      {
        UsersKnowledgeId = dtoUsersKnowledge.UsersKnowledgeId,
        Degree = dtoUsersKnowledge.Degree,
        Description = dtoUsersKnowledge.Description,
        UserId = dtoUsersKnowledge.UserId,
        KnowledgeId = dtoUsersKnowledge.KnowledgeId,
      
      };
    }

    public static UserKnowledgeDTO ToBllUserKnowledge(this UsersKnowledge dalUsersKnowledge)
    {
      return new UserKnowledgeDTO
      {
        UsersKnowledgeId = dalUsersKnowledge.UsersKnowledgeId,
        Degree = dalUsersKnowledge.Degree,
        Description = dalUsersKnowledge.Description,
        UserId = dalUsersKnowledge.UserId,
        KnowledgeId = dalUsersKnowledge.KnowledgeId,
       
      };

    }
  }
}
