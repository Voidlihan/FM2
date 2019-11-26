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
	/// Логика взаимодействия для AddProductWindow.xaml
	/// </summary>
	public partial class AddProductWindow : Window
	{
		public AddProductWindow()
		{
			InitializeComponent();

			FarmersMarketContext context = new FarmersMarketContext((Application.Current as App).ConnectionString);
			CategoryService categoryService = new CategoryService(context);
			categoriesList.ItemsSource = categoryService.GetAll();
		}

		private void categoriesListSelected(object sender, SelectionChangedEventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			Category selectedCategory = (Category)comboBox.SelectedItem;

			FarmersMarketContext context = new FarmersMarketContext((Application.Current as App).ConnectionString);
			ProductService productService = new ProductService(context);
			productsList.ItemsSource = productService.GetAllByCategory(selectedCategory);
		}

		private void addProductClicked(object sender, RoutedEventArgs e)
		{
			FarmersMarketContext context = new FarmersMarketContext((Application.Current as App).ConnectionString);
			ProfileService profileService = new ProfileService(context);
			SellerProductService sellerProductService = new SellerProductService(context);
			if (sellerProductService.AddSellerProduct((Product)productsList.SelectedItem, profileService.GetSeller((Application.Current as App).currentUser), Int32.Parse(quantityTB.Text), Int32.Parse(priceTB.Text), descriptionTB.Text, nameTB.Text) != null)
			{
				MessageBox.Show("Товар успешно добавлен");
				this.Close();
				return;
			}
			else
			{
				MessageBox.Show("Необходимо заполнить все поля!");
				return;
			}
		}

		private void cancelClicked(object sender, RoutedEventArgs e)
		{

		}
	}
}
