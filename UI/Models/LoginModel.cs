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
    }
}
