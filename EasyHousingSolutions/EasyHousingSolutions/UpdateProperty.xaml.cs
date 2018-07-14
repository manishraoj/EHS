using EasyHousingSolutions_BLL;
using EasyHousingSolutions_Entity;
using System.Windows;
using System.Windows.Controls;

namespace EasyHousingSolutions
{
    /// <summary>
    /// Interaction logic for UpdateProperty.xaml
    /// </summary>
    public partial class UpdateProperty : Page
    {
        SellerValidations sv = new SellerValidations();
        Property prp = null;
        public UpdateProperty()
        {
            InitializeComponent();
            
        }
        int propId = 0;
        int sellerId = 0;
        public UpdateProperty(int prop_Id,int seller_Id):this()
        {
            propId = prop_Id;
            sellerId = seller_Id;
            this.Loaded += new RoutedEventHandler(SellerPage_Loaded);
        }
        
        void SellerPage_Loaded(object sender, RoutedEventArgs e)
        {
           
            prp = sv.GetProp(propId);

            txtAddress.Text = prp.Address;
            txtDeposit.Text = prp.InitialDeposit.ToString();
            txtDesc.Text = prp.Description;
            txtLandMark.Text = prp.Landmark;
            txtPrice.Text = prp.PriceRange.ToString();
            txtPropName.Text = prp.PropertyName;

            if (prp.PropertyType == "Flat")
                radFlat.IsChecked = true;
            else if (prp.PropertyType == "Villa")
                radHouse.IsChecked = true;
            else if (prp.PropertyType == "Office")
                radOffice.IsChecked = true;


            if (prp.PropertyOption== "Rent")
                radRent.IsChecked = true;
            else if (prp.PropertyOption == "Sell")
                radSell.IsChecked = true;  

            cmbState.ItemsSource = sv.Get_State(prp.StateId);
            cmbState.DisplayMemberPath = "StateName";
            cmbState.SelectedIndex = 0;
            
            cmbCity.ItemsSource = sv.Get_City(prp.CityId);
            cmbCity.DisplayMemberPath = "CityName";
            cmbCity.SelectedIndex = 0;

        }
        private void cmbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            State state = (State)cmbState.SelectedItem;

            cmbCity.ItemsSource = sv.GetCities(state.StateId);
            cmbCity.DisplayMemberPath = "CityName";
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
           
            prp.Address = txtAddress.Text;
            prp.PropertyName = txtPropName.Text;
            prp.SellerId = sellerId;

            string prpOpt = "";
            if (radRent.IsChecked == true)
                prpOpt = "Rent";
            else if (radSell.IsChecked == true)
                prpOpt = "Sell";


            prp.PropertyOption = prpOpt;


            string prpType = "";
            if (radFlat.IsChecked == true)
                prpType = "Flat";
            else if (radOffice.IsChecked == true)
                prpType = "Office";
            else if (radHouse.IsChecked == true)
                prpType = "Villa";

            prp.PropertyType = prpType;

            prp.PriceRange = decimal.Parse(txtPrice.Text);
            if (txtDeposit.Text == "")
                prp.InitialDeposit = 0;
            else
            prp.InitialDeposit = decimal.Parse(txtDeposit.Text);
            prp.Landmark = txtLandMark.Text;

            sv.UpdateProperty(prp);

            MessageBox.Show("Property updated successfully");
            SellerPage sp = new SellerPage(sellerId);
            this.NavigationService.Navigate(sp);

        }
    }
}
