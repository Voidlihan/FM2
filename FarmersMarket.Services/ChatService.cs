using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersMarket.Services
{
	public class ChatService
	{
		private readonly FarmersMarketContext context;

		public ChatService(FarmersMarketContext context)
		{
			this.context = context;
		}

		public Chat Get(Guid SellerId, Guid CustomerId)
		{
			return context.Chats.Where(chat => chat.SellerId == SellerId && chat.CustomerId == CustomerId).FirstOrDefault<Chat>();
		}

		public void AddMessage(Chat chat, Message message)
		{
			message.ChatId = chat.Id;
			context.Messages.Add(message);
			context.SaveChanges();
		}

		public void Create(Guid SellerId, Guid CustomerId)
		{
			Chat chat = new Chat
			{
				SellerId = SellerId,
				CustomerId = CustomerId
			};
			context.Add(chat);
			context.SaveChanges();
		}
	}
}
