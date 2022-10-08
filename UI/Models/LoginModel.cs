using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class LoginModel
    {
	    [Required(ErrorMessage = "Не указан логин")]
	    public string UserName { get; set; }

	    [Required(ErrorMessage = "Не указан пароль")]
	    [DataType(DataType.Password)]
	    public string Password { get; set; }

	    public bool RememberMe { get; set; }

	    public string ReturnUrl { get; set; }
    }
}
