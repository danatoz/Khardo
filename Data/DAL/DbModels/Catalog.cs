namespace DAL.DbModels
{
	public class Catalog : Entity
	{
		public string Name { get; set; }
		public string Alias { get; set; }

		public string IconUrl { get; set; }
		public int? ParentId { get; set; }
		public bool Active { get; set; }
		[ForeignKey("ParentId")]
		public Catalog ParentCatalog { get; set; }
		public bool IsPublic { get; set; }
		public List<Product> Products { get; set; }
	}
}
