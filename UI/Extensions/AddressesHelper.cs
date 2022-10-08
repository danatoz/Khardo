using Microsoft.AspNetCore.Mvc;
using Common;

namespace UI.Extensions
{
    public static class AddressesExtensions
    {
        public static string GetArea(this IUrlHelper url)
        {
            return url.ActionContext.RouteData.Values["area"].ToString();
        }

        public static string GetController(this IUrlHelper url)
        {
            return url.ActionContext.RouteData.Values["controller"].ToString();
        }

        public static string GetAction(this IUrlHelper url)
        {
            return url.ActionContext.RouteData.Values["action"].ToString();
        }
    }
}