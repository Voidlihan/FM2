using System.Collections.Generic;

namespace FarmersMarket.Domain
{
	public class Seller : Entity
	{
		public User User { get; set; }
		public string FullName { get; set; }
		public string Location { get; set; }
		public virtual ICollection<SellerProduct> Products { get; set; }
		public virtual ICollection<Rating> Ratings { get; set; }
		public virtual ICollection<Chat> Chats { get; set; }
	}
}