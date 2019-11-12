using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket.Domain
{
	public class User : Entity
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public bool IsAdmin { get; set; }
	}
}
