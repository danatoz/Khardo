using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace UI.Models
{
	public class UserModel : BaseUser
	{
		[DisplayName("Контактное лицо")]
		public string ContactPerson { get; set; }

		[DisplayName("Наименование организации")]
		public string NameOrganization { get; set; }

		[DisplayName("Рейтинг")]
		public int? Rating { get; set; }

		[DisplayName("Ответственный менеджер")]
		public string ResponsibleId { get; set; }

		[DisplayName("ИНН")]
		public string ITN { get; set; }

		[DisplayName("БИК")]
		public string BIC { get; set; }

		[DisplayName("Физический адрес")]
		public string PhysicalAdress { get; set; }

		[DisplayName("Юредический адрес")]
		public string LegalAddress { get; set; }

		[DisplayName("Город")]
		public Guid? CityId { get; set; }

		public User Responsible { get; set; }

		public City City { get; set; }

		public List<User> Vendors { get; set; }

		public List<Order> Orders { get; set; }

		public List<PriceList> PriceLists { get; set; }

		public static UserModel ConvertToModel(User obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<User, UserModel>()
					.ForSourceMember(source => source.City,
						cfg => cfg.DoNotValidate())
					.ForSourceMember(source => source.Vendors,
						cfg => cfg.DoNotValidate())
					.ForSourceMember(source => source.Orders,
						cfg => cfg.DoNotValidate())
					.ForSourceMember(source => source.Responsible,
						cfg => cfg.DoNotValidate())
					.ForSourceMember(source => source.PriceLists,
						cfg => cfg.DoNotValidate()));
			var mapper = new Mapper(config);
			return mapper.Map<User, UserModel>(obj);
		}

		public static User ConvertToEntity(UserModel obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<UserModel, User>()
					.ForSourceMember(source => source.City,
						cfg => cfg.DoNotValidate())
					.ForSourceMember(source => source.Vendors,
						cfg => cfg.DoNotValidate())
					.ForSourceMember(source => source.Orders,
						cfg => cfg.DoNotValidate())
					.ForSourceMember(source => source.Responsible,
						cfg => cfg.DoNotValidate())
					.ForSourceMember(source => source.PriceLists,
						cfg => cfg.DoNotValidate()));
			var mapper = new Mapper(config);
			return mapper.Map<UserModel, User>(obj);
		}

		public static List<UserModel> ConvertListToModels(IEnumerable<User> obj)
		{
			return obj?.Select(ConvertToModel).ToList();
		}

		public static List<User> ConvertListToEntities(IEnumerable<UserModel> obj)
		{
			return obj?.Select(ConvertToEntity).ToList();
		}
	}
}
