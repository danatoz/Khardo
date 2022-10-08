using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TestData
{
	public class CustomerTestData
	{
		public static void SetTestData(CustomerDbContext context)
		{
			try
			{
				var users = new List<Customer>()
				{
					new Customer
					{
						Email = "customer@customer.ru",
						NormalizedEmail = "customer@customer.ru",
						UserName = "customer",
						NormalizedUserName = "customer".ToUpper(),
						PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
					},
					new Customer()
					{
						Email = "customer@customer.ru",
						NormalizedEmail = "customer1@customer.ru",
						UserName = "customer",
						NormalizedUserName = "customer1".ToUpper(),
						PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
					},
					new Customer()
					{
						Email = "customer2@customer.ru",
						NormalizedEmail = "customer@customer.ru",
						UserName = "customer2",
						NormalizedUserName = "customer2".ToUpper(),
						PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
					}
				};
				context.Users.AddRange(users);
				context.SaveChanges();

				var roles = new IdentityRole()
				{
					Name = "customer",
					NormalizedName = "customer".ToUpper(),
					ConcurrencyStamp = ""
				};
				context.Roles.Add(roles);
				context.SaveChanges();
				var customerRole = context.Roles.FirstOrDefault();
				var customer = context.Users.FirstOrDefault(item => item.UserName == "customer");
				var userRoles = new IdentityUserRole<string>()
				{
					RoleId = customerRole.Id,
					UserId = customer.Id
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
