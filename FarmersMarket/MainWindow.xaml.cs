using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using FarmersMarket.Services;
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
        static FarmersMarketContext context = new FarmersMarketContext("Server=A-104-09;Database=FarmersMarket;Trusted_Connection=True;");
        static ProfileService profileService = new ProfileService(context);

        private const string CONNECTION_STRING = "Server=;Database=;Trusted_Connection=TRUE;";

        public MainWindow()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", false, true);
            IConfigurationRoot configurationRoot = builder.Build();

            var connectionString = configurationRoot.GetConnectionString("MyConnectionString");
            new Constants(connectionString);

            InitializeComponent();

        }

        private void SearchBtnClicked(object sender, RoutedEventArgs e)
        {

        }

        private void searchBNClick(object sender, RoutedEventArgs e)
        {
            using (var context = new FarmersMarketContext(CONNECTION_STRING))
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
            using (var _context = new FarmersMarketContext("Server=A-104-12;Database=FarmersMarket;Trusted_Connection=True;"))
            {
                ProfileService _profileService = new ProfileService(_context);
                ProfileWindow profileWindow = new ProfileWindow();

                Customer currentCustomer = _profileService.GetCustomer((Application.Current as App).currentUser);

                profileWindow.userFirstName.Text = currentCustomer.FirstName;
                profileWindow.userLastName.Text = currentCustomer.LastName;
                profileWindow.userAddress.Text = currentCustomer.Address;

                profileWindow.Show();
            }
        }
    }
}
