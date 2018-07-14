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
    /// Interaction logic for SellerPage.xaml
    /// </summary>
    public partial class SellerPage : Page
    {
        public SellerPage()
        {
            InitializeComponent();
        }
        int sellerId = 0;

        public SellerPage(int val) : this()
        {
            sellerId = val;
            this.Loaded += new RoutedEventHandler(SellerPage_Loaded);

        }
        void SellerPage_Loaded(object sender, RoutedEventArgs e)
        {
            SellerValidations vf = new SellerValidations();
            dgViewprop.ItemsSource = vf.viewProp(sellerId);
        }
        void EditProp(object sender, EventArgs e, int PropID)
        {

            MessageBox.Show(PropID.ToString());
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            SellerValidations vf = new SellerValidations();
            dgViewprop.ItemsSource = vf.viewProp(sellerId);
        }

        private void btnVerify_Click(object sender, RoutedEventArgs e)
        {
            SellerValidations vf = new SellerValidations();
            dgViewprop.ItemsSource = vf.viewProp(sellerId, true);
        }

        private void btnDeactivate_Click(object sender, RoutedEventArgs e)
        {
            SellerValidations vf = new SellerValidations();
            bool? b = null;
            dgViewprop.ItemsSource = vf.viewProp(sellerId, b);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PostProperty sp = new PostProperty(sellerId);
            this.NavigationService.Navigate(sp);
        }

        private void dgViewprop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Property pro = (Property)dgViewprop.SelectedItem;
            int propId = pro.PropertyId;
            UpdateProperty sp = new UpdateProperty(propId, sellerId);
            this.NavigationService.Navigate(sp);
        }
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Login.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
