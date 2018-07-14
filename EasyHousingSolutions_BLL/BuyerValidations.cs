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
    public class BuyerValidations
    {

        BuyerOperations bo = null;
        private static bool ValidateBuyer(Buyer buyer)
        {
            StringBuilder sb = new StringBuilder();
            bool validBuyer = true;

            if (!(Regex.IsMatch(buyer.UserName, @"^[a-zA-Z0-9]{0,25}")))
            {
                validBuyer = false;
                sb.Append(Environment.NewLine + "UserName should contain only characters.");
            }
            if (buyer.FirstName == string.Empty)
            {
                validBuyer = false;
                sb.Append(Environment.NewLine + "First Name Required");
            }
            else
            if (!(Regex.IsMatch(buyer.FirstName, @"^[a-zA-Z ]{0,25}")))
            {
                validBuyer = false;
                sb.Append(Environment.NewLine + "First Name should contain only characters.");
            }

            if (!(Regex.IsMatch(buyer.LastName, @"^[a-zA-Z ]{0,25}")) && buyer.LastName != string.Empty)
            {
                validBuyer = false;
                sb.Append(Environment.NewLine + "Last Name should contain only characters.");
            }

            if (!(Regex.IsMatch(buyer.PhoneNo, @"^[7-9]{1}[0-9]{9}")))
            {
                validBuyer = false;
                sb.Append(Environment.NewLine + "Contact number should contain only numbers.");
            }


            if (buyer.DateOfBirth > DateTime.Now && buyer.DateOfBirth < DateTime.Parse("1/1/1940") || buyer.DateOfBirth == null)
            {
                validBuyer = false;
                sb.Append(Environment.NewLine + "Enter Valid DateOfBirth");
            }

            if (!Regex.IsMatch(buyer.EmailId, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
            {
                validBuyer = false;
                sb.Append(Environment.NewLine + "Enter Valid EmailID");
            }
            if (validBuyer == false)
                throw new BuyerException(sb.ToString());
            return validBuyer;
        }


        // insering into database...
        public void AddBuyer(Buyer buyer)
        {
            try
            {
                bo = new BuyerOperations();
                // if (ValidateBuyer(buyer))
                {
                    bo.InsertBuyer(buyer);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // add to cart..
        public List<Property> AddToCart(int propID)
        {
            List<Property> propertyList = new List<Property>();

            try
            {
                bo = new BuyerOperations();
                {
                    propertyList = bo.AddToCart(propID);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return propertyList;
        }

        public List<Property> DeletefromCart(int propID)
        {
            List<Property> propertyList = new List<Property>();
            try
            {
                bo = new BuyerOperations();
                {
                    propertyList = bo.DeleteFromCart(propID);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return propertyList;
        }


        #region show all the properties..
        public List<Property> showProperties()
        {
            List<Property> propertyList = new List<Property>();
            try
            {

                bo = new BuyerOperations();
                {
                    propertyList = bo.ShowALLProperties();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return propertyList;
        }


        #endregion

        #region show cart ...
        public List<Property> showCart()
        {
            List<Property> propertyList = new List<Property>();
            try
            {
                bo = new BuyerOperations();
                {
                    propertyList = bo.ShowCart();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return propertyList;
        }
        #endregion

        public int BuyerId(string userName)
        {

            try
            {
                BuyerOperations e = new BuyerOperations();
                return e.BuyerId(userName);
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
        public void GetBuyerId(int buyerId)
        {

            try
            {
                BuyerOperations e = new BuyerOperations();
                e.GetBuyerId(buyerId);
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
