using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.DbModels;
using Entities;

namespace UI.Models
{
    public class CustomerModel : BaseUser
    {
	    public List<OrderModel> Orders { get; set; }

	    public static Customer ConvertToDal(CustomerModel obj)
	    {
		    var config = new MapperConfiguration(cfg =>
			    cfg.CreateMap<CustomerModel, Customer>());
		    var mapper = new Mapper(config);
		    return mapper.Map<CustomerModel, Customer>(obj);
	    }

	    public static CustomerModel ConvertFromDal(Customer obj)
	    {
		    var config = new MapperConfiguration(cfg =>
			    cfg.CreateMap<Customer, CustomerModel>());
		    var mapper = new Mapper(config);
		    return mapper.Map<Customer, CustomerModel>(obj);
	    }

	    public static List<CustomerModel> ConvertListFromDal(IEnumerable<Customer> obj)
	    {
		    return obj?.Select(ConvertFromDal).ToList();
	    }
	    public static List<Customer> ConvertListToDal(IEnumerable<CustomerModel> obj)
	    {
		    return obj?.Select(ConvertToDal).ToList();
	    }
	}
}
