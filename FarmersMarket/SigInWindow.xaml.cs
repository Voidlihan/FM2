using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using FarmersMarket.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class SignInWindow : Window
	{
		private MainWindow mainWindow;
		static FarmersMarketContext context = new FarmersMarketContext("Server=A-104-09;Database=FarmersMarket;Trusted_Connection=True;");
		static AuthService authService = new AuthService(context);
		static ProfileService profileService = new ProfileService(context);

		public SignInWindow(MainWindow mainWin)
		{
			InitializeComponent();
			mainWindow = mainWin;
		}

		private void SignUpButtonClick(object sender, RoutedEventArgs e)
		{



			if (!authService.isExist(loginSignIn.Text))
			{
				(Application.Current as App).currentUser = authService.SignUp(loginSignIn.Text, passwordSignIn.Password);
				if ((Application.Current as App).currentUser == null)
				{
					MessageBox.Show("Введен неверный формат почты или слишком короткий пароль. Аккаунт не зарегестрирован");
					return;
				}
				else
				{
					SignUpWindow signUpWindow = new SignUpWindow();
					signUpWindow.Show();
					this.Close();
				}
			}
			else
			{
				MessageBox.Show("Пользователь уже существует");
			}
		}

		private void SignInButtonClick(object sender, RoutedEventArgs e)
		{

			//IConfigurationBuilder builder = new ConfigurationBuilder()
			//		.SetBasePath(Directory.GetCurrentDirectory())
			//		.AddJsonFile("appsettings.json", false, true);

			//IConfigurationRoot configurationRoot = builder.Build();

			//string connectionString = configurationRoot.GetConnectionString("MyConnectionString");

			if (authService.isExist(loginSignIn.Text))
			{
				(Application.Current as App).currentUser = authService.SignIn(loginSignIn.Text, passwordSignIn.Password);
				if ((Application.Current as App).currentUser == null)
				{
					MessageBox.Show("Неверный логин или пароль");
				}
				else
				{
					mainWindow.profileButton.Visibility = Visibility.Visible;
					mainWindow.cartButton.Visibility = Visibility.Visible;
					mainWindow.signInButton.Visibility = Visibility.Collapsed;
					this.Close();
				}
			}
			else // если пользователя не существует
			{
				MessageBox.Show("Пользователь не зарегестрирован");
				// тут перекинуть на окно регистрации с заполненными данными логина и пароля
			}
		}
	}
}
