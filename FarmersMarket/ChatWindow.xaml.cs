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
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
		private Chat currentChat;

		public ChatWindow(Chat chat)
        {
            InitializeComponent();
			currentChat = chat;
        }

		private void sendMessageBtnClicked(object sender, RoutedEventArgs e)
		{
			FarmersMarketContext context = new FarmersMarketContext((Application.Current as App).ConnectionString);
			ChatService chatService = new ChatService(context);

			Message message = new Message
			{
				Value = messageTB.Text
			};

			chatService.AddMessage(currentChat, message);
		}
	}
}
