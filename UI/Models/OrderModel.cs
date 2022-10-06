using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Entities;
using Entities.Base;

namespace UI.Models
{
    public class OrderModel : Entity
    {
	    public DateTime CreationDate { get; set; }

	    public int CustomerId { get; set; }

	    public CustomerModel Customer { get; set; }

	    public List<OrderPositionModel> OrderPositions { get; set; }

	    public static Order ConvertToDal(OrderModel obj)
	    {
		    var config = new MapperConfiguration(cfg =>
			    cfg.CreateMap<OrderModel, Order>());
		    var mapper = new Mapper(config);
		    return mapper.Map<OrderModel, Order>(obj);
	    }

	    public static OrderModel ConvertFromDal(Order obj)
	    {
		    var config = new MapperConfiguration(cfg =>
			    cfg.CreateMap<Order, OrderModel>());
		    var mapper = new Mapper(config);
		    return mapper.Map<Order, OrderModel>(obj);
	    }

	    public static List<OrderModel> ConvertListFromDal(IEnumerable<Order> obj)
	    {
		    return obj.Select(ConvertFromDal).ToList();
	    }

	    public static List<Order> ConvertListToDal(IEnumerable<OrderModel> obj)
	    {
		    return obj.Select(ConvertToDal).ToList();
	    }
	}
}
