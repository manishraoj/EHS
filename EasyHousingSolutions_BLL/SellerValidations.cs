using EasyHousingSolutions_DAL;
using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyHousingSolutions_BLL
{
    public class SellerValidations
    {
        SellerOperations OperationsObj = null;


        public bool AddSeller(Seller newSeller)
        {
            try
            {
                OperationsObj = new SellerOperations();
                return OperationsObj.AddSeller(newSeller);
            }
            catch (SellerException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool AddProperty(Property newProperty)
        {

            try
            {
                OperationsObj = new SellerOperations();
                return OperationsObj.AddProperty(newProperty);
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

        public bool UpdateProperty(Property newProperty)
        {
            try
            {
                OperationsObj = new SellerOperations();
                return OperationsObj.UpdateProperty(newProperty);
            }
            catch (SellerException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public List<Property> viewProp(int sellerID, bool? status)
        {

            try
            {
                OperationsObj = new SellerOperations();
                return OperationsObj.viewProperties(sellerID, status);
            }
            catch (SellerException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<Property> viewProp(int sellerID)
        {
            try
            {
                OperationsObj = new SellerOperations();
                return OperationsObj.viewProperties(sellerID);
            }
            catch (SellerException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public Property GetProp(int propId)
        {

            try
            {
                OperationsObj = new SellerOperations();
                return OperationsObj.GetPropertyById(propId);
            }
            catch (SellerException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<City> GetCities(int stateId)
        {

            try
            {
                OperationsObj = new SellerOperations();
                return OperationsObj.GetCityByState(stateId);
            }
            catch (SellerException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public List<State> GetStateById(int stateId)
        {

            try
            {
                OperationsObj = new SellerOperations();
                return OperationsObj.GetStateById(stateId);
            }
            catch (SellerException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public List<City> Get_City(int cityId)
        {
            try
            {
                OperationsObj = new SellerOperations();
                return OperationsObj.GetCity(cityId);
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

        public int GetSellerId(string userName)
        {

            try
            {
                OperationsObj = new SellerOperations();
                return OperationsObj.GetSellerId(userName);
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

        public List<State> GetStates()
        {

            try
            {
                OperationsObj = new SellerOperations();
                return OperationsObj.GetStates();
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