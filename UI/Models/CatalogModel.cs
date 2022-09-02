using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DbModels;
using Tools;

namespace UI.Models
{
	public class CatalogModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Наименование")]
		public string Name { get; set; }
		public string Alias { get; set; }
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Изображение")]
		public string IconUrl { get; set; }
		[Display(Name = "Родительская категория")]
		public int? ParentId { get; set; }
		[Display(Name = "Активна")]
		public bool Active { get; set; }
		public CatalogModel ParentCatalog { get; set; }
		//public List<CatalogModel> Catalogs { get; set; }
		public List<ProductModel> Products { get; set; }

		public static Catalog ConvertToDal(CatalogModel obj)
		{
			return obj == null ? null : new Catalog
			{
				Id = obj.Id,
				Name = obj.Name,
				Alias = Transliteration.Translit(obj.Name),
				IconUrl = obj.IconUrl,
				ParentId = obj.ParentId,
				Active = obj.Active,
				Products = ProductModel.ConvertListToDal(obj.Products),
				ParentCatalog = ConvertToDal(obj.ParentCatalog),
				//Catalogs = ConvertListToDal(obj.Catalogs)
			};

		}

		public static CatalogModel ConvertFromDal(Catalog obj)
		{
			return obj == null ? null : new CatalogModel()
			{
				Id = obj.Id,
				Name = obj.Name,
				Alias = obj.Alias,
				IconUrl = obj.IconUrl,
				ParentId = obj.ParentId,
				Active = obj.Active,
				Products = ProductModel.ConvertListFromDal(obj.Products),
				ParentCatalog = ConvertFromDal(obj.ParentCatalog),
				//Catalogs = ConvertListFromDal(obj.Catalogs)
			};
		}

		public static List<CatalogModel> ConvertListFromDal(IEnumerable<Catalog> models)
		{
			return models?.Select(ConvertFromDal).ToList();
		}

		public static List<Catalog> ConvertListToDal(IEnumerable<CatalogModel> models)
		{
			return models?.Select(ConvertToDal).ToList();

		}

		public static CatalogModel ConvetForTree(Catalog obj)
		{
			return obj == null
				? null
				: new CatalogModel()
				{
					Id = obj.Id,
					Name = obj.Name,
					ParentId = obj.ParentId
				};
		}

		public static List<CatalogModel> ConvetForTreeList(List<Catalog> objList) =>
			objList?.Select(ConvetForTree).ToList();
	}
}
