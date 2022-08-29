using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Common.Enums;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(AuthenticationSchemes = nameof(AuthScheme.Admin))]
    public class VendorsController : BaseController
    {
	    private readonly ILogger<VendorsController> _logger;

	    public VendorsController(ILogger<VendorsController> logger)
	    {
		    _logger = logger;
	    }
    }
}
