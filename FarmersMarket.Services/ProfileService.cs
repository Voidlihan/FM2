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
			context.Customers.Add(customer);
			context.SaveChanges();
		}

		public void Add(Seller seller)
		{
			context.Sellers.Add(seller);
			context.SaveChanges();
		}

		public Customer GetCustomer(User currentUser)
		{
            var customer = context.Customers.SingleOrDefault(user => user.User.Id == currentUser.Id);
			return customer;
		}

		public void UpdateProfile(Customer customerUpdate, User currentUser)
		{
            var customer = context.Customers.SingleOrDefault(user => user.User.Id == currentUser.Id);

			customer.FirstName = customerUpdate.FirstName;
			customer.LastName = customerUpdate.LastName;
			customer.Address = customerUpdate.Address;
			context.Update(customer);
			context.SaveChanges();
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
	}
}
