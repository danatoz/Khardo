using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class CustomerDbContext : IdentityDbContext<Customer, IdentityRole, string>
	{
		public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
		{
			options = new DbContextOptionsBuilder<CustomerDbContext>()
				.UseInMemoryDatabase("Default").Options;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.HasDefaultSchema("Identity");
			builder.Entity<IdentityUser>(entity =>
			{
				entity.ToTable(name: "Customers");
			});
			builder.Entity<IdentityRole>(entity =>
			{
				entity.ToTable(name: "Roles");
			});
			builder.Entity<IdentityUserRole<string>>(entity =>
			{
				entity.ToTable("CustomerRoles");
			});
			builder.Entity<IdentityUserClaim<string>>(entity =>
			{
				entity.ToTable("CustomerClaims");
			});
			builder.Entity<IdentityUserLogin<string>>(entity =>
			{
				entity.ToTable("CustomerLogins");
			});
			builder.Entity<IdentityRoleClaim<string>>(entity =>
			{
				entity.ToTable("RoleClaims");
			});
			builder.Entity<IdentityUserToken<string>>(entity =>
			{
				entity.ToTable("CustomerTokens");
			});
		}
	}
}
