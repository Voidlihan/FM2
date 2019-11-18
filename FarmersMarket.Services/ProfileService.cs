using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FarmersMarket.Services
{
	public class ProfileService
	{
		private readonly FarmersMarketContext context;

		public ProfileService(FarmersMarketContext context)
		{
			this.context = context;
		}

		public void Add(Customer customer)
		{
			context.Add(customer);
			context.SaveChanges();
		}

		public Customer GetCustomer(User currentUser)
		{			
			var shortQuery = from cust in context.Customers
							 where cust.User.Equals(currentUser)
							 select cust;
			var result = shortQuery.First();
			;
			return shortQuery.First();
		}

		public void UpdateImage(string imagePath, User currentUser)
		{
			var shortQuery = from cust in context.Customers
							 where cust.User.Equals(currentUser)
							 select cust;
			var thisCustomer = shortQuery.First();

			thisCustomer.ImagePath = imagePath;

			context.Update(thisCustomer);
			context.SaveChanges();
		}

		public void UpdateProfile(Customer customerUpdate, User currentUser)
		{
			var shortQuery = from cust in context.Customers
							 where cust.User.Equals(currentUser)
							 select cust;
			var thisCustomer = shortQuery.First();

			thisCustomer.FirstName = customerUpdate.FirstName;
			thisCustomer.LastName = customerUpdate.LastName;
			thisCustomer.Address = customerUpdate.Address;
			context.Update(thisCustomer);
			context.SaveChanges();
		}

	}
}
