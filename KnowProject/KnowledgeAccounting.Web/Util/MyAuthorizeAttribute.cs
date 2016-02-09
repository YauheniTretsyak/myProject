using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcPL.Filters
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] allowedUsers = new string[] { };
        private string[] allowedRoles = new string[] { };

        public MyAuthorizeAttribute()
        { }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!String.IsNullOrEmpty(base.Users))
            {
                allowedUsers = base.Users.Split(new char[] { ',' });
                for (int i = 0; i < allowedUsers.Length; i++)
                {
                    allowedUsers[i] = allowedUsers[i].Trim();
                }
            }
            if (!String.IsNullOrEmpty(base.Roles))
            {
                allowedRoles = base.Roles.Split(new char[] { ',' });
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    allowedRoles[i] = allowedRoles[i].Trim();
                }
            }

            return httpContext.Request.IsAuthenticated &&
                 User(httpContext) && Role(httpContext);
        }

        private bool User(HttpContextBase httpContext)
        {
            if (allowedUsers.Length > 0)
            {
                return allowedUsers.Contains(Membership.GetUser().UserName);
            }
            return true;
        }

        private bool Role(HttpContextBase httpContext)
        {
            if (allowedRoles.Length > 0)
            {
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    if (System.Web.Security.Roles.Provider.IsUserInRole(Membership.GetUser().UserName, allowedRoles[i]))
                        return true;
                }
                return false;
            }
            return true;
        }
    }
}