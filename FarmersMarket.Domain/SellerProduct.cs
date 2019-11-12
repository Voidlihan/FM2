using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket.Domain
{
	public class SellerProduct : Entity
	{
		public virtual Product Product { get; set; }
		public virtual Seller Seller { get; set; }
		public int Count { get; set; }
		public int Price { get; set; }
	}
}
