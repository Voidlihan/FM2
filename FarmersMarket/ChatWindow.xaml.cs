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
using FarmersMarket.DataAccess;
using FarmersMarket.Domain;

namespace FarmersMarket
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public static List<Message> messages;
        public ChatWindow()
        {
            InitializeComponent();
        }

        private void EnterButton(object sender, RoutedEventArgs e)
        {
            Button buttonEnter = new Button();
            Message message = new Message
            {
                Value = textBoxChat.Text,
                userChat = (Application.Current as App).currentUser
            };
            using (var context = new FarmersMarketContext("Server=A-104-09;Database=FarmersMarket;Trusted_Connection=True;"))
            {             
                while (true)
                {
                    Console.Clear();
                    messages = context.Messages.OrderBy(x => x.CreationDate).TakeLast(100).ToList();

                    foreach (var oneMessage in messages)
                    {
                        Console.WriteLine($"({oneMessage.CreationDate}) {oneMessage.userChat.Login}: {oneMessage.Value}");
                    }

                    textBoxChat.Text = Console.ReadLine();

                    if (textBoxChat.Text == "/r")
                    {
                        continue;
                    }

                    context.Add(message);
                    context.SaveChanges();
                }
            }

        }
    }
}
