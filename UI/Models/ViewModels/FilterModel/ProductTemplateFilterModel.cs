using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models.ViewModels.FilterModel
{
    public class ProductTemplateFilterModel : BaseFilterModel
    {
	    [Display(Name = "Поисковый запрос")]
	    public string SearchQuery { get; set; }
    }
}
