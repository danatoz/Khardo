using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DbModels;

namespace UI.Models
{
    public class PartModel
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string UrlImage { get; set; }
		public string Description { get; set; }
		public int Amount { get; set; }
		public int CatalogId { get; set; }
		public CatalogModel Catalog { get; set; }

		public static Part ConvertToDal(PartModel model)
		{
			var result = new Part
			{
				Id = model.Id,
				Name = model.Name,
				Amount = model.Amount,
				CatalogId = model.CatalogId,
				Description = model.Description,
				UrlImage = model.UrlImage
			};

			return result;
		}

		public static List<Part> ConvertListToDal(IEnumerable<PartModel> models)
		{
			var result = models.Select(ConvertToDal).ToList();

			return result;
		}
	}
}
