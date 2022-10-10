using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace Entities
{
    public class ProductPhoto : Entity
    {
		public Guid ProductTemplateId { get; set; }

	    public string UrlImage { get; set; }

	    [ForeignKey("ProductTemplateId")]
		public ProductTemplate ProductTemplate { get; set; }

	}
}
