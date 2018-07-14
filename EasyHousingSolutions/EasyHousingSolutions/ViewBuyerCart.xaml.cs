using EasyHousingSolutions_BLL;
using EasyHousingSolutions_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyHousingSolutions
{
    /// <summary>
    /// Interaction logic for ViewBuyerCart.xaml
    /// </summary>
    public partial class ViewBuyerCart : Page
    {
        public ViewBuyerCart()
        {
            InitializeComponent();
        }
        int buyerId = 0;

        public ViewBuyerCart(int val) : this()
        {
            buyerId = val;
            this.Loaded += new RoutedEventHandler(ViewBuyerCart_Loaded);

        }
        void ViewBuyerCart_Loaded(object sender, RoutedEventArgs e)
        {
            // lblView.Content = sellerId.ToString();

        }

        #region delete from cart ...

        void ConfirmCart(object sender, EventArgs e, int PropID, StackPanel StackOFDetails, WrapPanel wp)
        {
            List<Property> propertyList = new List<Property>();
            BuyerValidations buval = new BuyerValidations();
            StringBuilder sb = new StringBuilder();
            propertyList = buval.DeletefromCart(PropID);
            foreach (var k in propertyList)
            {
                sb.Append("Name: " + k.PropertyName + "\n");
                sb.Append("Type: " + k.PropertyType + "\n");
                sb.Append("Option :" + k.PropertyOption + "\n");
                sb.Append("Description :" + k.Description + "\n");
                sb.Append("Address :" + k.Address + "\n");
                sb.Append("Price: " + k.PriceRange + "\n");
                sb.Append("Intial Deposit: " + k.InitialDeposit + "\n");
                sb.Append("LandMark:" + k.Landmark + "\n");
                sb.Append("The Above Property will be Deleted from cart...!");

            }

            MessageBox.Show(sb.ToString());
            wp.Children.Remove(StackOFDetails);
        }
        #endregion

        #region add all cart properties dyanamically  to page..
        int onlyonce = 0;
        int removeIndex = -1;
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            BuyerValidations buval = new BuyerValidations();

            WrapPanel wp = new WrapPanel();


            // border for stackpanel
            Border myBorder1 = new Border();
            if (onlyonce == 0)
            {
                onlyonce++;

                myBorder1.Background = Brushes.Blue;
                myBorder1.BorderBrush = Brushes.Orange;
                myBorder1.BorderThickness = new Thickness(1);

                // fetching all the property data from DB 

                List<Property> propertyList = new List<Property>();
                propertyList = buval.showCart();

                foreach (var k in propertyList)
                {
                    StackPanel StackOFDetails = new StackPanel();
                    removeIndex++;
                    // Intializing the UI Controls...
                    Button btn = new Button();
                    Label lblPropname = new Label();
                    Label lblType = new Label();
                    Label lblPropOption = new Label();
                    Label lblPropDescription = new Label();
                    Label lblAddress = new Label();
                    Label lblPrice = new Label();
                    Label lblIntialdeposit = new Label();
                    Label lblLandMArk = new Label();


                    // Mapping the Property data with UI controls...
                    int propId = k.PropertyId;
                    lblPropname.Content = "Name: " + k.PropertyName;
                    lblType.Content = "Type: " + k.PropertyType;
                    lblPropOption.Content = "Option :" + k.PropertyOption;
                    lblPropDescription.Content = "Description :" + k.Description;
                    lblAddress.Content = "Address :" + k.Address;
                    lblPrice.Content = "Price: " + k.PriceRange;
                    lblIntialdeposit.Content = "Intial Deposit: " + k.InitialDeposit;

                    lblLandMArk.Content = "LandMark:" + k.Landmark;
                    btn.Content = "Delete From Cart";


                    // Appending All the UI Controls to stackpanel

                    StackOFDetails.Children.Add(lblPropname);
                    StackOFDetails.Children.Add(lblType);
                    StackOFDetails.Children.Add(lblPropOption);
                    StackOFDetails.Children.Add(lblPrice);
                    StackOFDetails.Children.Add(lblIntialdeposit);
                    StackOFDetails.Children.Add(lblLandMArk);

                    StackOFDetails.Children.Add(lblAddress);

                    StackOFDetails.Children.Add(lblPropDescription);


                    StackOFDetails.Children.Add(btn);

                    wp.Children.Add(StackOFDetails);

                    // ConfirmCart method will be called and name will be passed to same method...

                    btn.Click += (s, RoutedEventArgs) => { ConfirmCart(sender, e, propId, StackOFDetails, wp); };

                }



                // Adding stackpanel to the WrapPanel...
                MyWrapPanel.Children.Add(wp);
                MyWrapPanel.Children.Add(myBorder1);
            }

            else
            {
                MessageBox.Show("We have listed all the properties in the Cart...!");


                // MyWrapPanel.Children.Remove(wp);
                // MyWrapPanel.Children.Remove(myBorder1);
                // btnShow_Click(sender, e);

            }

        }
        #endregion

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Login.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
