using System;
using System.Collections.Generic;

namespace FarmersMarket.Domain
{
	public class Seller : Entity
	{
		public Guid UserId { get; set; }
		public virtual User User { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public virtual ICollection<SellerProduct> Products { get; set; }
		public virtual ICollection<Rating> Ratings { get; set; }
		public virtual ICollection<Chat> Chats { get; set; }
	}
}