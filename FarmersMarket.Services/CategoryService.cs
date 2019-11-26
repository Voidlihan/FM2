using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersMarket.Services
{
	public class CategoryService
	{
		private readonly FarmersMarketContext context;

		public CategoryService(FarmersMarketContext context)
		{
			this.context = context;
		}

		public List<Category> GetAll()
		{
			return context.Categories.ToList();
		}
	}
}
