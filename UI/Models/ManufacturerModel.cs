using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DbModels;

namespace UI.Models
{
	public class ManufacturerModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Rating { get; set; }
		public string UrlLogo { get; set; }


		public static Manufacturer ConvertToDal(ManufacturerModel obj)
		{
			return obj == null ? null : new Manufacturer
			{
				Id = obj.Id,
				Name = obj.Name,
				UrlLogo = obj.UrlLogo
			};
		}

		public static ManufacturerModel ConvertFromDal(Manufacturer obj)
		{
			return obj == null ? null : new ManufacturerModel
			{
				Id = obj.Id,
				Name = obj.Name,
				UrlLogo = obj.UrlLogo
			};
		}

		public static List<ManufacturerModel> ConvertListFromDal(IEnumerable<Manufacturer> models)
		{
			return models?.Select(ConvertFromDal).ToList();
		}
		public static List<Manufacturer> ConvertListToDal(IEnumerable<ManufacturerModel> models)
		{
			return models?.Select(ConvertToDal).ToList();
		}
	}
}
