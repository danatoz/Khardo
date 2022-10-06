using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.Mocks;
using Microsoft.AspNetCore.Identity;

namespace DAL
{
	public partial class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase("Default").Options;
		}

		public ApplicationDbContext()
		{
			
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseInMemoryDatabase("Default");
			//optionsBuilder.UseSqlServer("Server=localhost;Database=Khardo;Trusted_Connection=True;MultipleActiveResultSets=true");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductPhoto> ProductPhotos { get; set; }
		public DbSet<ProductTemplate> ProductTemplates { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Vendor> Vendors { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<OrderPosition> OrderPositions { get; set; }


	}
}
