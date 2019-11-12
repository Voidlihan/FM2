using System.Collections.Generic;

namespace FarmersMarket.Domain
{
	public class Category : Entity
	{
		public string Name { get; set; } 
		public virtual ICollection<FavoriteCategories> Customers { get; set; } // Не уверен в необходимости этой части
	}
}