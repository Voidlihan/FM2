using FarmersMarket.DataAccess;
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
    /// Interaction logic for CartWindows.xaml
    /// </summary>
    public partial class CartWindows : Window
    {
        //нужно connection string добавить 
        public CartWindows()
        {
            InitializeComponent();

            using (var context = new FarmersMarketContext((Application.Current as App).ConnectionString))
            {
                LBCarts.ItemsSource = context.Carts;
            }
            //Нужно доработать вывод продуктов
        }
    }
}
