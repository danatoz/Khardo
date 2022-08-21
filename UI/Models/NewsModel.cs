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
			var result = models.Select(ConvertFromDal).ToList();

			return result;
		}

		public static List<News> ConvertListToDal(IEnumerable<NewsModel> models)
		{
			var result = models.Select(ConvertToDal).ToList();

			return result;
		}
	}
}
