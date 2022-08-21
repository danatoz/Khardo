using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Areas.Public.Models
{
    public class BreadCrumbModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public bool IsActive { get; set; }

    }
}
