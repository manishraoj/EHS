using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_DAL
{
    public class SellerOperations
    {
        EasyHousingSolutions_Entities ehsEntity = null;

        #region Method for seller registration
        public bool AddSeller(Seller newSeller)
        {
            bool sellerAdded = false;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();
                 ehsEntity.Sellers.Add(newSeller);
                ehsEntity.SaveChanges();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sellerAdded;
        }
        #endregion

        #region Method to Add new Property
        public bool AddProperty(Property newProperty)
        {
            bool propertyAdded = false;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();
                propertyAdded = ehsEntity.Properties.Add(newProperty);
                ehsEntity.SaveChanges();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propertyAdded;
        }
        #endregion

        #region Method to Update existing property details
        public bool UpdateProperty(Property updateProperty)
        {
            bool propertyUpdated = false;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                List<Property> result = (from prop in ehsEntity.Properties
                                         where prop.PropertyId == updateProperty.PropertyId
                                         select prop).ToList();

                result[0].PropertyName = updateProperty.PropertyName;
                result[0].Address = updateProperty.Address;
                result[0].Description = updateProperty.Description;
                result[0].Status_Description = updateProperty.Status_Description;
                result[0].Images = updateProperty.Images;
                result[0].InitialDeposit = updateProperty.InitialDeposit;
                result[0].Landmark = updateProperty.Landmark;
                result[0].PriceRange = updateProperty.PriceRange;
                result[0].PropertyOption = updateProperty.PropertyOption;
                result[0].PropertyType = updateProperty.PropertyType;
                propertyUpdated = ehsEntity.SaveChanges();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propertyUpdated;
        }
        #endregion

        #region Method to get properties of a seller based on status
        public List<Property> viewProperties(int sellerID, bool? status)
        {
            List<Property> result = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                result = (from prop in ehsEntity.Properties
                          where prop.SellerId == sellerID && prop.IsActive == status
                          select prop).ToList();
            }
            catch (SellerException)
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

        #region Method to get all properties of a seller
        public List<Property> viewProperties(int sellerID)
        {
            List<Property> result = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                result = (from prop in ehsEntity.Properties
                          where prop.SellerId == sellerID
                          select prop).ToList();
            }
            catch (SellerException)
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

        #region Method to get property using its ID
        public Property GetPropertyById(int propId)
        {
            Property result = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                result = (from prop in ehsEntity.Properties
                          where prop.PropertyId == propId
                          select prop).FirstOrDefault();
            }
            catch (SellerException)
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

        #region Method to get all Cities of a state by StateId
        public List<City> GetCityByState(int stateId)
        {
            List<City> prp = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                prp = (from p in ehsEntity.Cities
                       where p.StateId == stateId
                       select p).ToList();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;
        }
        #endregion

        #region Method to get city by cityId
        public List<City> GetCity(int cityId)
        {
            List<City> prp = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                prp = (from p in ehsEntity.Cities
                       where p.CityId == cityId
                       select p).ToList();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;
        }
        #endregion

        #region Method to get State using stateId
        public List<State> GetStateById(int stateId)
        {
            List<State> prp = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                prp = (from p in ehsEntity.States
                       where p.StateId == stateId
                       select p).ToList();
            }
            catch (SellerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;
        }
        #endregion

        #region Method to get All States
        public List<State> GetStates()
        {
            List<State> result = null;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                result = (from p in ehsEntity.States

                          select p).ToList();
            }
            catch (SellerException)
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

        #region Method to get sellerId of a seller using username
        public int GetSellerId(string userName)
        {

            int result;
            try
            {
                ehsEntity = new EasyHousingSolutions_Entities();

                result = (from p in ehsEntity.Sellers
                          where p.UserName == userName
                          select p.SellerId).FirstOrDefault();
            }
            catch (SellerException)
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
