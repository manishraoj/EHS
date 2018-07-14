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
    public class HouseDetails
    {
        public String OwnerName { get; set; }
        public int Price_ofH { get; set; }
        public String TypeOFH { get; set; }
    }
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {

        SellerValidations sellerObj = new SellerValidations();
        AdminValidations adminObj = new AdminValidations();
        int propId = 0;
        public Admin()
        {
            try
            {
                InitializeComponent();
                cmbState.ItemsSource = sellerObj.GetStates();
                cmbState.DisplayMemberPath = "StateName";
                cmbState.SelectedIndex = 0;
                cmbOption.SelectedIndex = 0;
                cmbOwnerId.ItemsSource = adminObj.GetOwners();
                cmbOwnerId.DisplayMemberPath = "SellerId";
                cmbOwnerId.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnAll_Click(object sender, RoutedEventArgs e)
        {

            dgViewprop.ItemsSource = adminObj.viewProp(string.Empty, string.Empty).ToList();
        }

        private void cmbState_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                State state = (State)cmbState.SelectedItem;
                cmbCity.ItemsSource = sellerObj.GetCities(state.StateId);
                cmbCity.SelectedIndex = 0;
                cmbCity.DisplayMemberPath = "CityName";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                State typeState = (State)cmbState.SelectedItem;
                City typeCity = (City)cmbCity.SelectedItem;

                //   MessageBox.Show(typeState.StateName + "  " + typeCity.CityName);

                if (cmbState.SelectedIndex.ToString() == "" && cmbCity.SelectedIndex.ToString() == "")
                    dgViewprop.ItemsSource = adminObj.viewProp(string.Empty, string.Empty).ToList();
                else if (cmbState.SelectedIndex.ToString() != "" && cmbCity.SelectedIndex.ToString() == "")
                    dgViewprop.ItemsSource = adminObj.viewProp(typeState.StateName, string.Empty).ToList();
                else if (cmbState.SelectedIndex.ToString() != "" && cmbCity.SelectedIndex.ToString() != "")
                    dgViewprop.ItemsSource = adminObj.viewProp(typeState.StateName, typeCity.CityName).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnSearchByOwner_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Seller typeSellerId = (Seller)cmbOwnerId.SelectedItem;

                dgViewprop.ItemsSource = adminObj.viewPropbyOwner(typeSellerId.SellerId, ((ComboBoxItem)cmbOption.SelectedItem).Content.ToString()).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Property prop = (Property)sellerObj.GetProp(propId);
                // txtDesc.Text = "Property Deleted";

                prop.Status_Description = "Property Deleted";
                sellerObj.UpdateProperty(prop);
                adminObj.verifyProperty(propId, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Select a Property", "Alert");
            }

        }

        private void dgViewprop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if (dgViewprop.SelectedItem != null)
                {
                    Property pro = (Property)dgViewprop.SelectedItem;
                    if (pro.PropertyId != null)
                    {
                        propId = pro.PropertyId;
                        Property prop = (Property)sellerObj.GetProp(propId);
                        if (pro.IsActive == true)
                        {
                            txtDesc.Text = prop.Status_Description;
                            txtDesc.IsReadOnly = true;
                        }

                        else if (pro.IsActive == false)
                        {
                            txtDesc.Text = prop.Status_Description;
                            txtDesc.IsReadOnly = true;
                        }
                        else
                        {
                            txtDesc.Text = prop.Status_Description;
                            txtDesc.IsReadOnly = false;
                        }
                    }
                    else
                        throw new AdminException("Select a Property");


                }
                else
                    throw new AdminException("Select a property");

            }
            catch (AdminException ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
            catch (Exception)
            {
                MessageBox.Show("Select a Property");
            }



        }

        private void btnDeactivate_Click(object sender, RoutedEventArgs e)
        {
            Property prop = (Property)sellerObj.GetProp(propId);
            prop.Status_Description = "Property is De-Activated";

            sellerObj.UpdateProperty(prop);
            adminObj.verifyProperty(propId, true);
            //txtDesc.Text = "Property is De-Activated";
        }

        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {
            Property prop = (Property)sellerObj.GetProp(propId);
            prop.Status_Description = "Property is Activated";

            sellerObj.UpdateProperty(prop);
            adminObj.verifyProperty(propId, false);
            // txtDesc.Text = "Property is Activated";
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Login.xaml", UriKind.RelativeOrAbsolute));

        }
    }
}
