using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.TestData
{
	public class UsersTestData
	{
		public static void SetTestData(UserDbContext context)
		{
			try
			{
				var users = new List<User>()
				{
					new User
					{
						Email = "admin@admin.ru",
						NormalizedEmail = "admin@admin.ru",
						UserName = "admin",
						NormalizedUserName = "admin".ToUpper(),
						PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
						CityId = 1,
					},
					new User()
					{
						Email = "manager@manager.ru",
						NormalizedEmail = "manager@manager.ru",
						UserName = "manager",
						NormalizedUserName = "manager".ToUpper(),
						PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
						CityId = 1,
					},
					new User()
					{
						Email = "manager2@manager.ru",
						NormalizedEmail = "manager@manager.ru",
						UserName = "manager2",
						NormalizedUserName = "manager2".ToUpper(),
						PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
						CityId = 1,
					},
					new User()
					{
						Email = "vendor@vendor.ru",
						NormalizedEmail = "vendor@vendor.ru",
						UserName = "vendor",
						NormalizedUserName = "vendor".ToUpper(),
						PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
						NameOrganization = "ООО \"Понтал++\"",
					},
					new User()
					{
						Email = "customer@customer.ru",
						NormalizedEmail = "customer@customer.ru",
						UserName = "customer",
						NormalizedUserName = "customer".ToUpper(),
						PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
						CityId = 1,
					}
				};
				context.Users.AddRange(users);
				context.SaveChanges();

				var roles = new List<IdentityRole>()
				{
					new IdentityRole()
					{
						Name = "admin",
						NormalizedName = "admin".ToUpper(),
						ConcurrencyStamp = ""
					},					
					new IdentityRole()
					{
						Name = "manager",
						NormalizedName = "manager".ToUpper(),
						ConcurrencyStamp = ""
					},					
					new IdentityRole()
					{
						Name = "customer",
						NormalizedName = "customer".ToUpper(),
						ConcurrencyStamp = ""
					},					
					new IdentityRole()
					{
						Name = "vendor",
						NormalizedName = "vendor".ToUpper(),
						ConcurrencyStamp = ""
					},
				};
				context.Roles.AddRange(roles);
				context.SaveChanges();
				var admin = context.Users.FirstOrDefault(item => item.UserName == "admin");
				var manager = context.Users.FirstOrDefault(item => item.UserName == "manager");
				var vendor = context.Users.FirstOrDefault(item => item.UserName == "vendor");
				var customer = context.Users.FirstOrDefault(item => item.UserName == "customer");
				var userRoles = new List<IdentityUserRole<string>>()
				{
					new IdentityUserRole<string>()
					{
						RoleId = context.Roles.FirstOrDefault(item => item.Name == "admin").Id,
						UserId = admin.Id
					},					
					new IdentityUserRole<string>()
					{
						RoleId = context.Roles.FirstOrDefault(item => item.Name == "manager").Id,
						UserId = manager.Id
					},					
					new IdentityUserRole<string>()
					{
						RoleId = context.Roles.FirstOrDefault(item => item.Name == "vendor").Id,
						UserId = vendor.Id
					},					
					new IdentityUserRole<string>()
					{
						RoleId = context.Roles.FirstOrDefault(item => item.Name == "customer").Id,
						UserId = customer.Id
					},
				};
				context.UserRoles.AddRange(userRoles);
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
