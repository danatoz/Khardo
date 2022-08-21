using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models.ViewModels
{
    public class PagesInfoModel
    {
		public const int PageSizeForLoad = 10;
		public const int SelectPageBtnCount = 10;
		public int ItemsCount { get; set; }

		public int ItemsPerPage { get; set; }

		public int CurrentPage { get; set; }

		public int DisplayedPages { get; set; }

		public PagesInfoModel(int itemsCount, int itemsPerPage, int currentPage, int displayedPages)
		{
			ItemsCount = itemsCount;
			ItemsPerPage = itemsPerPage;
			CurrentPage = currentPage;
			DisplayedPages = displayedPages;
		}
	}
}
