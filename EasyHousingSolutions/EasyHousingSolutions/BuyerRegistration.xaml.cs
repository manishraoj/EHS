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
    /// Interaction logic for BuyerRegistration.xaml
    /// </summary>
    public partial class BuyerRegistration : Page
    {
        public BuyerRegistration()
        {
            InitializeComponent();
        }

        #region Add buyer to databse...
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            UsersValidations userObj = new UsersValidations();
            User newUser = new User();
            BuyerValidations buval = new BuyerValidations();
            Buyer buyer = new Buyer();
            buyer.UserName = txtName.Text;
            buyer.FirstName = txtFName.Text;
            buyer.LastName = txtLName.Text;
            buyer.DateOfBirth = dob.SelectedDate.Value;
            buyer.PhoneNo = txtNumber.Text;
            buyer.EmailId = txtEmail.Text;

            string x = txtPassword.Password;

            newUser.Password = x;
            newUser.UserName = buyer.UserName;
            newUser.UserType = "Buyer";
            buval.AddBuyer(buyer);
            userObj.AddUser(newUser);



            MessageBox.Show("Buyer added successfully");
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Login.xaml", UriKind.RelativeOrAbsolute));


        }
        #endregion

    }
}
