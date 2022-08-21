using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Areas.Public.Models;

namespace UI.Tools
{
    public interface IBreadCrumbDataProvider
    {
        Task<IEnumerable<BreadCrumbModel>> GetDataAsync(string currentPageTitle);
    }
}
