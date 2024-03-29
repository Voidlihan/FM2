﻿using FarmersMarket.Domain;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarket.DataAccess
{
	public class FarmersMarketContext : DbContext
	{
		private readonly string connectionString;
		public FarmersMarketContext(string connectionString)
		{
			this.connectionString = connectionString;
			Database.EnsureCreated();
		}

		public DbSet<Cart> Carts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Chat> Chats { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<FavoriteProducts> FavoriteCategories { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Product> Products  { get; set; }
		public DbSet<Customer> Profiles  { get; set; }
		public DbSet<Rating> Ratings  { get; set; }
		public DbSet<Seller> Sellers  { get; set; }
		public DbSet<SellerProduct> SellerProducts  { get; set; }
		public DbSet<User> Users  { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Chat>()
		   .HasOne(s => s.Seller)
		   .WithMany(m => m.Chats)
		   .OnDelete(DeleteBehavior.NoAction);
		}
	}
}
