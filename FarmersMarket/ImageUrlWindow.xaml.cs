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
		static FarmersMarketContext context = new FarmersMarketContext("Server=BorisHOME\\Boris;Database=FarmersMarket;Trusted_Connection=True;");
		static ProfileService profileService = new ProfileService(context);


		public ImageUrlWindow()
		{
			InitializeComponent();
		}

		private void LoadClick(object sender, RoutedEventArgs e)
		{
			profileService.UpdateImage(imageUrl.Text, (Application.Current as App).currentUser);
		}
	}
}
