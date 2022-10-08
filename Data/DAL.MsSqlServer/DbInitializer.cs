using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.TestData;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.MsSqlServer
{
	public class DbInitializer
	{
		private readonly ApplicationDbContext _db;
		private readonly ILogger<DbInitializer> _logger;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public DbInitializer(ApplicationDbContext db, ILogger<DbInitializer> logger, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_logger = logger;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		private async Task DeleteAsync(CancellationToken Cancel = default)
		{
			await _db.Database.EnsureDeletedAsync(Cancel).ConfigureAwait(false);
		}

		public async Task InitializeAsync(bool RemoveBefore = false, bool InitializeTestData = false, CancellationToken Cancel = default)
		{
			if (RemoveBefore)
				await DeleteAsync(Cancel).ConfigureAwait(false);

			var pending_migrations = await _db.Database.GetPendingMigrationsAsync(Cancel).ConfigureAwait(false);
			var applied_migrations = await _db.Database.GetPendingMigrationsAsync(Cancel);

			if (applied_migrations.Any())
			{
				_logger.LogInformation("К БД применены миграции: {0}", string.Join(",", applied_migrations));
			}
			if (pending_migrations.Any())
			{
				_logger.LogInformation("Применение миграций: {0}...", string.Join(",", pending_migrations));
				await _db.Database.MigrateAsync(Cancel);
				_logger.LogInformation("Применение миграций выполнено");
			}
			else
			{
				await _db.Database.EnsureCreatedAsync(Cancel);
			}

			if (InitializeTestData)
				await InitializeTestDataAsync(Cancel);
		}

		private async Task InitializeTestDataAsync(CancellationToken Cancel = default)
		{
			//if (await _db.Users.AnyAsync(Cancel).ConfigureAwait(false))
			//{
			//	_logger.LogInformation("В базе данных есть пользователи - в инициализации тестовыми данными не нуждается");
			//	return;
			//}

			var timer = Stopwatch.StartNew();

			await using var transaction = await _db.Database.BeginTransactionAsync(Cancel).ConfigureAwait(false);

			_db.Categories.AddRange(InitializeData.CategoryInitialize());
			_db.Countries.AddRange(InitializeData.CountryInitialize());
			_db.Manufacturers.AddRange(InitializeData.ManufactureInitialize());
			_db.ProductTemplates.AddRange(InitializeData.ProductTemplateInitialize());
			await _db.SaveChangesAsync(Cancel);

			var users = InitializeData.UsersInitialize();
			foreach (var user in users)
			{
				await _userManager.CreateAsync(user);
			}
			

			var roles = InitializeData.RoleInitialize();
			foreach (var role in roles)
				await _roleManager.CreateAsync(role);

			var user1 = await _userManager.FindByNameAsync("admin");
			var user2 = await _userManager.FindByNameAsync("manager");
			var user3 = await _userManager.FindByNameAsync("vendor");
			var user4 = await _userManager.FindByNameAsync("customer");

			_db.UserRoles.AddRange(new List<IdentityUserRole<string>>()
			{
				new IdentityUserRole<string>()
				{
					UserId = user1.Id,
					RoleId = _db.Roles.FirstOrDefault(item => item.Name == "admin")?.Id
				},
				new IdentityUserRole<string>()
				{
					UserId = user2.Id,
					RoleId = _db.Roles.FirstOrDefault(item => item.Name == "manager")?.Id
				},
				new IdentityUserRole<string>()
				{
					UserId = user3.Id,
					RoleId = _db.Roles.FirstOrDefault(item => item.Name == "vendor")?.Id
				},
				new IdentityUserRole<string>()
				{
					UserId = user4.Id,
					RoleId = _db.Roles.FirstOrDefault(item => item.Name == "customer")?.Id
				}
			});

			await _userManager.UpdateAsync(user1);
			await _userManager.UpdateAsync(user2);
			await _userManager.UpdateAsync(user3);
			await _userManager.UpdateAsync(user4);

			await transaction.CommitAsync(Cancel);
			_logger.LogInformation("Инициализация БД тестовыми данными выполнена успешно за {0} мс", timer.ElapsedMilliseconds);
		}
	}
}
