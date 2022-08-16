using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DbModels;

namespace UI.Models
{
    public class CatalogModel
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string IconUrl { get; set; }
		public int ParentId { get; set; }
		public CatalogModel ParentCatalog { get; set; }
		public List<PartModel> Parts { get; set; }

		public static Catalog ConvertToDal(CatalogModel model)
		{
			var result = new Catalog
			{
				Id = model.Id,
				Name = model.Name,
				Url = model.Url,
				IconUrl = model.IconUrl,
				ParentId = model.ParentId,
				Parts = PartModel.ConvertListToDal(model.Parts),
				ParentCatalog = ConvertToDal(model.ParentCatalog)
			};

			return result;
		}
	}
}
