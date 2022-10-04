using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UI.Models.ViewModels.FilterModel
{
	public class VendorFilterModel : BaseFilterModel
	{
		[Display(Name = "Поисковый запрос")]
		public string SearchQuery { get; set; }

		[Display(Name = "Ответственный")]
		public int? ResponsibleId { get; set; }

		public VendorFilterModel()
		{
			
		}
	}
}
