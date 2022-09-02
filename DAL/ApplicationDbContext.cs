using DAL.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.Mocks;
using Microsoft.AspNetCore.Identity;

namespace DAL
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase("Default").Options;
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
			//builder.HasDefaultSchema("Identity");
			//builder.Entity<IdentityUser>(entity =>
			//{
			//	entity.ToTable(name: "User");
			//});
			//builder.Entity<IdentityRole>(entity =>
			//{
			//	entity.ToTable(name: "Role");
			//});
			//builder.Entity<IdentityUserRole<string>>(entity =>
			//{
			//	entity.ToTable("UserRoles");
			//});
			//builder.Entity<IdentityUserClaim<string>>(entity =>
			//{
			//	entity.ToTable("UserClaims");
			//});
			//builder.Entity<IdentityUserLogin<string>>(entity =>
			//{
			//	entity.ToTable("UserLogins");
			//});
			//builder.Entity<IdentityRoleClaim<string>>(entity =>
			//{
			//	entity.ToTable("RoleClaims");
			//});
			//builder.Entity<IdentityUserToken<string>>(entity =>
			//{
			//	entity.ToTable("UserTokens");
			//});
			//builder.Entity<Customer>(entity =>
			//{
			//	entity.ToTable(name: "Customers");
			//});
			//builder.Entity<Vendor>(entity =>
			//{
			//	entity.ToTable(name: "Vendors");
			//});
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Catalog> Catalogs { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Vendor> Vendors { get; set; }
		public DbSet<Order> Orders { get; set; }


	}
}
