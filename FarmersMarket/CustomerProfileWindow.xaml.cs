using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using FarmersMarket.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
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
	public partial class CustomerProfileWindow : Window
	{
        public const string ADDRESS = "https://geocode-maps.yandex.ru/1.x/?apikey=1a91931f-aa17-48e4-838e-29d4f26ba796&format=json&geocode=*";

        public CustomerProfileWindow()
		{
			InitializeComponent();
		}

		private void saveChangesButtonClick(object sender, RoutedEventArgs e)
		{
			FarmersMarketContext context = new FarmersMarketContext((Application.Current as App).ConnectionString);
			ProfileService profileService = new ProfileService(context);
			Customer customer = new Customer
			{
				User = (Application.Current as App).currentUser,
				FirstName = userFirstName.Text,
				LastName = userLastName.Text,
				Address = userAddress.Text
			};
			profileService.UpdateProfile(customer, (Application.Current as App).currentUser);
			MessageBox.Show("Данные успешно сохранены");
			this.Close();
		}

		private void downloadImageClick(object sender, RoutedEventArgs e)
		{
			ImageUrlWindow imageUrlWindow = new ImageUrlWindow();
			imageUrlWindow.Show();
		}

        private void CheckAddress(object sender, MouseButtonEventArgs e)
        {
            if (!userAddress.Text.CheckOnElements('+'))
            {
                MessageBox.Show("Адрес не правильно написано. (Город+Адрес+Дом)");
            }
            else
            {
                WebClient web = new WebClient();
                string save = userAddress.Text;
                string tok = userAddress.Text.Replace(',', '+');
                string replace = "*";
                int IndexFirst = ADDRESS.IndexOf(replace);
                string address = ADDRESS.Remove(IndexFirst, replace.Length).Insert(IndexFirst, tok);
                string json = web.DownloadString(address);

                TestAddressa.RootObject response = JsonConvert.DeserializeObject<TestAddressa.RootObject>(json);

                int size;
                int.TryParse(response.Response.GeoObjectCollection.metaDataProperty.GeocoderResponseMetaData.found, out size);

                string[] menu = new string[size];

                int i = 0;
                foreach (var item in response.Response.GeoObjectCollection.featureMember)
                {
                    menu[i] = item.GeoObject.metaDataProperty.GeocoderMetaData.text;
                    i++;
                }

                addressMenuItem.Visibility = Visibility.Visible;
                addressMenuItem.ItemsSource = menu;

                var chooseItem = ItemsControl.ContainerFromElement(sender as Menu, e.OriginalSource as DependencyObject) as MenuItem;
                if(chooseItem != null)
                {
                    MessageBox.Show(chooseItem.Header.ToString());
                }
            }
        }
    }
}
