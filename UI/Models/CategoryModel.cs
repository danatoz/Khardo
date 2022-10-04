using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.DbModels;
using Entities.Base;
using Tools;

namespace UI.Models
{
	public class CategoryModel : Entity
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Наименование")]
		public string Name { get; set; }

		public string Description { get; set; }

		public string Alias { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Изображение")]
		public string IconUrl { get; set; }

		[Display(Name = "Родительская категория")]
		public int? ParentId { get; set; }

		[Display(Name = "Активна")]
		public bool Active { get; set; }

		public bool IsPublic { get; set; }

		public CategoryModel ParentCategory { get; set; }

		public List<ProductTemplateModel> ProductTemplates { get; set; }

		public static Category ConvertToDal(CategoryModel obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<CategoryModel, Category>());
			var mapper = new Mapper(config);
			return mapper.Map<CategoryModel, Category>(obj);
		}

		public static CategoryModel ConvertFromDal(Category obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<Category, CategoryModel>());
			var mapper = new Mapper(config);
			return mapper.Map<Category, CategoryModel>(obj);
		}

		public static List<CategoryModel> ConvertListFromDal(IEnumerable<Category> obj)
		{
			return obj?.Select(ConvertFromDal).ToList();
		}

		public static List<Category> ConvertListToDal(IEnumerable<CategoryModel> obj)
		{
			return obj?.Select(ConvertToDal).ToList();

		}

		public static CategoryModel ConvetForTree(Category obj)
		{
			return obj == null
				? null
				: new CategoryModel()
				{
					Id = obj.Id,
					Name = obj.Name,
					ParentId = obj.ParentId
				};
		}

		public static List<CategoryModel> ConvetForTreeList(List<Category> objList) =>
			objList?.Select(ConvetForTree).ToList();
	}
}
