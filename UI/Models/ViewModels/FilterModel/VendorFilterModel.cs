using System.ComponentModel.DataAnnotations;

namespace UI.Models.ViewModels.FilterModel
{
	public class UserFilterModel : BaseFilterModel
	{
		[Display(Name = "Поисковый запрос")]
		public string? SearchQuery { get; set; }

		[Display(Name = "Ответственный")]
		public string? ResponsibleId { get; set; }

		public UserFilterModel()
		{
			
		}
	}
}
