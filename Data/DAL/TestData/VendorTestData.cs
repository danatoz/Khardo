using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TestData
{
	public class VendorTestData
	{
		public static void SetTestData(VendorDbContext context)
		{
			try
			{
				var users = new List<Vendor>()
				{
					new Vendor
					{
						Email = "vendor@vendor.ru",
						NormalizedEmail = "vendor@vendor.ru",
						UserName = "vendor",
						NormalizedUserName = "vendor".ToUpper(),
						PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
					},
					new Vendor()
					{
						Email = "vendor@vendor.ru",
						NormalizedEmail = "vendor@vendor.ru",
						UserName = "vendor",
						NormalizedUserName = "vendor".ToUpper(),
						PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
					},
					new Vendor()
					{
						Email = "vendor2@vendor.ru",
						NormalizedEmail = "vendor@vendor.ru",
						UserName = "vendor2",
						NormalizedUserName = "vendor2".ToUpper(),
						PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
					}
				};
				context.Users.AddRange(users);
				context.SaveChanges();

				var roles = new IdentityRole()
				{
					Name = "vendor",
					NormalizedName = "vendor".ToUpper(),
					ConcurrencyStamp = ""
				};
				context.Roles.Add(roles);
				context.SaveChanges();
				var vendorRole = context.Roles.FirstOrDefault();
				var vendor = context.Users.FirstOrDefault(item => item.UserName == "vendor");
				var userRoles = new IdentityUserRole<string>()
				{
					RoleId = vendorRole.Id,
					UserId = vendor.Id
				};
				context.UserRoles.Add(userRoles);
				context.SaveChanges();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

		}

	}
}
