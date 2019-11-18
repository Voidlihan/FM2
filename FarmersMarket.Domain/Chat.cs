using System.Collections.Generic;

namespace FarmersMarket.Domain
{
	public class Chat : Entity
	{
		public Customer Seller { get; set; }
		public Customer Customer { get; set; }
		public virtual ICollection<Message> Messages { get; set; }
	}
}