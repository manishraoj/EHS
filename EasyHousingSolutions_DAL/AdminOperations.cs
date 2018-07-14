using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_DAL
{
    public class AdminOperations
    {
        EasyHousingSolutions_Entities entityObj = null;

        #region Method to get properties by region
        public IQueryable<Property> viewPropByRegion(string state, string city)
        {
            IQueryable<Property> result = null;
            entityObj = new EasyHousingSolutions_Entities();
            try
            {
                result = (from prop in entityObj.Properties
                          select prop);
                if (state != string.Empty && city != string.Empty)
                {
                    result = (from prop in entityObj.Properties
                              where prop.StateId == (from sId in entityObj.States where sId.StateName == state select sId.StateId).FirstOrDefault()
                              && prop.CityId == (from sId in entityObj.Cities where sId.CityName == city select sId.CityId).FirstOrDefault()
                              select prop);
                }
                else if (state != string.Empty && city == string.Empty)
                {
                    result = (from prop in entityObj.Properties
                              where prop.StateId == (from sId in entityObj.States where sId.StateName == state select sId.StateId).FirstOrDefault()
                              select prop);
                }
            }
            catch (AdminException)
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

        #region Method to get properties by Owners
        public IQueryable<Property> viewPropByOwner(int OwnerId, string type)
        {
            entityObj = new EasyHousingSolutions_Entities();
            IQueryable<Property> result = null;
            try
            {
                entityObj = new EasyHousingSolutions_Entities();
                result = (from prop in entityObj.Properties
                          where prop.SellerId == OwnerId
                          && prop.PropertyOption == type
                          select prop);
            }
            catch (AdminException)
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

        #region Method to Verify properties
        public List<Property> VerifyProperty(int propId, bool? state)
        {
            List<Property> result = null;
            try
            {
                entityObj = new EasyHousingSolutions_Entities();

                result = (from prop in entityObj.Properties
                          where prop.PropertyId == propId
                          select prop).ToList<Property>();
                result[0].IsActive = state;

                entityObj.SaveChanges();
            }
            catch (AdminException)
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

        #region Method to get All Seller Details
        public List<Seller> GetOwners()
        {
            List<Seller> result = null;
            try
            {
                entityObj = new EasyHousingSolutions_Entities();
                result = (from p in entityObj.Sellers
                          select p).ToList();
            }
            catch (AdminException)
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
