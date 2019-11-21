using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket.Domain
{
	public class Message : Entity
	{
		public Chat Chat { get; set; }
		public string Value { get; set; }
        public virtual User userChat { get; set; }
	}
}
