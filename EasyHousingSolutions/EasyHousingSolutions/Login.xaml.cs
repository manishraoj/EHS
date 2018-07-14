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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
           // this.ShowsNavigationUI = false;
        }



        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("SellerRegistration.xaml", UriKind.RelativeOrAbsolute));

        }

        private void btnBuyerRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("BuyerRegistration.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User login = new User();
                UsersValidations userObj = new UsersValidations();
                SellerValidations sellerObj = new SellerValidations();
                BuyerValidations buyerObj = new BuyerValidations();

                login.UserName = txtUserName.Text;
                login.Password = txtPass.Password;



                login = userObj.LoginUser(login);

                if (login != null)
                {
                    if (login.UserType.ToLower() == "admin")
                    {
                        Admin sp = new Admin();
                        this.NavigationService.Navigate(sp);
                    }
                    else if (login.UserType.ToLower() == "seller")
                    {
                        int sellerId = sellerObj.SellerId(login.UserName);
                        SellerPage sp = new SellerPage(sellerId);
                        this.NavigationService.Navigate(sp);
                    }
                    else if (login.UserType.ToLower() == "buyer")
                    {


                        int buyerId = buyerObj.BuyerId(login.UserName);
                        ShowAllProperties_Buyer sp = new ShowAllProperties_Buyer(buyerId);
                        this.NavigationService.Navigate(sp);
                    }
                    MessageBox.Show("Login Successful!!");
                }
                else
                {
                    txtUserName.Text = "";
                    txtPass.Password = "";
                    throw new UserException("UserName/Password is required");
                    

                }
            }
            catch (UserException ex)
            {

                MessageBox.Show(ex.Message, "Alert");
            }

        }
    }
}
