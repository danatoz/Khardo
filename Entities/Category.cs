using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace Entities
{
	public class Category : Entity
	{

		public string Name { get; set; }

		public string Description { get; set; }

		public string Alias { get; set; }

		public string IconUrl { get; set; }

		public int? ParentId { get; set; }

		public bool Active { get; set; }

		public bool IsPublic { get; set; }

		[ForeignKey("ParentId")]
		public Category ParentCategory { get; set; }

		public List<ProductTemplate> ProductTemplates { get; set; }
	}
}
