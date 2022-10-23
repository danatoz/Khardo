using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models.ViewModels
{
	public class ProductViewModel
	{
		public ProductTemplateModel ProductTemplateModel { get; set; }

		public List<ProductModel> ProductModels { get; set; }
	}
}
