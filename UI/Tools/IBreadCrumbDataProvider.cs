using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Tools
{
    public interface IBreadCrumbDataProvider
    {
        Task<IEnumerable<BreadCrumbModel>> GetDataAsync(string currentPageTitle);
    }
}
