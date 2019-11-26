using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersMarket.Services
{
	public class ProductService
	{
		private readonly FarmersMarketContext context;

		public ProductService(FarmersMarketContext context)
		{
			this.context = context;
		}

		public List<Product> GetAllByCategory(Category category)
		{
			return context.Products.Where(p => p.CategoryId == category.Id).ToList();
		}
	}
}
