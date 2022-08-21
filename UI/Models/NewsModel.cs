using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DbModels;

namespace UI.Models
{
    public class NewsModel
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public string Content { get; set; }
		public DateTime CreationDate { get; set; }

		public static News ConvertToDal(NewsModel model)
		{
			var result = new News
			{
				Id = model.Id,
				Title = model.Title,
				Content = model.Content,
				CreationDate = model.CreationDate,
				Url = model.Url
			};

			return result;
		}

		public static NewsModel ConvertFromDal(News model)
		{
			var result = new NewsModel
			{
				Id = model.Id,
				Title = model.Title,
				Content = model.Content,
				CreationDate = model.CreationDate,
				Url = model.Url

			};

			return result;
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
