using System.Collections.Generic;

namespace FarmersMarket.Domain
{
	public class Customer : Entity
	{
		public User User { get; set; }
		public string FullName { get; set; }
		public string Location { get; set; } 
		public virtual ICollection<FavoriteCategories> Categories { get; set; } // избранные категории, назвал по другому для лучшего понимания БД
		public virtual ICollection<Cart> Carts { get; set; } // у покупателя может быть много товаров в корзине
	}
}