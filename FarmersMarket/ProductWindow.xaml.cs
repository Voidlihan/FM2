using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using FarmersMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
	/// Interaction logic for ProductWindow.xaml
	/// </summary>
	public partial class ProductWindow : Window
	{
		private Guid SellerId { get; set; }

		public ProductWindow(Guid SellerProductId)
		{
			InitializeComponent();
			SellerId = SellerProductId;
		}

		private void writeToSellerClicked(object sender, RoutedEventArgs e)
		{
			FarmersMarketContext context = new FarmersMarketContext((Application.Current as App).ConnectionString);
			ChatService chatService = new ChatService(context);
			ProfileService profileService = new ProfileService(context);

			Chat chat;
			if ((Application.Current as App).currentUser == null)
			{
				MessageBox.Show("Вы не авторизованы в системе");
				return;
			}
			if (chatService.Get(SellerId, profileService.GetCustomer((Application.Current as App).currentUser).Id) == null) // Если чата нет
			{
				chat = new Chat
				{
					SellerId = SellerId,
					CustomerId = profileService.GetCustomer((Application.Current as App).currentUser).Id
				};
				chatService.Create(chat.SellerId, chat.CustomerId);
			}
			else // если чат есть
			{
				chat = chatService.Get(SellerId, profileService.GetCustomer((Application.Current as App).currentUser).Id);
			}

			ChatWindow chatWindow = new ChatWindow(chat);
			chatWindow.ShowDialog();
		}

		private void ButtonAddToCart(object sender, RoutedEventArgs e)
		{
			using (var context = new FarmersMarketContext((Application.Current as App).ConnectionString))
			{
				var cartService = new CartService(context);
				var sellerProduct = context.SellerProducts.SingleOrDefault(product => product.Id == SellerId);
				var customer = context.Customers.SingleOrDefault(user => user.UserId == (Application.Current as App).currentUser.Id);


				var cart = new Cart
				{
					SellerProduct = sellerProduct,
					Customer = customer,
					Count = sellerProduct.Count
				};
				cartService.AddProductToCart(cart);
			}
			MessageBox.Show("Товар добавлен в корзину");
		}
	}
}