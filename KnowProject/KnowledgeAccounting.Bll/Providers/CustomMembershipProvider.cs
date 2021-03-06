﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.Helpers;
using System.Security.Cryptography;
using KnowledgeAccounting.Dal.Interfaces;
using KnowledgeAccounting.Dal.Repositories;
using KnowledgeAccounting.Dal.Entities;
using KnowledgeAccounting.Bll.DTO;
using Ninject.Modules;
using Ninject;
using KnowledgeAccounting.Bll.Infrastructure;
using KnowledgeAccounting.Bll.Mappers;


namespace KnowledgeAccounting.Bll.Providers
{
  public class CustomMembershipProvider : MembershipProvider
  {
      [Inject]
      public IUnitOfWork userService { get; set; }
      public override bool ValidateUser(string email, string password)
      {

          bool isValid = false;

          try
          {
              var user = userService.Users.GetAll().Where(x => x.Email == email).First();


              if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
              {
                  isValid = true;
              }
          }
          catch
          {
              isValid = false;
          }

          return isValid;
      }


      public MembershipUser CreateUser(string username, string password, string email, byte[] Photo)
      {
          MembershipUser membershipUser = GetUser(email, false);

          if (membershipUser == null)
          {
              try
              {

                  var user = new User();
                  user.Name = username;
                  user.Password = Crypto.HashPassword(password);
                  user.RoleId = 2;
                  user.Photo = Photo;
                  user.Email = email;
                  userService.Users.Create(user);
                  userService.Save();
                  membershipUser = GetUser(email, false);

                  return membershipUser;

              }
              catch
              {
                  return null;
              }
          }
          return null;
      }

      public override MembershipUser GetUser(string email, bool userIsOnline)
      {
          try
          {
              var user = userService.Users.GetAll().Where(x => x.Email == email).FirstOrDefault();

              if (user != null)
              {
                  MembershipUser memberUser = new MembershipUser("MyMembershipProvider", user.Name, user.UserId, user.Email, null, null,
                      false, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
                  return memberUser;
              }

          }
          catch
          {
              return null;
          }
          return null;
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

    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {
      throw new NotImplementedException();
    }

    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {
      throw new NotImplementedException();
    }

    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
      throw new NotImplementedException();
    }

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
      throw new NotImplementedException();
    }

    public override bool EnablePasswordReset
    {
      get { throw new NotImplementedException(); }
    }

    public override bool EnablePasswordRetrieval
    {
      get { throw new NotImplementedException(); }
    }

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
      throw new NotImplementedException();
    }

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
      throw new NotImplementedException();
    }

    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
      throw new NotImplementedException();
    }

    public override int GetNumberOfUsersOnline()
    {
      throw new NotImplementedException();
    }

    public override string GetPassword(string username, string answer)
    {
      throw new NotImplementedException();
    }



    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
      throw new NotImplementedException();
    }

    public override string GetUserNameByEmail(string email)
    {
      throw new NotImplementedException();
    }

    public override int MaxInvalidPasswordAttempts
    {
      get { throw new NotImplementedException(); }
    }

    public override int MinRequiredNonAlphanumericCharacters
    {
      get { throw new NotImplementedException(); }
    }

    public override int MinRequiredPasswordLength
    {
      get { throw new NotImplementedException(); }
    }

    public override int PasswordAttemptWindow
    {
      get { throw new NotImplementedException(); }
    }

    public override MembershipPasswordFormat PasswordFormat
    {
      get { throw new NotImplementedException(); }
    }

    public override string PasswordStrengthRegularExpression
    {
      get { throw new NotImplementedException(); }
    }

    public override bool RequiresQuestionAndAnswer
    {
      get { throw new NotImplementedException(); }
    }

    public override bool RequiresUniqueEmail
    {
      get { throw new NotImplementedException(); }
    }

    public override string ResetPassword(string username, string answer)
    {
      throw new NotImplementedException();
    }

    public override bool UnlockUser(string userName)
    {
      throw new NotImplementedException();
    }

    public override void UpdateUser(MembershipUser user)
    {
      throw new NotImplementedException();
    }


  }
}
