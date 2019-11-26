using System;
using System.Collections.Generic;

namespace FarmersMarket.Domain
{
	public class Chat : Entity
	{
		public Guid SellerId { get; set; }
		public virtual Seller Seller { get; set; }
		public Guid CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual ICollection<Message> Messages { get; set; }
	}
}