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
    /// Interaction logic for ShowAllProperties_Buyer.xaml
    /// </summary>
    public partial class ShowAllProperties_Buyer : Page
    {
        public ShowAllProperties_Buyer()
        {
            InitializeComponent();
        }

        int buyerId = 0;

        public ShowAllProperties_Buyer(int val):this()
        {
            buyerId = val;
            this.Loaded += new RoutedEventHandler(ShowAllProperties_Buyer_Loaded);

        }
        void ShowAllProperties_Buyer_Loaded(object sender, RoutedEventArgs e)
        {
            // lblView.Content = sellerId.ToString();

        }

        #region add cart ...

        void ConfirmCart(object sender, EventArgs e, int PropID)
        {
            List<Property> propertyList = new List<Property>();
            BuyerValidations buval = new BuyerValidations();
            StringBuilder sb = new StringBuilder();
            buval.GetBuyerId(buyerId);
            propertyList = buval.AddToCart(PropID);
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
                sb.Append("The Above Property is Added to cart successfully...");

            }

            MessageBox.Show(sb.ToString());
        }
        #endregion

        #region add all properties dyanamically  to page..
        int onlyonce = 0;
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            BuyerValidations buval = new BuyerValidations();

            WrapPanel wp = new WrapPanel();

            Border myBorder1 = new Border();
            if (onlyonce == 0)
            {
                onlyonce++;
                // border for stackpanel

                myBorder1.Background = Brushes.Blue;
                myBorder1.BorderBrush = Brushes.Orange;
                myBorder1.BorderThickness = new Thickness(1);

                // fetching all the property data from DB 

                List<Property> propertyList = new List<Property>();
                propertyList = buval.showProperties();

                foreach (var k in propertyList)
                {
                    StackPanel StackOFDetails = new StackPanel();
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
                    btn.Content = "AddToCart";


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

                    btn.Click += (s, RoutedEventArgs) => { ConfirmCart(sender, e, propId); };


                }



                // Adding stackpanel to the WrapPanel...

                MyWrapPanel.Children.Add(wp);
                MyWrapPanel.Children.Add(myBorder1);



            }
            else
            {
                MessageBox.Show("We have listed all the data avialable....!");


            }
        }
        #endregion

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
           
            ViewBuyerCart sp = new ViewBuyerCart(buyerId);
            this.NavigationService.Navigate(sp);
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Login.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
