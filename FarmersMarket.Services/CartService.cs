using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmersMarket.Services
{
    public class CartService
    {
        private readonly FarmersMarketContext context;

        public CartService(FarmersMarketContext context)
        {
            this.context = context;
        }

        public bool AddProductToCart(Cart cart)
        {
            if (cart.Count <= 0) return false;

            context.Carts.Add(cart);
            context.SaveChanges();
            return true;
        }

        public void RemoveProductToCart(Cart cart)
        {
            context.Carts.Remove(cart);
            context.SaveChanges();
        }
    }
}
