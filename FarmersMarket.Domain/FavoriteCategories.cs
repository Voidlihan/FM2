namespace FarmersMarket.Domain
{
	public class FavoriteCategories : Entity
	{
		public virtual Customer Customer { get; set; }

		public virtual Category Category { get; set; }
	}
}