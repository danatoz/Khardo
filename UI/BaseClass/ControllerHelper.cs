using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Common.Enums;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace UI
{
	public static class ControllerHelper
	{
		public static string? GetCurrentUserId(this Controller controller)
		{
			var claimsIdentity = (ClaimsIdentity)controller.User.Identity;
			var claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
			return claim?.Value;
		}
	}
}
