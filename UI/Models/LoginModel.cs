using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DbModels;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace UI.Models
{
    public class LoginModel
    {
	    [Required(ErrorMessage = "Не указан Email")]
	    public string Login { get; set; }

	    [Required(ErrorMessage = "Не указан пароль")]
	    [DataType(DataType.Password)]
	    public string Password { get; set; }

	    public bool RememberMe { get; set; }
	    public string ReturnUrl { get; set; }

	    public async Task<User> VerifyUser(LoginModel model, ApplicationDbContext context)
	    {
		    var user = new User();
		    try
		    {
				//var passwordHash = HashPassword()
			    user = await context.Users.FirstOrDefaultAsync(item =>
				    item.UserName == model.Login && item.PasswordHash == model.Password);

		    }
		    catch (Exception ex)
		    {
			    Console.WriteLine(ex);
		    }

		    return user;
	    }

	    private static async Task<string> HashPassword(User user,string password)
	    {
		    var ph = new PasswordHasher<User>();

		    var hash = ph.HashPassword(user, password);

		    return hash;
	    }
	}
}
