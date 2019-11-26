using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using FarmersMarket.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersMarket.Services
{
    public class SellerProductService : ISellerProductService
    {
        private readonly FarmersMarketContext context;

        public SellerProductService(FarmersMarketContext context)
        {
            this.context = context;
        }

        public SellerProduct AddSellerProduct(Product product, Seller seller, int count, int price, string desc, string name)
        {
            if (count <= 0 || price <= 0 || desc == null || desc == string.Empty) return null;

            var newSellerProduct = new SellerProduct
            {
                ProductId = product.Id,
                SellerId = seller.Id,
                Count = count,
                Price = price,
				Description = desc,
				Name = name
            };

            context.SellerProducts.Add(newSellerProduct);
            context.SaveChanges();

            return newSellerProduct;
        }

        public int DeleteSellerProduct(SellerProduct sellerProduct)
        {
            context.SellerProducts.Remove(sellerProduct);
            return context.SaveChanges();
        }

        public SellerProduct EditSellerProduct(SellerProduct currentSellerProduct, int? count = null, int? price = null, Product product = null)
        {
            if (count <= 0 && price <= 0) return null;

            var newSellerProduct = new SellerProduct
            {
                Id = currentSellerProduct.Id,
                Product = product ?? currentSellerProduct.Product,
                Count = count ?? currentSellerProduct.Count,
                Price = price ?? currentSellerProduct.Price
            };

            context.SellerProducts.Update(newSellerProduct);
            context.SaveChanges();

            return newSellerProduct;
        }

        public List<SellerProduct> ShowSellerProducts(string categoryName)
        {
            return context.SellerProducts.Where(product => product.Product.Category.Name == categoryName).ToList();
        }

		public SellerProduct GetSellerProduct(string sellerProductId)
		{
			return context.SellerProducts.Where(sP => sP.Id == Guid.Parse(sellerProductId)).ToList().FirstOrDefault<SellerProduct>();
		}
	}
}
