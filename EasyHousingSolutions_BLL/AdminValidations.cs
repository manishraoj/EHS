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
    public class AdminValidations
    {
        AdminOperations adminObj = null;
        public  IQueryable<Property> viewProp(string state, string city)
        {
            try
            {
                adminObj = new AdminOperations();
                return adminObj.viewPropByRegion(state, city);
            }
            catch (AdminException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Property> viewPropbyOwner(int ownerId, string type)
        {
            try
            {
                adminObj = new AdminOperations();
                return adminObj.viewPropByOwner(ownerId, type);
            }
            catch (AdminException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public  List<Property> verifyProperty(int propId, bool? state)
        {
            try
            {
                adminObj = new AdminOperations();
                return adminObj.VerifyProperty(propId, state);
            }
            catch (AdminException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public List<Seller> GetOwners()
        {
            
            try
           {
              adminObj = new AdminOperations();
              return adminObj.GetOwners();  
            }
            catch (AdminException)
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