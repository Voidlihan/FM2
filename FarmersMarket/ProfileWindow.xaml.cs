using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using FarmersMarket.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FarmersMarket
{
    /// <summary>
    /// Interaction logic for WindowProfile.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
		static FarmersMarketContext context = new FarmersMarketContext("Server=A-104-09;Database=FarmersMarket;Trusted_Connection=True;");
		static ProfileService profileService = new ProfileService(context);

		public ProfileWindow()
        {
            InitializeComponent();
		}

		private void saveChangesButtonClick(object sender, RoutedEventArgs e)
		{
			Customer customer = new Customer
			{
                User = (Application.Current as App).currentUser,
                FirstName = userFirstName.Text,
				LastName = userLastName.Text,
				Address = userAddress.Text
			};
			profileService.UpdateProfile(customer, (Application.Current as App).currentUser);			
		}

		private void downloadImageClick(object sender, RoutedEventArgs e)
		{
			ImageUrlWindow imageUrlWindow = new ImageUrlWindow();
			imageUrlWindow.Show();
		}
	}
}
