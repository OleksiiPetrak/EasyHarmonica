using System.Web.Mvc;
using System.Web.Routing;

namespace EasyHarmonica.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"Register",
                url: "registration",
                defaults: new {controller ="Account",action="Register"}
            );

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new {controller =  "Account", action = "Login", id= UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GetLessons",
                url: "lessons",
                defaults: new { controller = "Lesson", action = "GetLessons", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Chapter", action = "GetChapters", id = UrlParameter.Optional }
            );
        }
    }
}
