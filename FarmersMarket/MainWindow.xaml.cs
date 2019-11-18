using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using FarmersMarket.Services;
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

namespace FarmersMarket
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		static FarmersMarketContext context = new FarmersMarketContext("Server=BorisHOME\\Boris;Database=FarmersMarket;Trusted_Connection=True;");
		static ProfileService profileService = new ProfileService(context);

		public MainWindow()
		{
			InitializeComponent();
		}

		private void SearchBtnClicked(object sender, RoutedEventArgs e)
		{

		}

		private void searchBNClick(object sender, RoutedEventArgs e)
		{

		}

		private void SignInClick(object sender, RoutedEventArgs e)
		{
			SignInWindow signIn = new SignInWindow(this);
			signIn.Show();
		}

		private void helpsClick(object sender, RoutedEventArgs e)
		{
			FAQWindow winFaq = new FAQWindow(this);
			winFaq.Show();
		}

		private void profileButtonClick(object sender, RoutedEventArgs e)
		{
			ProfileWindow profileWindow = new ProfileWindow();

			Customer currentCustomer = profileService.GetCustomer((Application.Current as App).currentUser);

			profileWindow.userFirstName.Text = currentCustomer.FirstName;
			profileWindow.userLastName.Text = currentCustomer.LastName;
			profileWindow.userAddress.Text = currentCustomer.Address;
			if (currentCustomer.ImagePath == null) { profileWindow.userImage.Source = new BitmapImage(new Uri("https://image.shutterstock.com/z/stock-vector-thin-line-user-icon-on-white-background-519039097.jpg", UriKind.Absolute)); }
			else { profileWindow.userImage.Source = new BitmapImage(new Uri(currentCustomer.ImagePath, UriKind.Absolute)); }
			;
			profileWindow.Show();
		}
	}
}
