

namespace AppCliente
{
    using System.Web.Mvc;
    using System.Web.Routing;
    public class RouteConfig
    {
     
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Application",
            url: "{*url}",
            defaults: new { controller = "Home", action = "Index" });
        }
    }
}
