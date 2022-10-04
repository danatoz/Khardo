
using AutoMapper;
using DAL.DbModels;
using System.Collections.Generic;
using System.Linq;

namespace UI.Models
{
	public class OrderPositionModel
	{
		public long Id { get; set; }

		public long OrderId { get; set; }

		public long ProductId { get; set; }

		public ProductModel Product { get; set; }

		public OrderPositionModel Order { get; set; }

		public static OrderPosition ConvertToDal(OrderPositionModel obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<OrderPositionModel, OrderPosition>());
			var mapper = new Mapper(config);
			return mapper.Map<OrderPositionModel, OrderPosition>(obj);
		}

		public static OrderPositionModel ConvertFromDal(OrderPosition obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<OrderPosition, OrderPositionModel>());
			var mapper = new Mapper(config);
			return mapper.Map<OrderPosition, OrderPositionModel>(obj);
		}

		public static List<OrderPositionModel> ConvertListFromDal(IEnumerable<OrderPosition> obj)
		{
			return obj.Select(ConvertFromDal).ToList();
		}

		public static List<OrderPosition> ConvertListToDal(IEnumerable<OrderPositionModel> obj)
		{
			return obj.Select(ConvertToDal).ToList();
		}
	}
}
