using DAL.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.Mocks;

namespace DAL
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext()
		{
			//Database.EnsureDeleted();
			//Database.EnsureCreated();
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Catalog> Catalogs{ get; set; }
		public DbSet<Part> Parts { get; set; }
		public DbSet<City> Cities { get; set; }


	}
}
