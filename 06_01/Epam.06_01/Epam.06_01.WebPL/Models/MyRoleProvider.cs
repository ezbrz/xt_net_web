using Epam._06_01.BLL.Interfaces;
using Epam._06_01.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epam._06_01.WebPL.Models
{
    public class MyRoleProvider : RoleProvider
    {
        IAuthUserLogic authUserLogic = DependencyResolver.AuthUserLogic;
        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            if (authUserLogic.GetByName(username)!=null&&authUserLogic.GetByName(username).IsAdmin) { roles.Append("ADMIN"); }
            return roles;
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            if (authUserLogic.GetByName(username) != null)
            {
                return authUserLogic.GetByName(username).IsAdmin;
            }
            return false;
        }
        #region NOT_IMPLEMENTED

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
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
        #endregion
    }
}