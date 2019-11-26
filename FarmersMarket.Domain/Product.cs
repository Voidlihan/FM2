using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket.Domain
{
	public class Product : Entity
	{
		public string Name { get; set; }
		public Guid CategoryId { get; set; }
		public virtual Category Category { get; set; }
		public virtual ICollection<SellerProduct> Sellers { get; set; } // Не уверен в необходимости этой части

		public override string ToString()
		{
			return Name;
		}
	}
}
