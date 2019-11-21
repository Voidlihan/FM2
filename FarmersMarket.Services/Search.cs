using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersMarket.Services
{
    public class Search
    {
        public List<Product> FindOfProduct(string productName, int count, FarmersMarketContext context)
        {
            int page = 0;
            var products = from item in context.Products
                           where item.Name.Contains(productName)
                           select item;
            int productCount = products.Count();
            if (productCount == 0)
            {
                return new List<Product>();
            }
            page = productCount / count;
            if (productCount % count != 0) 
            {
                page++;
            }
            return ToPagination(products.ToList<Product>(), page, count);
        }

        public List<Product> ToPagination(List<Product> products, int page, int count)
        {
            return products.Skip(page * count).Take(count).ToList();
        }
    }
}
