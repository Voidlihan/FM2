namespace FarmersMarket.Domain
{
	public class Rating : Entity
	{
		public Seller Seller { get; set; }
		public Customer Customer { get; set; }
		public int Value { get; set; }
	}
}