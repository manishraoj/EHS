using EasyHousingSolutions_BLL;
using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
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
    /// Interaction logic for PostProperty.xaml
    /// </summary>
    public partial class PostProperty : Page
    {
        SellerValidations sellerObj = new SellerValidations();
        public PostProperty()
        {
            InitializeComponent();
            cmbState.ItemsSource = sellerObj.GetStates();
            cmbState.DisplayMemberPath = "StateName";
            //var navWindow = Window.GetWindow(this) as NavigationWindow;
            //if (navWindow != null) navWindow.ShowsNavigationUI = false;
        }



        int sellerId = 0;

        public PostProperty(int val) : this()
        {
            sellerId = val;
            this.Loaded += new RoutedEventHandler(PostProperty_Loaded);

        }
        void PostProperty_Loaded(object sender, RoutedEventArgs e)
        {
            //   lblAddress.Content = sellerId.ToString();
        }

     

        private void cmbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            State state = (State)cmbState.SelectedItem;

            cmbCity.ItemsSource = sellerObj.GetCities(state.StateId);
            cmbCity.DisplayMemberPath = "CityName";
        }

        private void radRent_Checked(object sender, RoutedEventArgs e)
        {

            if (radRent.IsChecked == true)
                txtDeposit.IsEnabled = true;
        }

        private void radSell_Checked(object sender, RoutedEventArgs e)
        {
            if (radSell.IsChecked == true)
                txtDeposit.IsEnabled = false;
            //txtDeposit.Text = "0";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
       //    txtDeposit.IsEnabled = false;
        }

        private void cmbState_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            State state = (State)cmbState.SelectedItem;

            cmbCity.ItemsSource = sellerObj.GetCities(state.StateId);
            cmbCity.DisplayMemberPath = "CityName";
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Property newProp = new Property();
                newProp.Address = txtAddress.Text;
                newProp.PropertyName = txtPropName.Text;
                newProp.SellerId = sellerId;

                string prpOpt = "";
                if (radRent.IsChecked == true)
                    prpOpt = "Rent";
                else if (radSell.IsChecked == true)
                    prpOpt = "Sell";


                newProp.PropertyOption = prpOpt;


                string prpType = "";
                if (radFlat.IsChecked == true)
                    prpType = "Flat";
                else if (radOffice.IsChecked == true)
                    prpType = "Office";
                else 
                    prpType = "Villa";

                newProp.PropertyType = prpType;

                newProp.PriceRange = decimal.Parse(txtPrice.Text);
                newProp.InitialDeposit = decimal.Parse(txtDeposit.Text);
                newProp.Landmark = txtLandMark.Text;

                City city = (City)cmbCity.SelectedItem;
                newProp.CityId = city.CityId;
                State state = (State)cmbState.SelectedItem;
                newProp.StateId = state.StateId;

                sellerObj.AddProperty(newProp);

                MessageBox.Show("Property added successfully");
                SellerPage sp = new SellerPage(sellerId);
                this.NavigationService.Navigate(sp);
            }
            catch (SellerException ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
            catch (Exception)
            {

                MessageBox.Show("Enter all details ", "Alert");
            }

        }

        private void radFlat_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cmbState_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            State state = (State)cmbState.SelectedItem;

            cmbCity.ItemsSource = sellerObj.GetCities(state.StateId);
            cmbCity.DisplayMemberPath = "CityName";
        }

        private void radSell_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
