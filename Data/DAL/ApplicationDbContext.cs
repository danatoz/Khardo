using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DAL
{
	public partial class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			//options = new DbContextOptionsBuilder<ApplicationDbContext>()
			//	.UseInMemoryDatabase("Default").Options;
		}

		public ApplicationDbContext()
		{
			
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			//optionsBuilder.UseInMemoryDatabase("Default");
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer("Server=localhost;Database=Khardo;Trusted_Connection=True;MultipleActiveResultSets=true");
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<User>(entity =>
			{
				entity.ToTable(name: "Users");
			});
			builder.Entity<IdentityRole>(entity =>
			{
				entity.ToTable(name: "Roles");
			});
			builder.Entity<IdentityUserRole<string>>(entity =>
			{
				entity.ToTable("UserRoles");
			});
			builder.Entity<IdentityUserClaim<string>>(entity =>
			{
				entity.ToTable("UserClaims");
			});
			builder.Entity<IdentityUserLogin<string>>(entity =>
			{
				entity.ToTable("UserLogins");
			});
			builder.Entity<IdentityRoleClaim<string>>(entity =>
			{
				entity.ToTable("RoleClaims");
			});
			builder.Entity<IdentityUserToken<string>>(entity =>
			{
				entity.ToTable("UserTokens");
			});
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductPhoto> ProductPhotos { get; set; }
		public DbSet<ProductTemplate> ProductTemplates { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<OrderPosition> OrderPositions { get; set; }
		public DbSet<PriceList> Prices { get; set; }


	}
}
