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
	/// Логика взаимодействия для ImageUrlWindow.xaml
	/// </summary>
	public partial class ImageUrlWindow : Window
	{


		public ImageUrlWindow()
		{
			InitializeComponent();
		}

		private void LoadClick(object sender, RoutedEventArgs e)
		{
			using (var context = new FarmersMarketContext(Constants.ConnectionString))
			{
				ProfileService profileService = new ProfileService(context);
				profileService.UpdateImage(imageUrl.Text, (Application.Current as App).currentUser);
			}
			MessageBox.Show("Фотография успешно загружена");
			this.Close();
		}
	}
}
