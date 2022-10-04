using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbModels
{
    public class ProductPhoto : Entity
    {
		public string ProductTemplateId { get; set; }

	    public string UrlImage { get; set; }

	    [ForeignKey("ProductTemplateId")]
		public ProductTemplate ProductTemplate { get; set; }

	}
}
