using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models.ViewModels
{
	public class SearchResultViewModel<TModel>
	{
		public IList<TModel> Objects { get; set; }
		public PagesInfoModel PagesInfo { get; set; }

		public SearchResultViewModel(IEnumerable<TModel> objects, int totalCount, int requestedStartIndex,
			int? requestedCount, int displayedPages)
		{
			var pageSize = Math.Max(1, requestedCount ?? totalCount - requestedStartIndex);
			Objects = objects.ToList();
			PagesInfo = new PagesInfoModel(totalCount, pageSize, requestedStartIndex / pageSize + 1, displayedPages);
		}
	}

	public class SearchResultViewModel<TModel, TFilterModel> : SearchResultViewModel<TModel>
	{
		public TFilterModel FilterModel { get; set; }

		public SearchResultViewModel(IEnumerable<TModel> objects, TFilterModel filterModel, int totalCount, int requestedStartIndex,
			int? requestedCount, int displayedPages) : base(objects, totalCount, requestedStartIndex, requestedCount, displayedPages)
		{
			FilterModel = filterModel;
		}
	}
}
