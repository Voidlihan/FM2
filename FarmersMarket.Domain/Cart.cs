using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket.Domain
{
	public class Cart : Entity
	{
		public virtual Customer Customer { get; set; }
		public virtual SellerProduct SellerProduct { get; set; }
		public int Count { get; set; }
		// Цена не нужна, т.к. цена находится в самом товаре (SellerProduct)
	}
}
