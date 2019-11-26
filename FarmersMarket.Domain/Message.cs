using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket.Domain
{
	public class Message : Entity
	{
		public Guid ChatId { get; set; }
		public virtual Chat Chat { get; set; }
		public string Value { get; set; }
	}
}
