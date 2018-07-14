using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_DAL
{
    public class UsersOperations
    {
        EasyHousingSolutions_Entities entityObj = null;

        #region Method to Add new user
        public bool AddUser(User newUser)
        {
            bool userAdded = false;
            try
            {
                entityObj = new EasyHousingSolutions_Entities();
                userAdded = entityObj.Users.Add(newUser);
                entityObj.SaveChanges();
                
            }
            catch (UserException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userAdded;
        }
        #endregion

        #region Method to authenticate user login
        public User LoginUser(User login)
        {
            entityObj = new EasyHousingSolutions_Entities();
            var result = new User();
            try
            {
                result = (from user in entityObj.Users
                          where user.UserName == login.UserName && user.Password == login.Password
                          select user).FirstOrDefault();
            }
            catch (UserException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion
    }
}
