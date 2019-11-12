using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using FarmersMarket.Services.Abstract;
using System;
using System.Collections.Generic;
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

        public SellerProduct AddSellerProduct(Product product, Seller seller, int count, int price)
        {
            if (count <= 0 && price <= 0) return null;

            var newSellerProduct = new SellerProduct
            {
                Product = product,
                Seller = seller,
                Count = count,
                Price = price
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
    }
}
