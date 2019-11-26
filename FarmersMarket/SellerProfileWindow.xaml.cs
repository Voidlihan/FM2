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
	/// Логика взаимодействия для SellerProfileWindow.xaml
	/// </summary>
	public partial class SellerProfileWindow : Window
	{
		public SellerProfileWindow()
		{
			InitializeComponent();
		}

		private void saveChangesButtonClick(object sender, RoutedEventArgs e)
		{
            using (FarmersMarketContext context = new FarmersMarketContext((Application.Current as App).ConnectionString))
            {
                ProfileService profileService = new ProfileService(context);
                Seller seller = new Seller
                {
                    User = (Application.Current as App).currentUser,
                    FirstName = userFirstName.Text,
                    LastName = userLastName.Text,
                    Address = userAddress.Text
                };
                profileService.UpdateProfile(seller, (Application.Current as App).currentUser);
                MessageBox.Show("Данные успешно сохранены");
            }
		}

		private void downloadImageClick(object sender, RoutedEventArgs e)
		{
			ImageUrlWindow imageUrlWindow = new ImageUrlWindow();
			imageUrlWindow.Show();
		}

		private void AddProductClick(object sender, RoutedEventArgs e)
		{
			AddProductWindow addProductWindow = new AddProductWindow();
			addProductWindow.ShowDialog();
		}
	}
}
