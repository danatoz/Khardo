using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Entities.Base;

namespace UI.Models
{
    public class NewsModel : Entity
    {
		public string Title { get; set; }
		public string Url { get; set; }
		public string Content { get; set; }
		public DateTime CreationDate { get; set; }

		public static News ConvertToDal(NewsModel obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<NewsModel, News>());
			var mapper = new Mapper(config);
			return mapper.Map<NewsModel, News>(obj);
		}

		public static NewsModel ConvertFromDal(News obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<News, NewsModel>());
			var mapper = new Mapper(config);
			return mapper.Map<News, NewsModel>(obj);
		}

		public static List<NewsModel> ConvertListFromDal(IEnumerable<News> models)
		{
			return models.Select(ConvertFromDal).ToList();
		}

		public static List<News> ConvertListToDal(IEnumerable<NewsModel> models)
		{
			return models.Select(ConvertToDal).ToList();
		}
	}
}
