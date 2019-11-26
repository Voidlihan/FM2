using FarmersMarket.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket.Services.Abstract
{
    public interface ISellerProductService
    {
        SellerProduct AddSellerProduct(Product product, Seller seller, int count, int price, string desc, string name);
        int DeleteSellerProduct(SellerProduct sellerProduct);
        SellerProduct EditSellerProduct(SellerProduct currentSellerProduct, int? count = null, int? price = null, Product product = null);
        List<SellerProduct> ShowSellerProducts(string category);
    }
}
