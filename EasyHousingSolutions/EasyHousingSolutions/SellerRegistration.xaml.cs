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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class SellerRegistration : Page
    {
        SellerValidations sellerObj = new SellerValidations();
        public SellerRegistration()
        {
            InitializeComponent();
            cmbState.ItemsSource = sellerObj.GetStates();
            cmbState.DisplayMemberPath = "StateName";
            cmbState.SelectedIndex = 0;


           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersValidations userObj = new UsersValidations();

                Seller seller = new Seller();
                User newUser = new User();

                seller.Address = txtAddress.Text;
                City city = (City)cmbCity.SelectedItem;
                seller.CityId = city.CityId;
                State state = (State)cmbState.SelectedItem;
                seller.StateId = state.StateId;

                seller.DateofBirth = DateTime.Now;
                seller.EmailId = txtEmail.Text;
                seller.FirstName = txtFirstName.Text;
                seller.LastName = txtLastName.Text;
                // seller.Password = txtPass.Text;
                seller.PhoneNo = txtPhoneNo.Text;
                seller.UserName = txtUserName.Text;


                newUser.Password = txtPass.Text;
                newUser.UserName = seller.UserName;
                newUser.UserType = "Seller";


                sellerObj.AddSeller(seller);
                userObj.AddUser(newUser);



                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new Uri("Login.xaml", UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Invalid Details");
            }

        }



        private void cmbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            State state = (State)cmbState.SelectedItem;

            cmbCity.ItemsSource = sellerObj.GetCities(state.StateId);
            cmbCity.DisplayMemberPath = "CityName";
            cmbCity.SelectedIndex = 0;
        }

        
    }
}