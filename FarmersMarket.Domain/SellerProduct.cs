using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket.Domain
{
	public class SellerProduct : Entity
	{
		public Guid ProductId { get; set; }
		public virtual Product Product { get; set; }
		public Guid SellerId { get; set; }
		public virtual Seller Seller { get; set; }
		public int Count { get; set; }
		public int Price { get; set; }
		public string Description { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }

		public override string ToString()
        {
            return Id.ToString();
        }
    }
}
