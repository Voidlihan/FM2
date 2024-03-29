﻿using FarmersMarket.DataAccess;
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
	/// Interaction logic for SignUpWindow.xaml
	/// </summary>
	public partial class SignUpWindow : Window
	{
		private MainWindow mainWindow;

		public SignUpWindow(MainWindow mainWin)
		{
			InitializeComponent();
			mainWindow = mainWin;
		}

		private void SignUpButtonClicked(object sender, RoutedEventArgs e)
		{
			if (customerRB.IsChecked == true)
			{
				Customer customer = new Customer
				{
					UserId = (Application.Current as App).currentUser.Id,
					FirstName = userFirstName.Text,
					LastName = userLastName.Text,
					Address = userAddress.Text
				};

				using (var context = new FarmersMarketContext((Application.Current as App).ConnectionString))
				{
					ProfileService profileService = new ProfileService(context);
					profileService.Add(customer);
				}

			}
			else if (sellerRB.IsChecked == true)
			{
				Seller seller = new Seller
				{
					UserId = (Application.Current as App).currentUser.Id,
					FirstName = userFirstName.Text,
					LastName = userLastName.Text,
					Address = userAddress.Text
				};

				using (var context = new FarmersMarketContext((Application.Current as App).ConnectionString))
				{
					ProfileService profileService = new ProfileService(context);
					profileService.Add(seller);
				}
			}
			else
			{
				MessageBox.Show("Выберите вашу роль");
				return;
			}
			MessageBox.Show("Аккаунт успешно зарегестрирован.");
			this.Close();
			mainWindow.profileButton.Visibility = Visibility.Visible;
			mainWindow.cartButton.Visibility = Visibility.Visible;
			mainWindow.signInButton.Visibility = Visibility.Collapsed;
		}
	}
}
