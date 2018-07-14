using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_DAL
{
    public class BuyerOperations
    {
        // Creating object for DB Context Entity
        EasyHousingSolutions_Entities EasyHousingSolutionsEntities_Object = null;

        // Allocating Memory for DB Context Entity
        BuyerOperations()
        {
            EasyHousingSolutionsEntities_Object = new EasyHousingSolutions_Entities();
        }

        /// <summary>
        ///  This function will return  all the Property details to Search the properties.. and s
        /// </summary>
        /// <param name="property"></param>
        #region  this will Search the properties.. and s

        public void FilteredData(Property property)
        {
            EasyHousingSolutions_Entities entity = new EasyHousingSolutions_Entities();
            var filteredData = from a in entity.Properties
                               where a.Address.ToString() == property.Address && a.PropertyType == property.PropertyType
                               orderby a.PriceRange ascending
                               select a;
            foreach (var k in filteredData)
            {
                Console.WriteLine(k.PropertyName + "" + k.PropertyOption + " " + k.SellerId + " " + k.PriceRange);
            }
        }
        #endregion



        #region// this will sort the properties..
        public void SortByPrice()
        {
            EasyHousingSolutions_Entities entity = new EasyHousingSolutions_Entities();
            var SortedData = from a in entity.Properties
                             orderby a.PriceRange ascending
                             select a;

        }
        #endregion


        /// <summary>
        /// Author: Batch3
        /// Description: This function is written to add the properties to the cart of the specific buyer.
        /// Function Name: AddToCart
        /// Input arguments: PropertyID
        /// Return Type : A List which contain Property Details that match with the PropertyID.
        /// Date: 07/14/2018
        /// </summary>


        #region  AddToCart function starts here...


   // here we are suppose to use the sessions get the user credentials..
        static int Loginid;
        public void GetBuyerId(int buyrId)
        {
            Loginid = buyrId;
        }
        public List<Property> AddToCart(int PropertyID)
        {
            // Instatiating cart Object

            Cart cartObject = new Cart();


            // Creating a list object of type Property

            List<Property> AddedProperty_toCart = new List<Property>();


            // A LINQ query to get the Property details match with PropertyID

            var PropertyDetails = from property in EasyHousingSolutionsEntities_Object.Properties where property.PropertyId == PropertyIDselect property;


            //This Loop will Add the Property Details to AddedProperty_toCart object

            foreach (var PropertyData in PropertyDetails)
            {
                AddedProperty_toCart.Add(PropertyData);
            }


            // Assigning PropertyId to Cart PropertyId

            cartObject.PropertyId = PropertyID;

           
            // Assigning Current BuyerId  to Cart BuyerId

            cartObject.BuyerId = Loginid;

           
            // Adding Cart details to the CartTable

            EasyHousingSolutionsEntities_Object.Carts.Add(cartObject);

            EasyHousingSolutionsEntities_Object.SaveChanges();

            return AddedProperty_toCart;
        }


        #endregion AddToCart function ends here...


        /// <summary>
        /// Author: Batch3
        /// Description: This function is written to Delete the properties from the cart of the specific buyer.
        /// Function Name: DeleteFromCart
        /// Input arguments: PropertyID
        /// Return Type : A List which contain Property Details that match with the PropertyID.
        /// Date: 07/14/2018
        /// </summary>


        #region  DeleteFromCart function starts here...

        public List<Property> DeleteFromCart(int PropertyID)
        {
            // Creating a list object of type Property

            List<Property> DeletedProperty_fromCart = new List<Property>();


            // A LINQ query to get the Property details match with PropertyID
            
            var Property_ToBe_Delete = from property in EasyHousingSolutionsEntities_Object.Carts where property.PropertyId == PropertyID && property.BuyerId == Loginid select property;


            //This Loop will Delete the Property Details from specific Buyer Cart 
            foreach (var property in Property_ToBe_Delete)
            {
                EasyHousingSolutionsEntities_Object.Carts.Remove(property);
            }

            // fectching the property data which is deleted...
            var propdata = from PropertyData in entity.Properties
                           where PropertyData.PropertyId == PropertyID
                           select PropertyData;
            foreach (var k in propdata)
            {
                DeletedProperty_fromCart.Add(k);
            }

            entity.SaveChanges();
            return DeletedProperty_fromCart;

        }
        #endregion DeleteFromCart function ends here...

        /// <summary>
        /// Author: Batch3
        /// Description: This function is written to Show cart details what buyer is added into the cart.
        /// Function Name: ShowCart
        /// Input arguments:
        /// Return Type : A List which contain cart Details that match with the PropertyID and BuyerId.
        /// Date: 07/14/2018
        /// </summary>


        #region show cart

        public List<Property> ShowCart()
        {
            EasyHousingSolutions_Entities entity = new EasyHousingSolutions_Entities();

            // Creating a list object of type Property
            List<Property> propertyList = new List<Property>();

            // A LINQ query to get the cart details match with PropertyID and BuyerId
            var shoWCart = from PropertyData in entity.Properties
                           from Cart in entity.Carts

                           where PropertyData.PropertyId == Cart.PropertyId
                           && Cart.BuyerId == Loginid
                           select PropertyData;
            //This Loop will show the cart Details 
            foreach (var k in shoWCart)
            {
                propertyList.Add(k);
            }

            return propertyList;
        }



        #endregion

        #region   fetching all the property data from DB 
        /// <summary>
        /// Author: Batch3
        /// Description: This function is written to Show all Property details of the buyer.
        /// Function Name: ShowCart
        /// Input arguments:
        /// Return Type : A List which contain all Property Details of the buyer.
        /// Date: 07/14/2018
        /// </summary>


        public List<Property> ShowALLProperties()
        {
            EasyHousingSolutions_Entities entity = new EasyHousingSolutions_Entities();
            // Creating a list object of type Property
            List<Property> propertyList = new List<Property>();

            // A LINQ query to get all property details of the buyer
            var HouseDetails = from PropertyData in entity.Properties
                               select PropertyData;
            //This Loop will show the property Details of buyer
            foreach (var k in HouseDetails)
            {
                propertyList.Add(k);
            }
            return propertyList;


        }

        #endregion

        #region adding buyer details to databse..
        /// <summary>
        /// Author: Batch3
        /// Description: This function is written to add buyer details.
        /// Function Name: ShowCart
        /// Input arguments:
        /// Return Type : A List which contain buyer details.
        /// Date: 07/14/2018
        /// </summary>
        public void InsertBuyer(Buyer newBuyer)
        {
            EasyHousingSolutions_Entities ehsEntity = new EasyHousingSolutions_Entities();

            // Adding buyer details to the BuyerTable
            ehsEntity.Buyers.Add(newBuyer);

            ehsEntity.SaveChanges();
        }
        #endregion

        public int BuyerId(string userName)
        {

            int prp;
            try
            {

                prp = (from p in EasyHousingSolutionsEntities_Object.Buyers
                       where p.UserName == userName
                       select p.BuyerId).FirstOrDefault();
            }
            catch (BuyerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prp;

        }

    }
}
