namespace FarmersMarket.Domain
{
	public class Rating : Entity
	{
		public virtual Seller Seller { get; set; }
		public virtual Customer Customer { get; set; }
		public int Value { get; set; }
	}
}