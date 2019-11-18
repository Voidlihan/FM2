namespace FarmersMarket.Domain
{
	public class FavoriteProducts : Entity
	{
		public virtual Customer Customer { get; set; }

		public virtual Product Product { get; set; }
	}
}