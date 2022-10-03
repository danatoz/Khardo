using Microsoft.AspNetCore.Mvc;

namespace UI
{
	public static class ControllerHelper
	{
		public static int? GetCurrentUserId(this Controller controller)
		{
			return (controller.User.Identity as CustomUserIdentity)?.Id;
		}
	}
}
