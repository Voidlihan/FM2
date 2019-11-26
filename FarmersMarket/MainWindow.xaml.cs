using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using FarmersMarket.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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
		//static FarmersMarketContext context = new FarmersMarketContext(Constants.ConnectionString);
		//static ProfileService profileService = new ProfileService(context);

		//private const string CONNECTION_STRING = "Server=;Database=;Trusted_Connection=TRUE;";

		public MainWindow()
		{
			InitializeComponent();

			ListBoxCategories();
        }

		private void ListBoxCategories()
		{
            using (var _context = new FarmersMarketContext((Application.Current as App).ConnectionString))
            {
                CategoryService categoryService = new CategoryService(_context);
                listBoxCategories.ItemsSource = categoryService.GetAll();
            }
		}

		private void SearchBtnClicked(object sender, RoutedEventArgs e)
		{

		}

		private void searchBNClick(object sender, RoutedEventArgs e)
		{
			using (var context = new FarmersMarketContext((Application.Current as App).ConnectionString))
			{
				Search search = new Search();
				var products = search.FindOfProduct(searchTB.Text, 10, context);
				// добавить вывод как лист в xaml-е

			}
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
			using (var _context = new FarmersMarketContext((Application.Current as App).ConnectionString))
			{
				ProfileService _profileService = new ProfileService(_context);

				if (_profileService.GetCustomer((Application.Current as App).currentUser) != null)
				{
					Customer currentCustomer = _profileService.GetCustomer((Application.Current as App).currentUser);
					CustomerProfileWindow customerProfileWindow = new CustomerProfileWindow();
					customerProfileWindow.userFirstName.Text = currentCustomer.FirstName;
					customerProfileWindow.userLastName.Text = currentCustomer.LastName;
					customerProfileWindow.userAddress.Text = currentCustomer.Address;
					customerProfileWindow.Show();
				}
				else
				{
					Seller currentSeller = _profileService.GetSeller((Application.Current as App).currentUser);
					SellerProfileWindow sellerProfileWindow = new SellerProfileWindow();
					sellerProfileWindow.userFirstName.Text = currentSeller.FirstName;
					sellerProfileWindow.userLastName.Text = currentSeller.LastName;
					sellerProfileWindow.userAddress.Text = currentSeller.Address;
					sellerProfileWindow.Show();
				}
			}
		}

		private void listBoxCategoriesCategoryClicked(object sender, MouseButtonEventArgs e)
		{
			var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
			if (item != null)
			{
                using (var _context = new FarmersMarketContext((Application.Current as App).ConnectionString))
                {
                    var sellerProductService = new SellerProductService(_context);
                    var sellerProducts = sellerProductService.ShowSellerProducts(item.Content.ToString());
                    listBoxProductSellers.ItemsSource = sellerProducts;
                }
			}
		}

		private void listBoxProductSellersProductClicked(object sender, MouseButtonEventArgs e)
		{
			var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
			if (item != null)
			{
				using (var _context = new FarmersMarketContext((Application.Current as App).ConnectionString))
				{
					var sellerProductService = new SellerProductService(_context);
					var sellerProduct = sellerProductService.GetSellerProduct(item.Content.ToString());
					ProductWindow productWindow = new ProductWindow(Guid.Parse(item.Content.ToString()));
					productWindow.name.Text = sellerProduct.Name;
					productWindow.price.Text = sellerProduct.Price.ToString();
					productWindow.quantity.Text = sellerProduct.Count.ToString();
					productWindow.ShowDialog();
				}
			}
		}
	}
}
