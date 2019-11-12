using System.Collections.Generic;

namespace FarmersMarket.Domain
{
	public class Chat : Entity
	{
		public Profile Seller { get; set; }
		public Profile Customer { get; set; }
		public virtual ICollection<Message> Messages { get; set; }
	}
}