using EasyHousingSolutions_DAL;
using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_BLL
{
    public class UsersValidations
    {
        UsersOperations operationsObj = null;
        public bool AddUser(User newUser)
        {
            
            try
            {
                operationsObj = new UsersOperations();
                {
                   return operationsObj.AddUser(newUser);
                }
            }
            catch (UserException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public User LoginUser(User login)
        {

            try
            {
                operationsObj = new UsersOperations();
                {
                    return operationsObj.LoginUser(login);
                }
            }
            catch (UserException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}
